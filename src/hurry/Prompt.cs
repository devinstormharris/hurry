using System.Reflection;

namespace hurry;

public static class Prompt
{
    public static void Start()
    {
        var assembly = Assembly.GetExecutingAssembly();

        var promptPath = assembly.GetManifestResourceNames()
            .Single(str => str.EndsWith("prompt.txt"));

        using (Stream? stream = assembly.GetManifestResourceStream(promptPath))
        using (StreamReader reader = new StreamReader(stream!))
        {
            var prompt = reader.ReadToEnd();
            Console.WriteLine(prompt);
        }
    }
    
    // TODO: Add prompt randomizer
}