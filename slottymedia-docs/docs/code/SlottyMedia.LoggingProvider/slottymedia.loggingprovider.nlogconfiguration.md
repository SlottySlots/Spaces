# NlogConfiguration

Namespace: SlottyMedia.LoggingProvider

The configuration for NLog.

```csharp
public static class NlogConfiguration
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [NlogConfiguration](./slottymedia.loggingprovider.nlogconfiguration.md)

## Methods

### **CreateNlogConfig()**

This method creates a new NLog configuration.

```csharp
public static LoggingConfiguration CreateNlogConfig()
```

#### Returns

LoggingConfiguration<br>

**Remarks:**

The `CreateNlogConfig` method generates an NLog configuration for logging:
 1. **Initialize Configuration**: Creates a `LoggingConfiguration` object.
 2. **Define Log File Target**: Creates a `FileTarget` named "logfile" with daily archiving and a specific layout.
 3. **Define Console Target**: Creates a `ColoredConsoleTarget` named "console" with ANSI output and custom
 highlighting rules.
 4. **Add Console Row Highlighting Rules**: Adds custom highlighting rules for different log levels to the console
 target.
 5. **Wrap Targets in Async Wrappers**: Wraps the file and console targets in `AsyncTargetWrapper` for asynchronous
 logging.
 6. **Add Targets to Configuration**: Adds the async file and console targets to the logging configuration.
 7. **Define Logging Rules**: Adds rules to log messages to the file and console targets, with a filter for
 Microsoft logs.
 8. **Return Configuration**: Returns the configured `LoggingConfiguration` object.
