using Hurry.Utilities.Models;
using Hurry.Utilities.Services.Interfaces;

namespace Hurry.Utilities.Services;

public class ResultsService : IResultsService
{
    public int CalculateWpm(Test test)
    {
        var wordCount = test.UserInput.Length / 5;
        var time = CalculateMinutes(test.SecondsElapsed);
        test.Result!.Wpm = (int) (wordCount / time);

        return test.Result!.Wpm;
    }

    private static double CalculateMinutes(int seconds)
    {
        if (seconds >= 60) return seconds;

        var minutes = seconds / (double) 60;
        return minutes;
    }
}