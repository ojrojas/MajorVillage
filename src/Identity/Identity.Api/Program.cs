using System.Reflection;
using Identity.Core.Entities;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
Log.Logger = CreateSerilogLogger();

var migrationsAssembly = typeof(IStartup).GetTypeInfo().Assembly.GetName().Name;

var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(typeof(HttpExceptionsApplicationFilter)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<IdentityAppDbContext>(
    c => c.UseSqlite(builder.Configuration.GetConnectionString("ConnectionSqlite"))
);

builder.Services.AddIdentity<UserApplication, IdentityRole>()
    .AddEntityFrameworkStores<IdentityAppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityServer(x => { })
    .AddAspNetIdentity<UserApplication>()
    .AddConfigurationStore(op =>
    {
        op.ConfigureDbContext = builder => builder.UseSqlite("ConnectionSqlite",
                    sqliteOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(migrationsAssembly);
                    });
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenDocumention();

//builder.Services.AddDIOptionsConfiguration(configuration);
builder.Services.AddJwtExtension(configuration);
builder.Services.AddOptionsExtensions(configuration);
builder.Services.AddServicesDIApp();
builder.Services.AddHealthChecks();

IList<string> urlsAllowed = new List<string>();
var appsurls = configuration.GetSection("Apps").GetChildren();
foreach (var url in appsurls)
    urlsAllowed.Add(url.Value);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "IdentityCorsPolicy",
    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
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
    await initializer.Run();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("IdentityCorsPolicy");
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
        .WriteTo.File("identitylogger.txt",
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
        .CreateLogger();