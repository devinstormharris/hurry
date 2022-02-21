using hurry.Helpers;
using hurry.Models;

namespace hurry;

public class TestingService
{
    public Results Start()
    {
        var prompt = PromptHelper.GetPrompt();
        var test = new Test(prompt);

        TimeHelper.Start();
        Console.WriteLine(test.ToString());

        var input = Console.ReadLine();
        TimeHelper.Stop();

        var wpm = ResultsHelper.CalculateWpm(input!);
        var results = new Results(wpm);

        return results;
    }
}