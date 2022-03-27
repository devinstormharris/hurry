using Hurry.Helpers;
using Hurry.WpmTest;
using Microsoft.Extensions.DependencyInjection;

namespace Hurry;

public static class Program
{
    private static WpmTestService _wpmTestService = null!;

    private static async Task Main()
    {
        var services = new ServiceCollection()
            .AddSingleton(WpmTestService.GetInstance());

        await using var serviceProvider = services.BuildServiceProvider();
        _wpmTestService = serviceProvider.GetService<WpmTestService>()!;

        await _wpmTestService.Start();
    }
}