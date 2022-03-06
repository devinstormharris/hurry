using Hurry.Utilities.Services;
using Hurry.Utilities.Services.Interfaces;

namespace Hurry.Console.Helpers;

public static class TestHelper
{
    private static string _input;

    public static async Task RunTest(this ITestService testService)
    {
        await ConsoleHelper.StartCountdown();

        testService.WritePrompt();

        var cts = new CancellationTokenSource();
        var token = cts.Token;

        var taskStart = testService.StartTimer(token);
        var input = new List<string>();
        try
        {
            while (!taskStart.IsCompleted)
            {
                input.Add(System.Console.ReadLine()!);

                if (input.Last().ToLower() == "quit")
                {
                    cts.Cancel();
                    break;
                }
            }

            foreach (var i in input) _input += i;
            await taskStart.WaitAsync(token);
        }
        catch (OperationCanceledException)
        {
            System.Console.WriteLine("Ending test.");
        }
        catch (Exception exception)
        {
            System.Console.WriteLine($"Error: {exception.Message}");
        }

        testService.CalculateWpm(_input);

        testService.WriteResults();
    }
}