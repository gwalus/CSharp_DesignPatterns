using System;
using System.Collections.Generic;
using System.Linq;

namespace Dependency_Inversion_Principle
{
    public class Program
    {
        //public Program(Relationships relationships)
        //{
        //    var relations = relationships.Relations;

        //    foreach (var r in relations.Where(x => x.Item1.Name == "John" && x.Item2 == Relationship.Parent))
        //    {
        //        Console.WriteLine($"John has a child called {r.Item3.Name}");
        //    }
        //}

        public Program(IRelationshipBrowser browser)
        {
            foreach (var p in browser.FindAllChildrenOf("John"))
            {
                Console.WriteLine($"John has a child called {p.Name}");
            }
        }

        public static void Main(string[] args)
        {
            var parent = new Person{ Name = "John"};
            var child1 = new Person{ Name = "Chris"};
            var child2 = new Person{ Name = "Mary"};

            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);
        }
    }

    public class Person
    {
        public string Name { get; set; }
    }

    public enum Relationship
    {
        Parent, Child, Sibling
    }

    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    public class Relationships : IRelationshipBrowser
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            foreach (var r in relations.Where(x => x.Item1.Name == "John" && x.Item2 == Relationship.Parent))
            {
                //Console.WriteLine($"John has a child called {r.Item3.Name}");

                yield return r.Item3;
            }
        }

        //public List<(Person, Relationship, Person)> Relations => relations;
    }
}
