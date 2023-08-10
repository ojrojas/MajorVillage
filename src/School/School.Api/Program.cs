var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
Log.Logger = CreateSerilogLogger();

var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddDIDbContextApplication(configuration);
builder.Services.AddDIAuthenticationAndAuthorizationApplication();
builder.Services.AddServicesDIApplication();
builder.Services.AddHealthChecks();

builder.Services.AddMemoryCache();

builder.WebHost.ConfigureKestrel(options =>
{
    // Setup a HTTP/2 endpoint without TLS.
    var port = configuration.GetValue("GRPC_PORT", 5290);
    options.Listen(IPAddress.Any, port, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http2;
    });
});

builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();
builder.Services.AddProblemDetails();

builder.Services.AddCors(setup => {
    setup.AddPolicy("SchoolCorsPolicy", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapGrpcReflectionService();
}

//app.UseCors("SchoolCorsPolicy");
//app.UseHttpsRedirection();
//app.UseAuthentication();
//app.UseAuthorization();

// app.MapHealthChecks("/health").RequireAuthorization();
app.MapGrpcService<AreaGrpc>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();

static Serilog.ILogger CreateSerilogLogger() => new LoggerConfiguration()
        .MinimumLevel.Verbose()
        .Enrich.WithProperty("ApplicationContext", typeof(Program).Namespace)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .CreateLogger();