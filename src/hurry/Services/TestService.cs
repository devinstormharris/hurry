using hurry.Models;

namespace hurry.Services;

public class TestService
{
    private readonly Test _test = new();
    private readonly TimeService _timeService = new();
    private readonly PromptService _promptService = new();
    private readonly ResultsService _resultsService = new();

    public string GetPrompt()
    {
        _test.Prompt = _promptService.GetPrompt();
        return _test.Prompt;
    }

    public void Start()
    {
        _timeService.StartTimer(_test);
    }

    public void Stop(string input)
    {
        _test.UserInput = input.ToCharArray();
        _timeService.StopTimer(_test);
        _resultsService.CalculateWpm(_test);
        _test.IsComplete = true;
    }

    public Results? GetResults()
    {
        return _test.IsComplete ? _test.Result : null;
    }
}