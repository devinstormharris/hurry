namespace hurry.Helpers;

public static class ResultsHelper
{
    public static int CalculateWpm(string input)
    {
        try
        {
            var inputParsed = input!.ToCharArray();

            // to normalize results, we are considering 1 "word" to equal 5 characters, so we determine
            // words entered by dividing total characters by 5

            var wordCount = inputParsed!.Length / 5;

            // we first calculate words per second

            var wordsPerSecond = wordCount / TimeHelper.GetSeconds();

            // then we multiply words per second by 60 to get words per minute (wpm)

            var results = wordsPerSecond * 60;
            return results;
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred when attempting to calculate WPM.", e);
            return 0;
        }
    }
}