namespace Hurry.Utilities.Models;

public class Response
{
    public Response()
    {
        UserInput = Array.Empty<char>();
        SecondsElapsed = 0;
    }

    public char[] UserInput { get; set; }
    public int SecondsElapsed { get; set; }
}