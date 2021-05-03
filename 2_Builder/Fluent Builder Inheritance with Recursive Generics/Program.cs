using System;

namespace Fluent_Builder_Inheritance_with_Recursive_Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            //var builder = new PersonJobBulider();

            //builder.Called("John");
            //builder.WorksAsA("Developer");

            var person = Person.New
                .Called("John")
                .WorksAsA("Developer")
                .WithAge(18)
                .Build();

            Console.WriteLine(person);
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }

        public class Builder : PersonAgeBulider<Builder>
        {

        }

        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}, {nameof(Age)}: {Age}";
        }
    }

    public abstract class PersonBuilder
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }

    public class PersonInfoBuilder<SELF> : PersonBuilder where SELF : PersonInfoBuilder<SELF>
    {
        //protected Person person = new Person();

        //public PersonInfoBuilder Called(string name)
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }

    public class PersonJobBulider<SELF> : PersonInfoBuilder<PersonJobBulider<SELF>> where SELF : PersonJobBulider<SELF>
    {
        // public PersonJobBulider WorksAsA(string position)
        public SELF WorksAsA(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }

    public class PersonAgeBulider<SELF> : PersonJobBulider<PersonAgeBulider<SELF>> where SELF : PersonAgeBulider<SELF>
    {
        // public PersonJobBulider WorksAsA(string position)
        public SELF WithAge(int age)
        {
            person.Age = age;
            return (SELF)this;
        }
    }
}
