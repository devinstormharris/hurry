namespace hurry;

using System.IO;
using System.Reflection;

public static class Test
{
    private static char[]? _input;
    private static int _results;

    public static void Start()
    {
        _input = Array.Empty<char>();
        
        Prompt.Start();
        Clock.Start();
        GetInput();
        Clock.Stop();
        ViewInput();
        CalculateResults();
    }

    private static void GetInput()
    {
        var input = Console.ReadLine();
        _input = input!.ToCharArray();
    }

    private static void ViewInput()
    {
        Console.WriteLine("Your input: {0}", string.Join("", _input!));
        Console.WriteLine($"Time elapsed: {Clock.GetSeconds()} seconds...");
    }

    private static void CalculateResults()
    {
        // to normalize results, we are considering 1 "word" to equal 5 characters, so we determine
        // words entered by dividing total characters by 5

        var wordCount = _input!.Length / 5;

        // we first calculate words per second

        var wordsPerSecond = wordCount / Clock.GetSeconds();
        
        // then we multiply words per second by 60 to get words per minute (wpm)

        _results = wordsPerSecond * 60;
    }

    public static int GetResults()
    {
        return _results;
    }
}