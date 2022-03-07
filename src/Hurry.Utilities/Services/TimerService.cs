using Hurry.Utilities.Models;

namespace Hurry.Utilities.Services;

public class TimerService
{
    public async Task<Test> StartTimer(Test test, CancellationToken token)
    {
        while(!token.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromSeconds(1), token)
                .ConfigureAwait(false);
            test.SecondsElapsed++;
        }

        return test;
    }
}