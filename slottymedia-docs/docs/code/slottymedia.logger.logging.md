# Logging

Namespace: SlottyMedia.Logger

Logging class to handle application logging using NLog.

```csharp
public class Logging
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Logging](./slottymedia.logger.logging.md)

## Properties

### **Instance**

```csharp
public static Logging Instance { get; }
```

#### Property Value

[Logging](./slottymedia.logger.logging.md)<br>

## Methods

### **LogDebug(String)**

```csharp
public void LogDebug(string message)
```

#### Parameters

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **LogInfo(String)**

```csharp
public void LogInfo(string message)
```

#### Parameters

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **LogError(String)**

```csharp
public void LogError(string message)
```

#### Parameters

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **LogError(Exception, String)**

```csharp
public void LogError(Exception ex, string message)
```

#### Parameters

`ex` [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
