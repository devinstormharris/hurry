namespace hurry.Helpers;

public static class ScoreHelper
{
    private static char[]? _input;
    private static int _results;
    
    public static int GetScore(string input)
    {
        _input = Array.Empty<char>();
        CalculateScore(input);
        
        return _results;
    }
    
    private static void CalculateScore(string str)
    {
        _input = str!.ToCharArray();

        // to normalize results, we are considering 1 "word" to equal 5 characters, so we determine
        // words entered by dividing total characters by 5

        var wordCount = _input!.Length / 5;

        // we first calculate words per second

        var wordsPerSecond = wordCount / TimeHelper.GetSeconds();
        
        // then we multiply words per second by 60 to get words per minute (wpm)

        _results = wordsPerSecond * 60;
    }
}