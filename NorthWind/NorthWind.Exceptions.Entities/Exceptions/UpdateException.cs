namespace NorthWind.Exceptions.Entities.Exceptions;

public class UpdateException : Exception
{
    public UpdateException()
    {
    }

    public UpdateException(string message) : base(message)
    {
    }

    public UpdateException(string message, Exception innerException) : base(message, innerException)
    {
    }
    public IEnumerable<string> Entities { get; set; }

    public UpdateException(Exception exception, IEnumerable<string> entities) : base(exception.Message, exception)
        => Entities = entities;
}