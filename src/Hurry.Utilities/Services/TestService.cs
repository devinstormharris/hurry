using Hurry.Utilities.Models;

namespace Hurry.Utilities.Services;

public class TestService : ITestService
{
    private readonly IPromptService _promptService;
    private readonly IResultsService _resultsService;
    private readonly Test _test = new();
    private readonly ITimerService _timerService;

    public TestService(ITimerService timerService, IPromptService promptService, IResultsService resultsService)
    {
        _timerService = timerService;
        _promptService = promptService;
        _resultsService = resultsService;
    }

    public async Task Start(CancellationToken token)
    {
        await _timerService.StartTimer(_test, token);
    }

    public void Stop(string input)
    {
        _test.UserInput = input.ToCharArray();
        _test.IsComplete = true;
        _test.Result!.Wpm = _resultsService.CalculateWpm(_test);
    }

    public Results? GetResults()
    {
        return _test.IsComplete ? _test.Result : null;
    }

    public string GetPrompt()
    {
        return _test.Prompt ?? (_test.Prompt = _promptService.GetPrompt());
    }
}