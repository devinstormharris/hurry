using Hurry.Utilities.Models;

namespace Hurry.Utilities.Services
{
    public interface ITimerService
    {
        Task<Test> StartTimer(Test test, CancellationToken token);
    }
}