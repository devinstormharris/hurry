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
                .Single(str => str.EndsWith(RandomizePrompt()));

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

    private static string RandomizePrompt()
    {
        var prompts = new Dictionary<int, string>()
        {
            {1, "prompt1.txt"},
            {2, "prompt2.txt"}
        };

        Random random = new Random();
        int randomInt = random.Next(1, prompts.Count);

        return prompts[randomInt];
    }
}