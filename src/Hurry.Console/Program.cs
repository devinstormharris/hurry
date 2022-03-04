using Hurry.Console.Helpers;
using Hurry.Utilities.Services;
using Hurry.Utilities.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Hurry.Console;

public static class Program
{
    private static ITestService? _testService;

    private static async Task Main()
    {
        var services = new ServiceCollection()
            .AddSingleton<ITestService>(new TestService(new TimerService(), new PromptService(), new ResultsService()));

        await using var serviceProvider = services.BuildServiceProvider();
        _testService = serviceProvider.GetService<ITestService>()!;

        _testService.Greet();
        await _testService.RunTest();
    }
}