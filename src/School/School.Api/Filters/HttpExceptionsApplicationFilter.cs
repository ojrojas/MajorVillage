namespace School.Api.Filters;

public class HttpExceptionsApplicationFilter : IExceptionFilter
{
    private readonly ILogger<HttpExceptionsApplicationFilter> _logger;
    private readonly IWebHostEnvironment _env;

    public HttpExceptionsApplicationFilter(ILogger<HttpExceptionsApplicationFilter> logger, IWebHostEnvironment env)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _env = env ?? throw new ArgumentNullException(nameof(env));
    }

    public void OnException(ExceptionContext context)
    {
        _logger.LogError(new EventId(context.Exception.HResult), context.Exception, context.Exception.Message);
        if (context.Exception.GetType() == typeof(Exceptions.ApplicationException))
        {
            var problemDetails = new ValidationProblemDetails()
            {
                Instance = context.HttpContext.Request.Path,
                Status = StatusCodes.Status400BadRequest,
                Detail = "Errors refer to the errores property details"
            };

            problemDetails.Errors.Add("ApplicationValidation", new string[]
            {
                context.Exception.Message.ToString()
            });

            context.Result = new BadRequestObjectResult(problemDetails);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        else
        {
            var errorDetails = new ErrorDetails
            {
                Messages = new[] { "Error refer to the errores details" }
            };

            if (_env.IsDevelopment())
            {
                errorDetails.MessagesEnvDeveloper = context.Exception;
            }

            context.Result = new ObjectResult(errorDetails);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }

        context.ExceptionHandled = true;
    }
}

public class ErrorDetails
{
    public string[]? Messages { get; set; }
    public object? MessagesEnvDeveloper { get; set; }
}
