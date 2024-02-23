namespace NorthWind.Validation.Entities.ValueObjects;

public class ValidationError(string propertyName, string message)
{
    public string PropertyName => propertyName;
    public string Message => message;
}