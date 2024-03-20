namespace NorthWind.HttpDelegatingHandlers;

public class ExceptionDelegatingHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = await response.Content.ReadAsStringAsync();
            string source = null;
            string message = null;

            IEnumerable<ValidationError> errors = null;
            var isValidProblemDetails = false;

            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.Forbidden:
                    errorMessage = $"{(int)response.StatusCode} {response.ReasonPhrase}";
                    break;
                default:
                    try
                    {
                        var contentType = response.Content.Headers.ContentType.MediaType;
                        var jsonResponse = JsonSerializer.Deserialize<JsonElement>(errorMessage);

                        if (contentType == "application/problem+json" &&
                            TryGetProperty(jsonResponse, "instance", out JsonElement instanceValue))
                        {
                            var value = instanceValue.ToString();
                            if (value.ToLower().StartsWith("problemdetails/"))
                            {
                                source = value;
                                if (TryGetProperty(jsonResponse, "title", out var titleValue))
                                    message = titleValue.ToString();
                                if (TryGetProperty(jsonResponse, "detail", out var detailValue))
                                    message = $"{message} {detailValue}".Trim();
                                if (TryGetProperty(jsonResponse, "errors", out JsonElement errorsValue))
                                    errors = errorsValue.Deserialize<IEnumerable<ValidationError>>(
                                        new JsonSerializerOptions
                                        {
                                            PropertyNameCaseInsensitive = true,
                                        });
                                isValidProblemDetails = true;
                            }
                        }
                    }
                    catch { }
                    break;
            }

            if (!isValidProblemDetails)
            {
                message = errorMessage;
                source = null;
                errors = null;
            }

            var ex = new HttpRequestException(message, null, response.StatusCode);
            ex.Source = source;
            if (errors != null)
                ex.Data.Add("Errors", errors);
            throw ex;
        }

        return response;
    }

    bool TryGetProperty(JsonElement element, string propertyName, out JsonElement value)
    {
        var found = false;
        value = default;
        var property = element.EnumerateObject()
            .FirstOrDefault(s => string.Compare(s.Name, propertyName, StringComparison.OrdinalIgnoreCase) == 0);

        if (property.Value.ValueKind != JsonValueKind.Undefined)
        {
            value = property.Value;
            found = true;
        }

        return found;
    }
}