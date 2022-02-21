namespace hurry.Models;

public class Results
{
    public Results(int wpm)
    {
        Wpm = wpm;
    }

    private int Wpm { get; }

    public override string ToString()
    {
        return Wpm.ToString();
    }
}