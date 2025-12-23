using System.Linq.Expressions;

namespace DataModelLibrary.Specifications;

public abstract class BaseSpecification<T> where T : class
{
    // Where clause
    public Expression<Func<T, bool>>? Criteria { get; protected set; }

    // Table Joins
    public List<Expression<Func<T, object>>> Includes { get; } = [];

    protected void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }
}
