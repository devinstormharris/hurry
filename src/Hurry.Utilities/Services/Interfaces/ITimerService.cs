using Hurry.Utilities.Models;

namespace Hurry.Utilities.Services.Interfaces;

public interface ITimerService
{
    Task<Test> StartTimer(Test test, CancellationToken token);
}