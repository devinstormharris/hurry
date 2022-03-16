namespace Hurry.Utilities.Models;

public class Results
{
    public Results()
    {
        Wpm = 0;
        Errors = 0;
        SecondsElapsed = 0;
    }

    public int Wpm { get; set; }
    public int Errors { get; set; }
    public int SecondsElapsed { get; set; }
}