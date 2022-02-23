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
        var promptPath = assembly.GetManifestResourceNames()
            .Single(str => str.EndsWith(prompts[randomInt]));
        
        using var stream = assembly.GetManifestResourceStream(promptPath);
        using var reader = new StreamReader(stream!);
        var prompt = reader.ReadToEnd();
            
        return prompt;    
    }
}