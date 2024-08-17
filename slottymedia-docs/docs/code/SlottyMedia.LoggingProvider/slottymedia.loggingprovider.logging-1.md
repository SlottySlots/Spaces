# Logging&lt;T&gt;

Namespace: SlottyMedia.LoggingProvider

Logging class to handle application logging using NLog.

```csharp
public class Logging<T>
```

#### Type Parameters

`T`<br>

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Logging&lt;T&gt;](./slottymedia.loggingprovider.logging-1.md)

## Constructors

### **Logging()**

Constructor for the Logging class.

```csharp
public Logging()
```

## Methods

### **LogTrace(String)**

Logs a trace message.

```csharp
public void LogTrace(string message)
```

#### Parameters

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The message to log.

### **LogDebug(String)**

Logs a debug message.

```csharp
public void LogDebug(string message)
```

#### Parameters

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The message to log.

### **LogInfo(String)**

Logs an info message.

```csharp
public void LogInfo(string message)
```

#### Parameters

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The message to log.

### **LogWarn(String)**

Logs a warning message.

```csharp
public void LogWarn(string message)
```

#### Parameters

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The message to log.

### **LogError(String)**

Logs an error message.

```csharp
public void LogError(string message)
```

#### Parameters

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The message to log.

### **LogFatal(String)**

Logs a fatal message.

```csharp
public void LogFatal(string message)
```

#### Parameters

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The message to log.

### **LogTrace(Exception, String)**

Logs a trace message with an exception.

```csharp
public void LogTrace(Exception ex, string message)
```

#### Parameters

`ex` [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>
The exception to log.

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The message to log.

### **LogDebug(Exception, String)**

Logs a debug message with an exception.

```csharp
public void LogDebug(Exception ex, string message)
```

#### Parameters

`ex` [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>
The exception to log.

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The message to log.

### **LogInfo(Exception, String)**

Logs an info message with an exception.

```csharp
public void LogInfo(Exception ex, string message)
```

#### Parameters

`ex` [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>
The exception to log.

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The message to log.

### **LogWarn(Exception, String)**

Logs a warning message with an exception.

```csharp
public void LogWarn(Exception ex, string message)
```

#### Parameters

`ex` [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>
The exception to log.

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The message to log.

### **LogError(Exception, String)**

Logs an error message with an exception.

```csharp
public void LogError(Exception ex, string message)
```

#### Parameters

`ex` [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>
The exception to log.

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The message to log.

### **LogFatal(Exception, String)**

Logs a fatal message with an exception.

```csharp
public void LogFatal(Exception ex, string message)
```

#### Parameters

`ex` [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>
The exception to log.

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The message to log.
