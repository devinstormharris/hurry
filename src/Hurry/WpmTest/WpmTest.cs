namespace Hurry.WpmTest;

public class Test
{
    public Test()
    {
        UserInput = string.Empty;
        Prompt = string.Empty;
        Wpm = 0;
        Errors = 0;
        SecondsElapsed = 0;
    }

    public string Prompt { get; set; }
    
    public string UserInput { get; set; }
    
    public int Wpm { get; set; }
    
    public int Errors { get; set; }
    
    public int SecondsElapsed { get; set; }
}