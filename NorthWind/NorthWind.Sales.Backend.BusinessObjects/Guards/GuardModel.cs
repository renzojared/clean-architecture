namespace NorthWind.Sales.Backend.BusinessObjects.Guards;

public static class GuardModel
{
    public static async Task AgainstNotValid<T>(IModelValidatorHub<T> modelValidatorHub, T model)
    {
        if (!await modelValidatorHub.Validate(model))
        {
            var errors = string
                .Join(" ", modelValidatorHub.Errors
                    .Select(s => $"{s.PropertyName}: {s.Message}"));
            throw new Exception(errors);
        }
    }
}