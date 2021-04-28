using Open_Closed_Principle.Filters;
using Open_Closed_Principle.Models;
using Open_Closed_Principle.Specification;
using System;

namespace Open_Closed_Principle
{
    // Takie podejście łamie zasadę
    //public class ProductFilter
    //{
    //    public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
    //    {
    //        foreach (var p in products)
    //        {
    //            if (p.Size == size)
    //                yield return p;
    //        }
    //    }

    //    public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
    //    {
    //        foreach (var p in products)
    //        {
    //            if (p.Color == color)
    //                yield return p;
    //        }
    //    }
    //}

    internal static class Program
    {
        static void Main(string[] args)
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);


            var flower = new Product("Flower", Color.Pink, Size.Medium);
            var picture = new Product("Picture", Color.Yellow, Size.Small);
            var baby = new Product("Baby", Color.Pink, Size.Medium);

            Product[] products = { apple, tree, house, flower, picture, baby };

            //var pf = new ProductFilter();
            //Console.WriteLine("Green products (old):");
            //foreach (var p in pf.FilterByColor(products, Color.Green))
            //{
            //    Console.WriteLine($" - {p.Name} is green");
            //}

            var pf = new ProductFilter();
            Console.WriteLine("Green products (new):");
            foreach (var p in pf.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($" - {p.Name} is green");
            }

            Console.WriteLine("Large blue items:");
            foreach (var p in pf.Filter(products, new AddSpecification<Product>(new ColorSpecification(Color.Blue), new SizeSpecification(Size.Large))))
            {
                Console.WriteLine($" - {p.Name} is big and blue");
            }

            // MODYFICATION
            // Add new pink color
            // Add new products
            // Filter by pink and medium

            Console.WriteLine("Pink and medium:");
            foreach (var p in pf.Filter(products, new AddSpecification<Product>(new ColorSpecification(Color.Pink), new SizeSpecification(Size.Medium))))
            {
                Console.WriteLine($" - {p.Name} is pink and medium");
            }
        }
    }
}
