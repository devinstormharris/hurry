namespace hurry;

using System.IO;
using System.Reflection;

public static class Test
{
    private static char[]? _input;

    public static void Start()
    {
        _input = Array.Empty<char>();
        
        Prompt.Start();
        Clock.Start();
        GetInput();
        Clock.Stop();
        ViewInput();
        // calculate results
        // return results
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
}