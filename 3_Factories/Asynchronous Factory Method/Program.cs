using System;
using System.Threading.Tasks;

namespace Asynchronous_Factory_Method
{
    class Program
    {
        static async void Main(string[] args)
        {
            Foo x = await Foo.CreateAsync();
        }

        public class Foo
        {
            private Foo()
            {
                //await Task.Delay(1000);
            }

            private async Task<Foo> InitAsync()
            {
                await Task.Delay(1000);
                return this;
            }

            public static Task<Foo> CreateAsync()
            {
                var result = new Foo();
                return result.InitAsync();
            }
        }
    }
}
