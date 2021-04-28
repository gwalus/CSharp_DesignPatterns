using Open_Closed_Principle.Models;
using Open_Closed_Principle.Specification;
using System.Collections.Generic;

namespace Open_Closed_Principle.Filters
{
    public class ProductFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var i in items)
            {
                if (spec.IsSatisfied(i))
                    yield return i;
            }
        }
    }
}
