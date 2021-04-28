namespace Open_Closed_Principle.Specification
{
    public class AddSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> first, second;

        public AddSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first;
            this.second = second;
        }

        public bool IsSatisfied(T t)
        {
            return first.IsSatisfied(t) && second.IsSatisfied(t);
        }
    }
}
