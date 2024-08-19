using NLog;

namespace SlottyMedia.LoggingProvider;

/// <summary>
///     Logging class to handle application logging using NLog.
/// </summary>
public class Logging
{
    /// <summary>
    ///     The logger instance.
    /// </summary>
    private static Logger Logger;

    /// <summary>
    ///     The instance of the Logging class.
    /// </summary>
    private static readonly Lazy<Logging> instance = new(() => new Logging());

    private Logging()
    {
        var config = NlogConfiguration.CreateNlogConfig();
        LogManager.Setup().LoadConfiguration(config);
        Logger = LogManager.GetCurrentClassLogger();
    }

    /// <summary>
    ///     The instance of the Logging class.
    /// </summary>
    public static Logging Instance => instance.Value;

    /// <summary>
    ///     This method logs a trace message.
    /// </summary>
    /// <param name="message"></param>
    public void LogTrace(string message)
    {
        Logger.Trace(message);
    }

    /// <summary>
    ///     This method logs a debug message.
    /// </summary>
    /// <param name="message"></param>
    public void LogDebug(string message)
    {
        Logger.Debug(message);
    }

    /// <summary>
    ///     This method logs an info message.
    /// </summary>
    /// <param name="message"></param>
    public void LogInfo(string message)
    {
        Logger.Info(message);
    }

    /// <summary>
    ///     This method logs a warning message.
    /// </summary>
    /// <param name="message"></param>
    public void LogWarn(string message)
    {
        Logger.Warn(message);
    }

    /// <summary>
    ///     This method logs an error message.
    /// </summary>
    /// <param name="message"></param>
    public void LogError(string message)
    {
        Logger.Error(message);
    }

    /// <summary>
    ///     This method logs an error message with an exception.
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    public void LogError(Exception ex, string message)
    {
        Logger.Error(ex, message);
    }

    /// <summary>
    ///     This method logs a fatal message.
    /// </summary>
    /// <param name="message"></param>
    public void LogFatal(string message)
    {
        Logger.Fatal(message);
    }

    /// <summary>
    ///     This method logs a fatal message with an exception.
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="message"></param>
    public void LogFatal(Exception ex, string message)
    {
        Logger.Fatal(ex, message);
    }
}