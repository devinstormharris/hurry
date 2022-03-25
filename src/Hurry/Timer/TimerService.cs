using Hurry.Models;

namespace Hurry.Services;

public class TimerService
{
    private readonly CancellationTokenSource _cts;
    private readonly CancellationToken _token;

    public TimerService()
    {
        _cts = new CancellationTokenSource();
        _token = _cts.Token;
    }

    public async Task<Test> StartTimer(Test test)
    {
        await Task.Yield();

        while (!_token.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromSeconds(1), _token)
                .ConfigureAwait(false);
            test.SecondsElapsed++;
        }

        return test;
    }

    public void StopTimer()
    {
        _cts.Cancel();
        _cts.Dispose();
    }
}