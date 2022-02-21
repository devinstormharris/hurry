using System.Timers;
using Timer = System.Timers.Timer;

namespace hurry.Helpers;

internal static class TimeHelper
{
    private static Timer? _timer;
    private static int _seconds;


    public static void Start()
    {
        _seconds = 0;
        _timer = new Timer(1000);
        _timer.Elapsed += OnTimedEvent!;
        _timer.AutoReset = true;
        _timer.Enabled = true;
    }

    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        _seconds++;
    }

    public static void Stop()
    {
        _timer?.Stop();
        _timer?.Dispose();
    }

    public static int GetSeconds()
    {
        return _seconds;
    }
}