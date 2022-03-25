using Hurry.Helpers;
using Hurry.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hurry;

public static class Program
{
    private static TestService _testService = null!;

    private static async Task Main()
    {
        var services = new ServiceCollection()
            .AddSingleton(TestService.GetInstance());

        await using var serviceProvider = services.BuildServiceProvider();
        _testService = serviceProvider.GetService<TestService>()!;

        await _testService.Start();
    }
}