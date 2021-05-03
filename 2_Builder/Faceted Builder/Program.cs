using Faceted_Builder.Builders;
using Faceted_Builder.Models;
using System;

namespace Faceted_Builder
{
    static class Program
    {
        private static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            var pb = new PersonBuilder();

            Person person = pb
                .Works
                    .At("Google")
                    .AsA("Developer")
                    .Earning(15000)
                .Lives
                    .At("21 street")
                    .In("NY")
                    .WithPostcode("xxxxx");

            Console.WriteLine(person.ToString());
        }       
    }
}
