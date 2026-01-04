using Microsoft.Extensions.DependencyInjection;
using Pouya.Satep;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSatepServices(this IServiceCollection services)
    {
        services.AddHttpClient<AuthorizationService>((sp, client) =>
        {
            client.Timeout = TimeSpan.FromSeconds(30);
        });
        return services;
    }
}