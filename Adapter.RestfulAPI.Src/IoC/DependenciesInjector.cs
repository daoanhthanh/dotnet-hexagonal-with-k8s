using Domain.Core.Interfaces;
using Domain.Core.User;
using Domain.Services.User;
using In.User;
using Postgres.Base;
using Postgres.User;

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