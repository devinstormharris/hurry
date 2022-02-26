using System.Timers;
using hurry.Models;
using Timer = System.Timers.Timer;

namespace hurry.Services;

public interface ITimerService
{
    Task StartTimer(Test test, CancellationToken token);
}
public class TimerService : ITimerService
{
    public async Task StartTimer(Test test, CancellationToken token)
    {
        await Task.Delay(TimeSpan.FromMinutes(1), token)
            .ConfigureAwait(false);
    }
}