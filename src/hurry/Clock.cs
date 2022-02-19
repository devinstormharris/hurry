namespace hurry;

using System.Timers;

internal static class Clock
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
    
    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        _seconds++;
        // Console.WriteLine($"tik {_seconds}");
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