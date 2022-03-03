using Hurry.Console.Helpers;
using Hurry.Utilities.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hurry.Console;

public static class Program
{
    private static ITestService? _testService;

    static async Task Main(string[] args)
    {
        var services = new ServiceCollection()
            .AddSingleton<ITestService>(new TestService(new TimerService(), new PromptService(), new ResultsService()));

        using var serviceProvider = services.BuildServiceProvider();
        _testService = serviceProvider.GetService<ITestService>()!;

        _testService.Greet();
        await _testService.RunTest();
    }
}