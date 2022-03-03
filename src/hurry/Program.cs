using hurry.Services;
using Microsoft.Extensions.DependencyInjection;

namespace hurry;

public static class Program
{
    private static async Task Main(string[] args)
    {
        var services = new ServiceCollection()
            .AddSingleton<ITestService>(new TestService( new TimerService(), new PromptService(), new ResultsService()));

        using var serviceProvider = services.BuildServiceProvider();
        ITestService testService = serviceProvider.GetService<ITestService>()!;

        ConsoleHelper.Greet();
        await ConsoleHelper.StartCountdown();
        
        var wpm = RunTest(testService).Result;
        Console.WriteLine($"You're WPM is {wpm}.");
    }

    static async Task<int> RunTest(ITestService testService)
    {
        var cts = new CancellationTokenSource();
        var token = cts.Token;

        var prompt = testService.GetPrompt();
        Console.WriteLine(prompt);

        var taskStart = testService.Start(token);
        var tmpInput = new List<string>();
        var input = "";
        try
        {
            while (!taskStart.IsCompleted)
            {
                tmpInput.Add(Console.ReadLine()!);

                if (tmpInput.Last().ToLower() == "quit")
                {
                    cts.Cancel();
                    break;
                }
            }

            foreach (var i in tmpInput) input += i;
            await taskStart.WaitAsync(token);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Goodbye!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }

        testService.Stop(input);
        var results = testService.GetResults();

        return results!.Wpm;
    }
}