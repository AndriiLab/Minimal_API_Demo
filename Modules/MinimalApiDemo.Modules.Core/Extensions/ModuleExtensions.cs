using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MinimalApiDemo.Modules.Core.Interfaces;

namespace MinimalApiDemo.Modules.Core.Extensions;

public static class ModuleExtensions
{
    private static readonly ICollection<IModule> RegisteredModules = new List<IModule>();

    public static IServiceCollection RegisterModule<TModule>(this IServiceCollection services) where TModule : class, IModule
    {
        // register assembly validators
        services.AddValidatorsFromAssembly(typeof(TModule).Assembly, includeInternalTypes: true);

        // register module repositories decorated with IRepository
        services.Scan(scan => scan
            .FromAssemblyOf<TModule>()
            .AddClasses(classes => classes.AssignableTo<IRepository>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        
        var module = Activator.CreateInstance<TModule>();
        module.RegisterServices(services);
        
        RegisteredModules.Add(module);

        return services;
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        foreach (var module in RegisteredModules)
        {
            module.MapEndpoints(app);
        }
        return app;
    }
}