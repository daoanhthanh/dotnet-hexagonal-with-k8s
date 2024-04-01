using System.Text.Json.Serialization;
using Adapter.RestfulAPI.Src.Extensions;
using Adapter.RestfulAPI.Src.IoC;
using Domain.Services.AutoMapper;
using Microsoft.AspNetCore.Mvc.Versioning;

using Postgres.Config;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
// builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers()
    .AddJsonOptions(x => { x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull; });

builder.Services.AddCustomizedSwagger(builder.Environment);

// ----- AutoMapper -----
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

// ----- Database Config -----
builder.Services.AddPostgresDatabase(builder.Configuration, builder.Environment.IsProduction());

// ----- Versioning -----
builder.Services.AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.ReportApiVersions = true;
    opt.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("x-api-version"),
        new MediaTypeApiVersionReader("x-api-version"));
});

// Add ApiExplorer to discover versions
builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

builder.Services.AddEndpointsApiExplorer();


DependenciesInjector.RegisterServices(builder.Services);


var app = builder.Build();

app.UseCustomizedSwagger(builder.Environment);

app.UseRouting();

#pragma warning disable ASP0014
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
#pragma warning restore ASP0014

// app.UseHttpsRedirection();


app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }