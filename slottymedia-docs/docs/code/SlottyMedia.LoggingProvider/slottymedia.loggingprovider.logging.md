# Logging

Namespace: SlottyMedia.LoggingProvider

Logging class to handle application logging using NLog.

```csharp
public class Logging
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Logging](./slottymedia.loggingprovider.logging.md)

## Properties

### **Instance**

The instance of the Logging class.

```csharp
public static Logging Instance { get; }
```

#### Property Value

[Logging](./slottymedia.loggingprovider.logging.md)<br>

## Methods

### **LogTrace(String)**

This method logs a trace message.

```csharp
public void LogTrace(string message)
```

#### Parameters

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **LogDebug(String)**

This method logs a debug message.

```csharp
public void LogDebug(string message)
```

#### Parameters

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **LogInfo(String)**

This method logs an info message.

```csharp
public void LogInfo(string message)
```

#### Parameters

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **LogWarn(String)**

This method logs a warning message.

```csharp
public void LogWarn(string message)
```

#### Parameters

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **LogError(String)**

This method logs an error message.

```csharp
public void LogError(string message)
```

#### Parameters

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **LogError(Exception, String)**

This method logs an error message with an exception.

```csharp
public void LogError(Exception ex, string message)
```

#### Parameters

`ex` [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **LogFatal(String)**

This method logs a fatal message.

```csharp
public void LogFatal(string message)
```

#### Parameters

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **LogFatal(Exception, String)**

This method logs a fatal message with an exception.

```csharp
public void LogFatal(Exception ex, string message)
```

#### Parameters

`ex` [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
