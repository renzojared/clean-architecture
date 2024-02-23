namespace NorthWind.Validation.Entities.Interfaces;

public interface IModelValidatorHub<T>
{
    Task<bool> Validate(T model);
    IEnumerable<ValidationError> Errors { get; }
}