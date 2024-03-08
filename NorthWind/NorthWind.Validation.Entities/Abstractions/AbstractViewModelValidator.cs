namespace NorthWind.Validation.Entities.Abstractions;

public abstract class AbstractViewModelValidator<DtoType, ViewModelType>(
    IModelValidatorHub<DtoType> dtoModelValidatorHub,
    ValidationConstraint constraint) : IModelValidator<ViewModelType>
{
    public ValidationConstraint Constraint => constraint;

    public IEnumerable<ValidationError> Errors => dtoModelValidatorHub.Errors;

    public virtual DtoType Cast(ViewModelType viewModel)
    {
        DtoType dtoModel = default;

        var explicitMethod = typeof(ViewModelType).GetMethod("op_Explicit");
        if (explicitMethod != null)
            dtoModel = (DtoType)explicitMethod.Invoke(viewModel, new object[] { viewModel });
        else
            throw new InvalidCastException();
        
        return dtoModel;
    }

    public Task<bool> Validate(ViewModelType model)
        => dtoModelValidatorHub.Validate(Cast(model));
}