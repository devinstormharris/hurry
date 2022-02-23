using hurry.Helpers;
using hurry.Models;

namespace hurry.Services;

public class TestService
{
    private readonly Test _test = new Test();
    
    public void StartTest()
    {
        _test.StartCountdown();
        
        _test.PrintPrompt();
        _test.StartTimer();
    }
    
    public void StopTest(string input)
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