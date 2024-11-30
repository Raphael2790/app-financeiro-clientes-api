using AppFinanceiro.AgioBank.Application.UseCases.Cliente.Inativar;
using AppFinanceiro.AgioBank.Utils.Notifications;
using AppFinanceiro.AgioBank.Utils.Notifications.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AppFinanceiro.AgioBank.Ioc;

public static class BootStraper
{
    public static void ConfigureDependencies(this IServiceCollection services)
    {
        services.ConfigureMediatR()
            .ConfigureRepositories()
            .ConfigureDomainServices()
            .ConfigureNotification();
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
    
    public static IServiceCollection ConfigureNotification(this IServiceCollection services)
    {
        services.AddScoped<INotificationContext, NotificationContext>();
        return services;
    }
}