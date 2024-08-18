using NLog;

namespace SlottyMedia.LoggingProvider;

/// <summary>
///     Logging class to handle application logging using NLog.
/// </summary>
public class Logging
{
    private static Logger Logger;
    private static readonly Lazy<Logging> instance = new(() => new Logging());

    private Logging()
    {
        var config = NlogConfiguration.CreateNlogConfig();
        LogManager.Setup().LoadConfiguration(config);
        Logger = LogManager.GetCurrentClassLogger();
    }

    public static Logging Instance => instance.Value;

    public void LogTrace(string message)
    {
        Logger.Trace(message);
    }

    public void LogDebug(string message)
    {
        Logger.Debug(message);
    }

    public void LogInfo(string message)
    {
        Logger.Info(message);
    }

    public void LogWarn(string message)
    {
        Logger.Warn(message);
    }

    public void LogError(string message)
    {
        Logger.Error(message);
    }

    public void LogError(Exception ex, string message)
    {
        Logger.Error(ex, message);
    }

    public void LogFatal(string message)
    {
        Logger.Fatal(message);
    }

    public void LogFatal(Exception ex, string message)
    {
        Logger.Fatal(ex, message);
    }
}