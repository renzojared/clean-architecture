using NorthWind.Exceptions.Entities.Exceptions;

namespace NorthWind.Sales.Backend.BusinessObjects.Guards;

public static class GuardModel
{
    public static async Task AgainstNotValid<T>(IModelValidatorHub<T> modelValidatorHub, T model)
    {
        if (!await modelValidatorHub.Validate(model))
            throw new ValidationException(modelValidatorHub.Errors);
    }
}
