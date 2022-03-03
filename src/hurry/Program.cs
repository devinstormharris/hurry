using hurry.Services;
using Microsoft.Extensions.DependencyInjection;

namespace hurry;

public static class Program
{
    static async Task Main(string[] args)
    {
        var services = new ServiceCollection()
            .AddSingleton<ITestService>(new TestService(new TimerService(), new PromptService(), new ResultsService()));

        await using var serviceProvider = services.BuildServiceProvider();
        var testService = serviceProvider.GetService<ITestService>()!;

        ConsoleHelper.Greet();
        await ConsoleHelper.StartCountdown();

        var wpm = RunTest(testService);
        Console.WriteLine($"You're WPM is {wpm}.");
    }

    static int RunTest(ITestService testService)
    {
        WritePrompt(testService);

        var input = StartTest(testService).Result;
        testService.Stop(input);

        var results = testService.GetResults();
        return results!.Wpm;
    }

    static void WritePrompt(ITestService testService)
    {
        var prompt = testService.GetPrompt();
        Console.WriteLine(prompt);
    }

    static async Task<string> StartTest(ITestService testService)
    {
        var cts = new CancellationTokenSource();
        var token = cts.Token;

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

            return input;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Goodbye!");
            return input;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
            return null;
        }
    }
}