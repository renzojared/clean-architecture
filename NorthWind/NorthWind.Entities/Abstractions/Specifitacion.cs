using System.Linq.Expressions;

namespace NorthWind.Entities.Abstractions;

public abstract class Specifitacion<T>
{
    public abstract Expression<Func<T, bool>> ConditionExpression { get; }

    public bool IsSatisfiedBy(T entity)
    {
        var expressionDelegate = ConditionExpression.Compile();
        return expressionDelegate(entity);
    }
}