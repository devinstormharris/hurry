using hurry.Models;

namespace hurry.Services;

public interface ITimerService
{
    Task<Test> StartTimer(Test test, CancellationToken token);
}

public class TimerService : ITimerService
{
    public async Task<Test> StartTimer(Test test, CancellationToken token)
    {
        for (var i = 0; i < 60; i++)
        {
            await Task.Delay(TimeSpan.FromSeconds(1), token)
                .ConfigureAwait(false);
            test.SecondsElapsed++;
        }

        return test;
    }
}