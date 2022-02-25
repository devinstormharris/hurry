namespace hurry.Models;

public class Test
{
    public Test()
    {
        Result = new Results();
        Prompt = "";
        IsComplete = false;
        UserInput = null!;
    }

    public string Prompt { get; set; }

    public Results? Result { get; }

    public char[] UserInput { get; set; }

    public int SecondsElapsed { get; set; }

    public bool IsComplete { get; set; }
}