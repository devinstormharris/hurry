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
        {
            var wordCount = test.UserInput.Length / 5;
            var time = CalculateMinutes(test.SecondsElapsed);
            test.Result!.Wpm = (int) (wordCount / time);

            return test.Result!.Wpm;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred when attempting to calculate WPM. {e.Message}");
            return 0;
        }
    }

    private static double CalculateMinutes(int seconds)
    {
        if (seconds >= 60) return seconds;

        var minutes = seconds / (double) 60;
        return minutes;
    }
}