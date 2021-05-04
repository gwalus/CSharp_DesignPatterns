using System;

namespace Factory_Coding_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var person1 = new PersonFactory().CreatePerson("John");
            var person2 = new PersonFactory().CreatePerson("John");
            var person3 = new PersonFactory().CreatePerson("John");

            Console.WriteLine(person1);
            Console.WriteLine(person2);
            Console.WriteLine(person3);
        }

        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }


            public Person(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString()
            {
                return $"{Id}, {Name}";
            }
        }

        public class PersonFactory
        {
            private static int id = 0;

            public Person CreatePerson(string name)
            {
                return new Person(id++, name);
            }
        }
    }
}
