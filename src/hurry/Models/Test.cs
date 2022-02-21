using hurry.Helpers;

namespace hurry.Models;

public class Test
{
    public Test()
    {
        Result = new Results();
        Prompt = PromptHelper.GetPrompt();
    }
    public string Prompt { get; }
    
    public Results Result { get; }
    
    public char[] UserInput { get; set; }
    
    public int Seconds { get; set; }
}