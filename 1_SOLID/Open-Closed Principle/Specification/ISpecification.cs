namespace Open_Closed_Principle.Specification
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }
}
