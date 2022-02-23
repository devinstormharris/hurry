using hurry.Helpers;
using hurry.Models;

namespace hurry.Services;

public class TestService
{
    private readonly Test _test = new Test();

    public string GetPrompt()
    {
        return _test.Prompt;
    }

    public void Start()
    {
        _test.StartTimer();
    }

    public void Stop(string input)
    {
        _test.UserInput = input.ToCharArray();
        _test.StopTimer();
        _test.CalculateWpm();
        _test.IsComplete = true;
    }

    public Results? GetResults()
    {
        return _test.IsComplete ? _test.Result : null;
    }
}