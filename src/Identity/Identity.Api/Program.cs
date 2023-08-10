var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
var configuration = builder.Configuration;

Log.Logger = CreateSerilogLogger();
// Add services to the container.
builder.Services.AddDIContextApplication(configuration);

builder.Services.AddQuartz(conf =>
{
    conf.UseMicrosoftDependencyInjectionJobFactory();
    conf.UseSimpleTypeLoader();
    conf.UseInMemoryStore();
});

builder.Services.AddControllersWithViews(options => options.Filters.Add(typeof(HttpExceptionsApplicationFilter)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDIOpenIddictApplication(configuration);
builder.Services.AddIdentityServerApplication();

builder.Services.AddDISwaggerApplication(configuration);

builder.Services.AddDIJwtApplication();
builder.Services.AddOptionsExtensions(configuration);
builder.Services.AddDIServicesApplication();
builder.Services.AddHealthChecks();

var urls = configuration["UrlsAllow"];
ArgumentNullException.ThrowIfNull(urls);
var clientUrls = TransformString.TransformStringtoDictionary(urls);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "IdentityCorsPolicy",
    builder => builder.WithOrigins(clientUrls.Values.ToArray()).AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddMemoryCache();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var service = scope.ServiceProvider;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    var initializer = service.GetRequiredService<InitializerDbContext>();
    var context = service.GetRequiredService<IdentityAppDbContext>();
    var _managerApplication = service.GetRequiredService<IOpenIddictApplicationManager>();
    var _managerScopes = service.GetRequiredService<IOpenIddictScopeManager>();

    await initializer.Run();

    var applied = context.Database.GetAppliedMigrations();
    await initializer.RunConfigurationDbContext(_managerApplication, _managerScopes, clientUrls);

    app.UseSwagger();
    app.UseSwaggerUI(
        options =>
        {
            options.DisplayOperationId();
            options.EnablePersistAuthorization();
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity api v1");
            options.OAuthClientId("identityswaggerui");
            options.OAuthClientSecret("a961a072-4a69-4b10-bc17-1551d454d44c");
        });
}

if(app.Environment.EnvironmentName.Equals("Testing"))
{
    var initializer = service.GetRequiredService<InitializerDbContext>();
    var context = service.GetRequiredService<IdentityAppDbContext>();
    var _managerApplication = service.GetRequiredService<IOpenIddictApplicationManager>();

    await initializer.Run();

    await initializer.RunConfigurationDbContextTesting(_managerApplication);
}

app.UseCors("IdentityCorsPolicy");
app.UseHttpsRedirection();

app.AddDIConfigurationApplication();

app.MapHealthChecks("/health").RequireAuthorization();

app.Run();


static Serilog.ILogger CreateSerilogLogger() => new LoggerConfiguration()
        .MinimumLevel.Verbose()
        .Enrich.WithProperty("MajorIdentityServerApplication", typeof(Program).Namespace)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .CreateLogger();

public partial class Program { }