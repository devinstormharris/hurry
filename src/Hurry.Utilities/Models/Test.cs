using Hurry.Utilities.Helpers;

namespace Hurry.Utilities.Models;

public class Test
{
    public Test()
    {
        Result = new Results();
        Response = new Response();
        Prompt = PromptHelper.GetPrompt();
    }

    public string? Prompt { get; set; }

    public Results? Result { get; }

    public Response Response { get; set; }
}