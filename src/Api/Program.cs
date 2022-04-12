using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

// CreateLogger Application
Log.Logger = CreateSerilogLogger();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenDocumention();

builder.Services.AddServicesDIApp();

var configuration = builder.Configuration;

builder.Services.AddDIOptionsConfiguration(configuration);
builder.Services.AddJwtExtension(configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MajorVillagePolicy", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

// //Asynchronous - Dialect don´t work
// DapperExtensions.DapperAsyncExtensions.SqlDialect = new DapperExtensions.Sql.MySqlDialect();
// //Synchronous
DapperExtensions.DapperExtensions.SqlDialect = new DapperExtensions.Sql.MySqlDialect();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


Serilog.ILogger CreateSerilogLogger() => new LoggerConfiguration()
        .MinimumLevel.Verbose()
        .Enrich.WithProperty("ApplicationContext", typeof(Program).Namespace)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File("logmajorvillage.txt",
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
        .CreateLogger();