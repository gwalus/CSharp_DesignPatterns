using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Copy_Through_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var john = new Person(new[] { "John", "Doe" },
                new Address("London street", 213));
            
            var jane = john.DeepCopyXml();
            jane.Names[0] = "Jane";
            jane.Address.HouseNumber = 213123;



            Console.WriteLine(john);
            Console.WriteLine(jane);
        }
    }

    //[Serializable]
    public class Address
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
    }

    //[Serializable]
    public class Person
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
    }

    public class Employee : Person
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
    }

    public static class ExtensionsMethods
    {
        // Attribute Serializable is required
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();

            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T)copy;
        }

        // Not required
        // But we must a default constructors
        public static T DeepCopyXml<T>(this T self)
        {
            using(var ms = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                ms.Position = 0;
                return (T)s.Deserialize(ms);
            }
        }
    }
}
