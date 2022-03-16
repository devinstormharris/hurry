using Hurry.Utilities.Models;

namespace Hurry.Utilities.Services;

public class ResultService
{
    public static Test GetWpm(Test test)
    {
        GetErrors(test);
        var wordCount = GetWordCount(test);
        var time = GetMinutes(test);

        test.Result!.Wpm = (int) (wordCount / time);

        return test;
    }

    private static void GetErrors(Test test)
    {
        var prompt = test.Prompt.Split();
        var userInput = test.UserInput.Split();

        for (var i = 0; i < userInput.Length; i++)
            if (prompt[i] != userInput[i])
                test.Result.Errors++;
    }
    
    private static int GetWordCount(Test test)
    {
        var lengthWithoutSpaces = RemoveWhitespace(test.UserInput).Length;
        
        return lengthWithoutSpaces / 5 - test.Result.Errors;
    }

    private static string RemoveWhitespace(string input)
    {
        return new string(input.ToCharArray()
            .Where(c => !Char.IsWhiteSpace(c))
            .ToArray());
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