using System;

namespace ICloneable_is_Bad
{
    class Program
    {
        static void Main(string[] args)
        {
            var john = new Person(new[] { "John", "Smith" }, 
                new Address("London Road", 123));

            // Repleacing reference
            //var jane = john;
            //jane.Names[0] = "Jane";

            //Console.WriteLine(john);
            //Console.WriteLine(jane);

            //var jane = (Person)john.Clone();
            //jane.Address.HouseNumber = 500;
            //jane.Names[0] = "Jane";

            // Copy constructor
            //var jane = new Person(john);
            //jane.Address.HouseNumber = 321;

            //Deep Copy
            var jane = john.DeepCopy();
            jane.Address.HouseNumber = 321;


            Console.WriteLine(john);
            Console.WriteLine(jane);
        }        
    }

 //public class Person : ICloneable
    public class Person : IPrototype<Person>
    {
        public string[] Names { get; set; }
        public Address Address { get; set; }

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public Person(Person other)
        {
            Names = other.Names;
            Address = new Address(other.Address);
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}, {2}: {3}", nameof(Names), string.Join(" ", Names), nameof(Address), Address);
        }

        // DeepClone
        public object Clone()
        {
            return new Person(Names, (Address)Address.Clone());
        }

        public Person DeepCopy()
        {
            return new Person(Names, Address.DeepCopy());
        }
    }


    //public class Address : ICloneable
    public class Address : IPrototype<Address>
    {
        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public Address(Address other)
        {
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }

        public string StreetName { get; set; }
        public int HouseNumber { get; set; }

        public object Clone()
        {
            return new Address(StreetName, HouseNumber);
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}, {2}: {3}", nameof(StreetName), StreetName, nameof(HouseNumber), HouseNumber.ToString());
        }

        public Address DeepCopy()
        {
            return new Address(StreetName, HouseNumber);
        }
    }

    public interface IPrototype<T>
    {
        T DeepCopy();
    }
}
