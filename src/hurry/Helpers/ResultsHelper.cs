using hurry.Models;

namespace hurry.Helpers;

public static class ResultsHelper
{
    public static int CalculateWpm(this Test test)
    {
        try
        {
            // TODO: calculate wpm accurately
            var wordCount = test.UserInput.Length / 5L;
            var wordsPerSecond = wordCount / test.SecondsElapsed;
            var results = (int) wordsPerSecond * 60;

            return results;
        }
        catch (Exception)
        {
            Console.WriteLine("An error occurred when attempting to calculate WPM.");
            return 0;
        }
    }
}