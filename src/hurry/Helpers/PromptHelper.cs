using System.Reflection;

namespace hurry.Helpers;

public static class PromptHelper
{
    public static void GetPrompt()
    {
        var assembly = Assembly.GetExecutingAssembly();

        var promptPath = assembly.GetManifestResourceNames()
            .Single(str => str.EndsWith("prompt.txt"));

        using var stream = assembly.GetManifestResourceStream(promptPath);
        using var reader = new StreamReader(stream!);
        var prompt = reader.ReadToEnd();
        Console.WriteLine(prompt);
    }

    // TODO: Add prompt randomizer
}