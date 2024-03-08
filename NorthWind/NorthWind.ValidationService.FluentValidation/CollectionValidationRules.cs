using NorthWind.Validation.Entities.Abstractions;

namespace NorthWind.ValidationService.FluentValidation;

internal class CollectionValidationRules<T, TProperty>(
    IRuleBuilderInitialCollection<T, TProperty> ruleBuilderInitialCollection) : ICollectionValidationRules<T, TProperty>
{
    public ICollectionValidationRules<T, TProperty> SetValidator(IModelValidator<TProperty> validator)
    {
        var modelValidator = validator as AbstractModelValidator<TProperty>;
        var validationService = modelValidator.ValidatorService as FluentValidationService<TProperty>;
        ruleBuilderInitialCollection
            .SetValidator(validationService.Wrapper);
        return this;
    }
}