namespace School.Api.Exceptions;

public class CreditApplicationException : Exception
{
    public CreditApplicationException()
    {
    }

    public CreditApplicationException(string? message) : base(message)
    {
    }

    public CreditApplicationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected CreditApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
