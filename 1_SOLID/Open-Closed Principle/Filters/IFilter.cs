using Open_Closed_Principle.Specification;
using System.Collections.Generic;

namespace Open_Closed_Principle.Filters
{
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }
}
