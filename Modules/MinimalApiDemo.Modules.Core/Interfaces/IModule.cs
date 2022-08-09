using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace MinimalApiDemo.Modules.Core.Interfaces;

public interface IModule
{
    IServiceCollection RegisterServices(IServiceCollection builder);
    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}