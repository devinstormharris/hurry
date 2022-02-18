namespace hurry;

using System.Timers;

public static class TypingTest
{
    private static Timer? _timer;
    private static int _seconds;

    public static int Start()
    {
        StartTimer();
        // output prompt
        // input user text
        StopTimer();
        // calculate results
        // return results
        
        return _seconds;
    }

    private static void StartTimer()
    {
        _timer = new Timer(1000);
        _timer.Elapsed += OnTimedEvent!;
        _timer.AutoReset = true;
        _timer.Enabled = true;
    }
    
    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        _seconds++;
    }

    private static void StopTimer()
    {
        _timer?.Stop();
        _timer?.Dispose();
    }
}