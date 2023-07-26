namespace School.Api.DI;

public static class DICorsAndAuthenticationAuthorization
{
    public static IServiceCollection AddDICorsAndAuthenticationAuthorization(this IServiceCollection services, IConfiguration configuration)
    {
        //IList<string> urlsAllowed = new List<string>();
        //var appsurls = configuration.GetSection("Apps").GetChildren();

        //foreach (var url in appsurls)
        //    urlsAllowed.Add(url.Value);

        //services.AddCors(options =>
        //{
        //    options.AddPolicy(name: "SchoolCorsPolicy",
        //    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        //});

        //services.AddAuthorization(options =>
        //{
        //    options.AddPolicy(name: "SchoolCorsPolicy",
        //    builder => builder.RequireClaim("TypeUser"));
        //});

        return services;
    }
}

