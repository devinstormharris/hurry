using Hurry.Models;

namespace Hurry.Helpers;

public static class ResultHelper
{
    public static Test GetWpm(Test test)
    {
        GetErrors(test);
        var wordCount = GetWordCount(test);
        var time = GetMinutes(test);
        test.Wpm = CalculateWpm(wordCount, time);

        return test;
    }

    public static void GetErrors(Test test)
    {
        var prompt = test.Prompt.Split();
        var userInput = test.UserInput.Split();

        for (var i = 0; i < userInput.Length; i++)
            if (prompt[i] != userInput[i])
                test.Errors++;
    }

    private const int _averageWordLength = 5;
    public static int GetWordCount(Test test)
    {
        var lengthWithoutSpaces = RemoveWhitespace(test.UserInput).Length;

        return lengthWithoutSpaces / _averageWordLength - test.Errors;
    }

    private static string RemoveWhitespace(string input)
    {
        return new string(input.ToCharArray()
            .Where(c => !char.IsWhiteSpace(c))
            .ToArray());
    }

    private const int _sixtySeconds = 60;
    private const double _oneMinute = 1.0;
    public static double GetMinutes(Test test)
    {
        var minutes = 0.0;
        var seconds = test.SecondsElapsed;

        while (true)
            switch (seconds)
            {
                case < _sixtySeconds:
                    if (minutes == 0) return seconds / (double)_sixtySeconds;
                    else return minutes + seconds / (double)_sixtySeconds;

                case _sixtySeconds:
                    return _oneMinute;
                default:
                {
                    seconds -= _sixtySeconds;
                    minutes++;
                    break;
                }
            }
    }

    private static int CalculateWpm(int wordCount, double time)
    {
        var wpm = (int) (wordCount / time);
        return wpm < 0 ? 0 : wpm;
    }
}