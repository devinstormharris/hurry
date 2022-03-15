using Hurry.Utilities.Models;

namespace Hurry.Utilities.Services;

public class ResultService
{
    public Test GetWpm(Test test)
    {
        GetErrors(test);
        var wordCount = (test.UserInput.Length / 5) - test.Result.Errors;
        var time = GetMinutes(test);

        test.Result!.Wpm = (int) (wordCount / time);

        return test;
    }

    private Test GetErrors(Test test)
    {
        var accuracy = 1.0;

        var prompt = test.Prompt.Split();
        var userInput = test.UserInput.Split();

        for (int i = 0; i < userInput.Length; i++)
        {
            if (prompt[i] != userInput[i])
            {
                test.Result.Errors++;
            }
        }

        if (test.Result.Errors > 0)
        {
            accuracy = 1 - Math.Round((double)test.Result.Errors / userInput.Length, 1);
        }

        test.Result.Accuracy = accuracy;

        return test;
    }
    
    private static double GetMinutes(Test test)
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