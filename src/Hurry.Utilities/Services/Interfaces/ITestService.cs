using Hurry.Utilities.Models;

namespace Hurry.Utilities.Services.Interfaces;

public interface ITestService
{
    Task Start(CancellationToken token);
    void Stop(string input);
    Results? GetResults();
    string GetPrompt();
}