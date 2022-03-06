using Hurry.Utilities.Models;

namespace Hurry.Utilities.Services.Interfaces;

public interface ITestService
{
    Task StartTimer(CancellationToken token);
    void CalculateWpm(string input);
    Results? GetResults();
    string GetPrompt();
}