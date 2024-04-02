using System.Text.Json.Serialization;
using Adapter.Database.Postgres.Config;
using Adapter.RestfulAPI.Src.Extensions;
using Adapter.RestfulAPI.Src.IoC;
using Application.Services.AutoMapper;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Adapter.RestfulAPI.Src;

public class Startup
{
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _env;


    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        _configuration = configuration;
        _env = env;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMemoryCache();

        services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

        services.AddControllers()
            .AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

        // ----- AutoMapper -----
        services.AddAutoMapper(typeof(AutoMapperConfig));

        services.AddPostgresDatabase(_configuration, _env.IsProduction());

        // ----- Register dependencies for services -----
        DependenciesInjector.RegisterServices(services);

        if (_env.IsDevelopment() || _env.IsEnvironment("Local"))
        {
            services.AddCustomizedSwagger();
        }

        // ----- Versioning -----
        services.AddApiVersioning(opt =>
        {
            opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            opt.AssumeDefaultVersionWhenUnspecified = true;
            opt.ReportApiVersions = true;
            opt.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("x-api-version"),
                new MediaTypeApiVersionReader("x-api-version"));
        });

        // ----- Add ApiExplorer to discover versions -----
        services.AddVersionedApiExplorer(setup =>
        {
            setup.GroupNameFormat = "'v'VVV";
            setup.SubstituteApiVersionInUrl = true;
        });

        services.AddEndpointsApiExplorer();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsEnvironment("Local") || env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();

            app.UseCustomizedSwagger();
        }

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}