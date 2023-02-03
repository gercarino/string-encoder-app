using Microsoft.Extensions.DependencyInjection.Extensions;
using OneInc.API.Interfaces;
using OneInc.API.Services;

namespace OneInc.API;

public static class ServiceCollectionExtensions
{
    public static void AddOneIncServices(this IServiceCollection services)
    {
        services.TryAddScoped<IStringEncoder, Base64Encoder>();
        services.TryAddScoped<IEncodingService, OneIncEncodingService>();
        services.TryAddScoped(typeof(IDelayableCollection<>), typeof(RandomTimeCollectionDelayer<>));
    }
}