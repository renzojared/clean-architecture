namespace NorthWind.Validation.Entities.Interfaces;

public interface IValidationRules<T, TProperty>
{
    IValidationRules<T, TProperty> NotEmpty(string errorMessage);
    IValidationRules<T, TProperty> NotNull(string errorMessage);
    IValidationRules<T, TProperty> Must(Func<TProperty, bool> predicate, string errorMessage);
    IValidationRules<T, TProperty> StopOnFirstFailure();

    IValidationRules<T, TProperty> GreaterThan<TValue>(TValue valueToCompare, string errorMessage)
        where TValue : TProperty, IComparable<TValue>, IComparable;

    IValidationRules<T, TProperty> Equal(Expression<Func<T, TProperty>> expression, string errorMessage);
    IValidationRules<T, string> Length(int length, string errorMessage);
    IValidationRules<T, string> MaximumLength(int length, string errorMessage);
    IValidationRules<T, string> MinimumLength(int length, string errorMessage);
    IValidationRules<T, string> EmailAddress(string errorMessage);
}
