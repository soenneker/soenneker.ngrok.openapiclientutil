using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.ngrok.HttpClients.Registrars;
using Soenneker.ngrok.OpenApiClientUtil.Abstract;

namespace Soenneker.ngrok.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class ngrokOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="ngrokOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddngrokOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddngrokOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IngrokOpenApiClientUtil, ngrokOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="ngrokOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddngrokOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddngrokOpenApiHttpClientAsSingleton()
                .TryAddScoped<IngrokOpenApiClientUtil, ngrokOpenApiClientUtil>();

        return services;
    }
}
