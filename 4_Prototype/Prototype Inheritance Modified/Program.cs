using System;

namespace Prototype_Inheritance_Modified
{
    class Program
    {
        static void Main(string[] args)
        {
            var john = new Employee();

            john.Names = new[] { "John", "Doe" };
            john.Address = new Address
            {
                HouseNumber = 123,
                StreetName = "London street"
            };

            john.Salary = 321000;
            var copy = john.DeepCopy();

            copy.Names[1] = "Smith";
            copy.Address.HouseNumber++;
            copy.Salary = 123000;

            Console.WriteLine(john);
            Console.WriteLine(copy);
        }
    }

    public class Address : IDeepCopyable<Address>
    {
        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public Address()
        {

        }

        public string StreetName { get; set; }
        public int HouseNumber { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(StreetName)}={StreetName}, {nameof(HouseNumber)}={HouseNumber.ToString()}}}";
        }

        public void CopyTo(Address target)
        {
            target.StreetName = StreetName;
            target.HouseNumber = HouseNumber;
        }
    }

    public class Person : IDeepCopyable<Person>
    {
        public string[] Names { get; set; }
        public Address Address { get; set; }

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public Person()
        {

        }

        public override string ToString()
        {
            return $"{{{nameof(Names)}={string.Join(",", Names)}, {nameof(Address)}={Address}}}";
        }

        public void CopyTo(Person target)
        {
            target.Names = (string[])Names;
            target.Address = Address.DeepCopy(); // broken // works after add extension method           
        }
    }

    public class Employee : Person, IDeepCopyable<Employee>
    {
        public Employee(string[] names, Address address, int salary) : base(names, address)
        {
            Salary = salary;
        }

        public Employee() : base()
        {
        }

        public int Salary { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(Salary)}: {Salary}";
        }

        public void CopyTo(Employee target)
        {
            base.CopyTo(target);
            target.Salary = Salary;
        }
    }

    public static class ExtensionsMethods
    {
        public static T DeepCopy<T>(this IDeepCopyable<T> item) where T : new()
        {
            return item.DeepCopy();
        }

        public static T DeepCopy<T>(this T person) where T : Person, new()
        {
            return ((IDeepCopyable<T>)person).DeepCopy();
        }
    }

    public interface IDeepCopyable<T> where T : new()
    {
        void CopyTo(T target);

        public T DeepCopy()
        {
            T t = new T();
            CopyTo(t);
            return t;
        }
    }
}
