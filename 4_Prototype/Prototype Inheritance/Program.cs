using System;

namespace Prototype_Inheritance
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
            Console.WriteLine(copy );
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

        public Address DeepCopy()
        {
            return (Address)MemberwiseClone();
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

        public Person DeepCopy()
        {
            return new Person((string[]) Names.Clone(), Address.DeepCopy());
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

        public Employee DeepCopy()
        {
            return new Employee((string[])Names.Clone(), Address.DeepCopy(), Salary);
        }
    }

    public interface IDeepCopyable<T>
    {
        T DeepCopy();
    }
}
