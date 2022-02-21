using System.Timers;
using hurry.Models;
using Timer = System.Timers.Timer;

namespace hurry.Helpers;

public static class TimeHelper
{
    private static Timer? _timer;
    private static int _seconds;
    
    public static void StartTimer(Test test)
    {
        _seconds = test.Seconds;
        _timer = new Timer(1000);
        _timer.Elapsed += OnTimedEvent!;
        _timer.AutoReset = true;
        _timer.Enabled = true;
    }

    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        _seconds++;
    }
    
    public static Test StopTimer(Test test)
    {
        _timer?.Stop();
        _timer?.Dispose();

        test.Seconds = _seconds;

        return test;
    }
}