using System.Reflection;

namespace hurry.Helpers;

public static class PromptHelper
{
    public static string GetPrompt()
    {
        try
        {
            var assembly = Assembly.GetExecutingAssembly();

            var promptPath = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith("prompt.txt"));

            using var stream = assembly.GetManifestResourceStream(promptPath);
            using var reader = new StreamReader(stream!);
            var prompt = reader.ReadToEnd();
            return prompt;
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred when attempting to get prompt from assembly.", e);
            return "";
        }
    }

    // TODO: Add prompt randomizer
}