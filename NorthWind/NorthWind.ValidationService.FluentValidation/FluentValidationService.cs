using System.Linq.Expressions;
using NorthWind.Validation.Entities.Interfaces;
using NorthWind.Validation.Entities.ValueObjects;

namespace NorthWind.ValidationService.FluentValidation;

public class FluentValidationService<T> : IValidationService<T>
{
    //TODO: Implement
    public IValidationRules<T, TProperty> AddRuleFor<TProperty>(Expression<Func<T, TProperty>> expression)
    {
        throw new NotImplementedException();
    }

    public ICollectionValidationRules<T, TProperty> AddRuleForEach<TProperty>(Expression<Func<T, IEnumerable<TProperty>>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ValidationError>> Validate(T model)
    {
        throw new NotImplementedException();
    }
}