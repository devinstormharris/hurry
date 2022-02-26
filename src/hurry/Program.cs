using hurry.Services;

namespace hurry;

public static class Program
{
    private static readonly TestService _testService =
        new(new TimerService(), new PromptService(), new ResultsService());

    private static async Task Main()
    {
        var cts = new CancellationTokenSource();
        var token = cts.Token;

        Console.WriteLine("Welcome to hurry, a typing test where you want to hurry.");
        Console.WriteLine("You will be given one minute to type out the prompt that you will see");
        Console.WriteLine("If you want to end the program early, you can type 'quit'");
        await StartCountdown();

        var prompt = _testService.GetPrompt();
        Console.WriteLine(prompt);

        Task taskStart = _testService.Start(token);
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

            foreach (var i in input)
            {
                input = input + i;
            }
            Console.WriteLine(input);
            
        }
        catch (OperationCanceledException e)
        {
            // swallow
        }

        try
        {
            await taskStart.WaitAsync(token);
        }
        catch (Exception e)
        {
            Console.WriteLine($"TestService Error: {e.Message}");
        }

        _testService.Stop(input);
        var results = _testService.GetResults();
        Console.WriteLine($"You're WPM is {results!.Wpm}.");
    }

    private static async Task StartCountdown()
    {
        for (var i = 3; i > 0; i--)
        {
            Console.WriteLine($"Starting in {i} second(s)...");
            await Task.Delay(TimeSpan.FromSeconds(1));
        }

        Console.WriteLine("Starting test.");
    }
}