using Application.Domain.Core.Interfaces;
using Application.Domain.Core.User;
using Application.Services.User;
using Application.Ports.In.User;
using Adapter.Database.Postgres.Base;
using Adapter.Database.Postgres.User;

namespace Adapter.RestfulAPI.Src.IoC;

public static class DependenciesInjector
{
    public static void RegisterServices(IServiceCollection services)
    {
        // ASP.NET HttpContext dependency
        services.AddHttpContextAccessor();

        // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        // Port services
        services.AddScoped<GetAllUser, GetAllUserService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
    }
}