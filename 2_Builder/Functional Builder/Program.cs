using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional_Builder
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            var person = new PersonBuilder()
                .Called("John")
                .WorksAs("Developer")
                .WithAge(20)
                .Build();

            Console.WriteLine(person);
        }
    }

    public abstract class FunctionalBuilder<TSubject, TSelf>
        where TSubject : new()
        where TSelf : FunctionalBuilder<TSubject, TSelf>
    {
        private readonly List<Func<Person, Person>> _actions = new List<Func<Person, Person>>();

        //public TSelf Called(string name)
        //    => Do(p => p.Name = name);

        public TSelf Do(Action<Person> action)
                => AddAction(action);

        public Person Build()
            => _actions.Aggregate(new Person(), (p, f) => f(p));

        private TSelf AddAction(Action<Person> action)
        {
            _actions.Add(p =>
            {
                action(p);
                return p;
            });

            return (TSelf)this;
        }
    }

    public sealed class PersonBuilder : FunctionalBuilder<Person, PersonBuilder>
    {
        public PersonBuilder Called(string name)
            => Do(p => p.Name = name);
    }

    public class Person
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Position: {Position}, Age: {Age}";
        }
    }

    //public sealed class PersonBuilder
    //{
    //    private readonly List<Func<Person, Person>> actions = new List<Func<Person, Person>>();

    //    public PersonBuilder Called(string name)
    //        => Do(p => p.Name = name);

    //    public PersonBuilder Do(Action<Person> action)
    //            => AddAction(action);

    //    public Person Build()
    //        => actions.Aggregate(new Person(), (p, f) => f(p));

    //    private PersonBuilder AddAction(Action<Person> action)
    //    {
    //        actions.Add(p => {
    //            action(p);
    //            return p;
    //        });

    //        return this;
    //    }
    //}

    public static class PersonBuilderExtensions
    {
        public static PersonBuilder WorksAs(this PersonBuilder builder, string position)
            => builder.Do(p => p.Position = position);

        public static PersonBuilder WithAge(this PersonBuilder builder, int age)
            => builder.Do(p => p.Age = age);
    }
}
