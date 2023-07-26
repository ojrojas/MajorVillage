var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
Log.Logger = CreateSerilogLogger();

var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(typeof(HttpExceptionsApplicationFilter)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDIDbContextApplication(configuration);

builder.Services.AddDISwaggerApplication(configuration);

//builder.Services.AddDIOptionsConfiguration(configuration);
builder.Services.AddDIJwtApplication(configuration);
builder.Services.AddServicesDIApplication();
builder.Services.AddHealthChecks();

builder.Services.AddDICorsAndAuthenticationAuthorization(configuration);

builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.OAuthClientId("schoolclientswaggerui");
        options.OAuthAppName("Swagger UI School");
    });
}

app.UseCors("SchoolCorsPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health").RequireAuthorization();

app.Run();

static Serilog.ILogger CreateSerilogLogger() => new LoggerConfiguration()
        .MinimumLevel.Verbose()
        .Enrich.WithProperty("ApplicationContext", typeof(Program).Namespace)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .CreateLogger();