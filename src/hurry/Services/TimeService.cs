using System.Timers;
using hurry.Models;
using Timer = System.Timers.Timer;

namespace hurry.Services;

public class TimeService
{
    private static Timer? _timer;
    private static int _seconds;

    public void StartTimer(Test test)
    {
        _seconds = test.SecondsElapsed;
        _timer = new Timer(1000);
        _timer.Elapsed += OnTimedEvent!;
        _timer.AutoReset = true;
        _timer.Enabled = true;
    }
    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        _seconds++;
    }

    public void StopTimer(Test test)
    {
        _timer?.Stop();
        _timer?.Dispose();

        test.SecondsElapsed = _seconds;
    }
}