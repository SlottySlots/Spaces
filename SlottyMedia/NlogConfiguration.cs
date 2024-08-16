using NLog;
using NLog.Conditions;
using NLog.Config;
using NLog.Targets;
using NLog.Targets.Wrappers;

namespace SlottyMedia;

/// <summary>
/// Configuration for NLog.
/// </summary>
public class NlogConfiguration
{
    /// <summary>
    /// Create a new NLog configuration.
    /// </summary>
    /// <returns></returns>
    public static LoggingConfiguration CreateNlogConfig()
    {
        var config = new LoggingConfiguration();

        // Ensure the directory for the log file exists
        var logFilePath = "logs/logfile-${shortdate}.txt";

        // Define targets
        var logfile = new FileTarget("logfile")
        {
            FileName = logFilePath,
            ArchiveEvery = FileArchivePeriod.Day,
            ArchiveNumbering = ArchiveNumberingMode.Date,
            MaxArchiveFiles = 30,
            ArchiveFileName = "logs/archives/logfile-{#}.txt",
            Layout = @"${date:format=HH\:mm\:ss} [${level}] ${logger} ${message}"
        };
        var logconsole = new ColoredConsoleTarget("console")
        {
            Layout = @"${date:format=HH\:mm\:ss} [${level}] ${logger} ${message}",
            UseDefaultRowHighlightingRules = true
        };
        
        var highlightRule = new ConsoleRowHighlightingRule();

        highlightRule.Condition = ConditionParser.ParseExpression("level == LogLevel.Debug");
        highlightRule.ForegroundColor = ConsoleOutputColor.Green;
        highlightRule.BackgroundColor = ConsoleOutputColor.Red;
        logconsole.RowHighlightingRules.Add(highlightRule);
        
        // Wrap targets in AsyncTargetWrapper
        var asyncLogfile = new AsyncTargetWrapper(logfile);
        var asyncLogconsole = new AsyncTargetWrapper(logconsole);

        // Add targets to configuration
        config.AddTarget(asyncLogfile);
        config.AddTarget(asyncLogconsole);

        // Define rules
        config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, asyncLogfile);
        config.AddRule(NLog.LogLevel.Debug, NLog.LogLevel.Fatal, asyncLogconsole);

        // Apply configuration
        return config;
    }
}