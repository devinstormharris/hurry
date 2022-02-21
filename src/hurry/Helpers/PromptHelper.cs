using System.Reflection;
using hurry.Models;

namespace hurry.Helpers;

public static class PromptHelper
{
    public static string GetPrompt()
    {
        var prompts = new Dictionary<int, string>()
        {
            {0, "prompt1.txt"},
            {1, "prompt2.txt"}
        };
        
        var random = new Random();
        var randomInt = random.Next(prompts.Count);

        var assembly = Assembly.GetExecutingAssembly();
        var path = assembly.GetManifestResourceNames()
            .Single(str => str.EndsWith(prompts[randomInt]));

        return path;
    }

    public static void PrintPrompt(Test test)
    {
        var prompt = ReadPrompt(test);
        Console.WriteLine(prompt);
    }

    private static string ReadPrompt(Test test)
    {
        try
        {
            var assembly = Assembly.GetExecutingAssembly();

            using var stream = assembly.GetManifestResourceStream(test.Prompt);
            using var reader = new StreamReader(stream!);
            var prompt = reader.ReadToEnd();
            
            return prompt;
        }
        catch (Exception)
        {
            Console.WriteLine("PromptHelper: An error occurred when attempting to read prompt from assembly.");
            return "";
        }
    }
}