using AppFinanceiro.AgioBank.Application.UseCases.Cliente.Inativar;
using Microsoft.Extensions.DependencyInjection;

namespace AppFinanceiro.AgioBank.Ioc;

public static class BootStraper
{
    public static void ConfigureDependencies(this IServiceCollection services)
    {
        services.ConfigureMediatR()
            .ConfigureRepositories()
            .ConfigureDomainServices();
    }
    
    public static IServiceCollection ConfigureMediatR(this IServiceCollection services)
    {
        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssemblies(typeof(InativarCliente).Assembly);
        });
        
        return services;
    }
    
    public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
    {
        return services;
    }
    
    public static IServiceCollection ConfigureDomainServices(this IServiceCollection services)
    {
        return services;
    }
}