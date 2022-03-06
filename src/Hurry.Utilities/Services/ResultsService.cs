using Hurry.Utilities.Models;

namespace Hurry.Utilities.Services;

public class ResultsService
{
    /// <summary>
    /// Determines WPM.
    /// We divide word count by time elapsed to determine WPM.
    /// </summary>
    /// <param name="test">User's test data.</param>
    /// <param name="input">User's input data.</param>
    /// <returns>User's WPM.</returns>
    public Test CalculateWpm(Test test, string input)
    {
        test.UserInput = input.ToCharArray();
        test.IsComplete = true;
        
        var wordCount = CalculateWordCount(test);
        var time = CalculateMinutes(test);
        
        test.Result!.Wpm = (int) (wordCount / time);

        return test;
    }
    
    /// <summary>
    /// Determines word count.
    /// We divide every individual character the user entered by 5. We choose 5 to normalize word length.
    /// </summary>
    /// <param name="test">User's test data.</param>
    /// <returns>Normalized word count.</returns>
    private static int CalculateWordCount(Test test)
    {
        return test.UserInput.Length / 5;
    }

    /// <summary>
    /// Determines amount of time elapsed in minutes.
    /// </summary>
    /// <param name="test">User's test data.</param>
    /// <returns>Amount of minutes elapsed.</returns>
    private static double CalculateMinutes(Test test)
    {
        var minutes = 0.0;
        var seconds = test.SecondsElapsed;

        while (true)
        {
            switch (seconds)
            {
                case < 60:
                    if (minutes == 0) return seconds / 60.0;
                    else return minutes + (seconds / 60.0);

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
}