using Open_Closed_Principle.Models;

namespace Open_Closed_Principle.Specification
{
    public class SizeSpecification : ISpecification<Product>
    {
        private Size _size;

        public SizeSpecification(Size size)
        {
            _size = size;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Size == _size;
        }
    }
}
