using Hurry.Utilities.Models;

namespace Hurry.Utilities.Services;

public class ResultService
{
    public Test GetWpm(Test test)
    {
        GetErrors(test);
        var wordCount = GetWordCount(test);
        var time = GetMinutes(test);

        test.Result!.Wpm = (int) (wordCount / time);

        return test;
    }

    private void GetErrors(Test test)
    {
        var prompt = test.Prompt.Split();
        var userInput = test.UserInput.Split();

        for (var i = 0; i < userInput.Length; i++)
            if (prompt[i] != userInput[i])
                test.Result.Errors++;
    }
    
    private int GetWordCount(Test test)
    {
        return test.UserInput.Length / 5 - test.Result.Errors;
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