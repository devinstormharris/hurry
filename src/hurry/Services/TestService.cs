using hurry.Models;

namespace hurry.Services;

public interface ITestService
{
    string GetPrompt();
    void Start();
    void Stop(string input);
    Results? GetResults();
}
public class TestService : ITestService
{
    private readonly Test _test = new();
    private readonly ITimerService _timerService;
    private readonly IPromptService _promptService;
    private readonly IResultsService _resultsService;

    public TestService(ITimerService timerService, IPromptService promptService, IResultsService resultsService)
    {
        _timerService = timerService;
        _promptService = promptService;
        _resultsService = resultsService;
    }
    public string GetPrompt()
    {
        _test.Prompt = _promptService.GetPrompt();
        return _test.Prompt;
    }

    public void Start()
    {
        _timerService.StartTimer(_test);
    }

    public void Stop(string input)
    {
        _test.UserInput = input.ToCharArray();
        _timerService.StopTimer(_test);
        _test.Result!.Wpm = _resultsService.CalculateWpm(_test);
        _test.IsComplete = true;
    }

    public Results? GetResults()
    {
        return _test.IsComplete ? _test.Result : null;
    }
}