namespace MajorVillage.Api.Intraestructure;

public class ExceptionApplication : Exception
{
    public ExceptionApplication() { }

    public ExceptionApplication(string message ) :base(message) { }

    public ExceptionApplication (string message, Exception exception) : base(message, exception) { }
}