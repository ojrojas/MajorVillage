var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
Log.Logger = CreateSerilogLogger();

var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddDIContextApplication(configuration);

builder.Services.AddQuartz(conf => {
    conf.UseMicrosoftDependencyInjectionJobFactory();
    conf.UseSimpleTypeLoader();
    conf.UseInMemoryStore();
});

builder.Services.AddControllers(options => options.Filters.Add(typeof(HttpExceptionsApplicationFilter)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDIOpenIddictApplication();
builder.Services.AddIdentityServerApplication(configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDISwaggerApplication();

//builder.Services.AddDIOptionsConfiguration(configuration);
builder.Services.AddDIJwtApplication(configuration);
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

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(name: "IdentityCorsPolicy",
    builder => builder.RequireClaim("TypeUser"));
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
    await initializer.RunConfigurationDbContext(_managerApplication,_managerScopes, clientUrls);
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("IdentityCorsPolicy");
app.UseHttpsRedirection();


app.MapControllers();
app.MapHealthChecks("/health").RequireAuthorization();

app.Run();


static Serilog.ILogger CreateSerilogLogger() => new LoggerConfiguration()
        .MinimumLevel.Verbose()
        .Enrich.WithProperty("MajorIdentityServerApplication", typeof(Program).Namespace)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .CreateLogger();