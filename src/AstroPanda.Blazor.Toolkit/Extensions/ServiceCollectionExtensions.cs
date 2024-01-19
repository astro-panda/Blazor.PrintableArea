using BlazorComponentBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MudBlazor.Services;

namespace AstroPanda.Blazor.Toolkit;
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the services from the Blazor Toolkit
    /// DOM
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddBlazorToolkit(this IServiceCollection services)
    {
        services.TryAddSingleton<IPrintService, PrintService>();
        services.TryAddSingleton<IDownloadService, DownloadService>();

        services.AddScoped<IComponentBus, ComponentBus>();
        services.AddScoped(sp => sp.GetRequiredService<IComponentBus>() as ComponentBus ?? new ComponentBus());

        services.AddHttpClient();
        services.AddMudServices();
        return services;
    }

}
