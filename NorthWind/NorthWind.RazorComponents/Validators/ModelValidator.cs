namespace NorthWind.RazorComponents.Validators;
public class ModelValidator<T> : ComponentBase
{
    [CascadingParameter]
    EditContext EditContext { get; set; }

    [Parameter]
    public IModelValidatorHub<T> Validator { get; set; }

    ValidationMessageStore ValidationMessageStore;

    FieldIdentifier GetFieldIdentifier(object model, string propertyName)
    {
        char[] PropertyNameSeparators = ['.', '['];
        object NewModel = model;

        string PropertyPath = propertyName;

        int SeparatorIndex;
        string Token = null;

        do
        {
            SeparatorIndex =
                PropertyPath.IndexOfAny(PropertyNameSeparators);

            if (SeparatorIndex >= 0)
            {
                Token = PropertyPath.Substring(0, SeparatorIndex);
                PropertyPath = PropertyPath.Substring(SeparatorIndex + 1);

                if (Token.EndsWith("]"))
                {
                    // "3]"
                    Token = Token.Substring(0, Token.Length - 1);
                    var PropertyInfo =
                        NewModel.GetType().GetProperty("Item");

                    var IndexerType =
                        PropertyInfo.GetIndexParameters()[0]
                        .ParameterType;

                    var IndexValue =
                        Convert.ChangeType(Token, IndexerType);

                    NewModel = PropertyInfo.GetValue(NewModel,
                        new object[] { IndexValue });
                }
                else
                {
                    var PropertyInfo = NewModel.GetType()
                        .GetProperty(Token);
                    NewModel = PropertyInfo.GetValue(NewModel);
                }
                Token = null;
            }
        } while (SeparatorIndex >= 0);

        return new FieldIdentifier(NewModel,
            Token ?? PropertyPath);
    }

    public void AddErrors(IEnumerable<ValidationError> errors)
    {
        ValidationMessageStore.Clear();
        foreach (var Error in errors)
        {
            var FieldIdentifier =
                GetFieldIdentifier(EditContext.Model, Error.PropertyName);
            ValidationMessageStore.Add(FieldIdentifier, Error.Message);
        }
        EditContext.NotifyValidationStateChanged();
    }

    async void ValidationRequested(object sender,
        ValidationRequestedEventArgs args)
    {
        bool IsValid = await Validator.Validate((T)EditContext.Model);
        if (IsValid)
        {
            ValidationMessageStore.Clear();
            EditContext.NotifyValidationStateChanged();
        }
        else
        {
            AddErrors(Validator.Errors);
        }
    }

    async void FieldChanged(object sender, FieldChangedEventArgs args)
    {
        ValidationMessageStore.Clear(args.FieldIdentifier);
        bool IsValid = await Validator.Validate((T)EditContext.Model);
        if (!IsValid)
        {
            foreach (var Error in Validator.Errors)
            {
                var FieldIdentifier =
                    GetFieldIdentifier(EditContext.Model, Error.PropertyName);
                if (FieldIdentifier.FieldName == args.FieldIdentifier.FieldName &&
                    FieldIdentifier.Model == args.FieldIdentifier.Model)
                {
                    ValidationMessageStore.Add(FieldIdentifier, Error.Message);
                }
            }
        }

        EditContext.NotifyValidationStateChanged();
    }

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        EditContext PreviousEditContext = EditContext;
        await base.SetParametersAsync(parameters);

        if (EditContext != PreviousEditContext)
        {
            ValidationMessageStore = new ValidationMessageStore(EditContext);
            EditContext.OnValidationRequested += ValidationRequested;
            EditContext.OnFieldChanged += FieldChanged;
        }
    }
}
