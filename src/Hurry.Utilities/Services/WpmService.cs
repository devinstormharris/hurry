using Hurry.Utilities.Models;

namespace Hurry.Utilities.Services;

public class WpmService
{
    public Test CalculateWpm(Test test)
    {
        var wordCount = test.UserInput.Length / 5;
        var time = CalculateMinutes(test);

        test.Result!.Wpm = (int) (wordCount / time);

        return test;
    }

    private static double CalculateMinutes(Test test)
    {
        var minutes = 0.0;
        var seconds = test.Result.SecondsElapsed;

        while (true)
            switch (seconds)
            {
                case < 60:
                    if (minutes == 0) return seconds / 60.0;
                    else return minutes + seconds / 60.0;

                case 60:
                    return 1.0;
                default:
                {
                    seconds -= 60;
                    minutes++;
                    break;
                }
            }
    }
}