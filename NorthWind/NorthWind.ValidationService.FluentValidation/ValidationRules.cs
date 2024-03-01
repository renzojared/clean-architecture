namespace NorthWind.ValidationService.FluentValidation;

internal class ValidationRules<T,TProperty>(
    IRuleBuilderInitial<T, TProperty> ruleBuilderInitial) : IValidationRules<T, TProperty>
{
    private IRuleBuilder<T, string> stringRuleBuilder
        => (IRuleBuilder<T, string>)ruleBuilderInitial;

    private IValidationRules<T, string> thisAsStringValidationRules
        => (IValidationRules<T, string>)this;

    public IValidationRules<T, TProperty> NotEmpty(string errorMessage)
    {
        ruleBuilderInitial
            .NotEmpty()
            .WithMessage(errorMessage);
        return this;
    }

    public IValidationRules<T, TProperty> NotNull(string errorMessage)
    {
        ruleBuilderInitial
            .NotNull()
            .WithMessage(errorMessage);
        return this;
    }

    public IValidationRules<T, TProperty> Must(Func<TProperty, bool> predicate, string errorMessage)
    {
        ruleBuilderInitial
            .Must(predicate)
            .WithMessage(errorMessage);
        return this;
    }

    public IValidationRules<T, TProperty> StopOnFirstFailure()
    {
        ruleBuilderInitial
            .Cascade(CascadeMode.Stop);
        return this;
    }

    public IValidationRules<T, TProperty> GreaterThan<TValue>(TValue valueToCompare, string errorMessage) where TValue : TProperty, IComparable<TValue>, IComparable
    {
        var builder = (IRuleBuilder<T, TValue>)ruleBuilderInitial;
        builder
            .GreaterThan(valueToCompare)
            .WithMessage(errorMessage);
        return this;
    }

    public IValidationRules<T, TProperty> Equal(Expression<Func<T, TProperty>> expression, string errorMessage)
    {
        ruleBuilderInitial
            .Equal(expression)
            .WithMessage(errorMessage);
        return this;
    }

    public IValidationRules<T, string> Length(int length, string errorMessage)
    {
        stringRuleBuilder
            .Length(length)
            .WithMessage(errorMessage);
        return thisAsStringValidationRules;
    }

    public IValidationRules<T, string> MaximumLength(int length, string errorMessage)
    {
        stringRuleBuilder
            .MaximumLength(length)
            .WithMessage(errorMessage);
        return thisAsStringValidationRules;
    }

    public IValidationRules<T, string> MinimumLength(int length, string errorMessage)
    {
        stringRuleBuilder
            .MinimumLength(length)
            .WithMessage(errorMessage);
        return thisAsStringValidationRules;
    }

    public IValidationRules<T, string> EmailAddress(string errorMessage)
    {
        stringRuleBuilder
            .EmailAddress()
            .WithMessage(errorMessage);
        return thisAsStringValidationRules;
    }
}