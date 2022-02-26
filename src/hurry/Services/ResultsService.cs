using hurry.Models;

namespace hurry.Services;

public interface IResultsService
{
    int CalculateWpm(Test test);
}
public class ResultsService : IResultsService
{
    public int CalculateWpm(Test test)
    {
        try
        { // TODO: fix: method always returns 0
            var wordCount = test.UserInput.Length / 5;
            test.Result!.Wpm = wordCount / test.SecondsElapsed;

            return test.Result!.Wpm;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred when attempting to calculate WPM. {e.Message}");
            return 0;
        }
    }
}