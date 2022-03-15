namespace Hurry.Utilities.Models;

public class Results
{
    public Results()
    {
        Wpm = 0;
        Accuracy = 0;
        SecondsElapsed = 0;
    }

    public int Wpm { get; set; }
    public double Accuracy { get; set; }
    public int SecondsElapsed { get; set; }
}