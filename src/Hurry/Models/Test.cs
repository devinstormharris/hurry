namespace Hurry.Models;

public class Test
{
    public Test()
    {
        Result = new Results();
        UserInput = string.Empty;
        Prompt = string.Empty;
    }

    public string Prompt { get; set; }

    public Results Result { get; }

    public string UserInput { get; set; }
}