using Hurry.Utilities.Models;

namespace Hurry.Utilities.Services
{
    public interface ITestService
    {
        Task Start(CancellationToken token);
        void Stop(string input);
        Results? GetResults();
        string GetPrompt();
    }
}