using NorthWind.Validation.Entities.Interfaces;

namespace NorthWind.Validation.Entities.Services;

public class ModelValidatorHub<ModelType>(IEnumerable<IModelValidator<ModelType>> validators) : IModelValidatorHub<ModelType>
{
    public async Task<bool> Validate(ModelType model)
    {
        List<ValidationError> CurrentErrors = [];
        var doValidators = validators
            .Where(s => s.Constraint == ValidationConstraint.AlwaysValidate)
            .ToList();
        
        doValidators.AddRange(validators.Where(s =>
            s.Constraint == ValidationConstraint.ValidateIfThereAreNoPreviousErrors));

        foreach (var validator in doValidators)
        {
            if(validator.Constraint == ValidationConstraint.AlwaysValidate || !CurrentErrors.Any())
                if (!await validator.Validate(model))
                    CurrentErrors.AddRange(validator.Errors);
        }

        Errors = CurrentErrors;
        return !Errors.Any();
    }

    public IEnumerable<ValidationError> Errors { get; private set; }
}