namespace hurry.Models;

public class Test
{
    public Test(string prompt)
    {
        Prompt = prompt;
    }

    private string Prompt { get; }

    public override string ToString()
    {
        return Prompt;
    }
}