# DatabaseJsonConvertFailed

Namespace: SlottyMedia.Database.Exceptions

This exception is thrown when an IUD action fails. I stands for Insert, U for Update and D for Delete.

```csharp
public class DatabaseJsonConvertFailed : SlottyMedia.LoggingProvider.BaseException`1[[SlottyMedia.Database.Exceptions.DatabaseJsonConvertFailed, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Runtime.Serialization.ISerializable
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception) → BaseException&lt;DatabaseJsonConvertFailed&gt; → [DatabaseJsonConvertFailed](./slottymedia.database.exceptions.databasejsonconvertfailed.md)<br>
Implements [ISerializable](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.iserializable)

## Properties

### **TargetSite**

```csharp
public MethodBase TargetSite { get; }
```

#### Property Value

[MethodBase](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.methodbase)<br>

### **Message**

```csharp
public string Message { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Data**

```csharp
public IDictionary Data { get; }
```

#### Property Value

[IDictionary](https://docs.microsoft.com/en-us/dotnet/api/system.collections.idictionary)<br>

### **InnerException**

```csharp
public Exception InnerException { get; }
```

#### Property Value

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

### **HelpLink**

```csharp
public string HelpLink { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Source**

```csharp
public string Source { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **HResult**

```csharp
public int HResult { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **StackTrace**

```csharp
public string StackTrace { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **DatabaseJsonConvertFailed()**

The default constructor.

```csharp
public DatabaseJsonConvertFailed()
```

### **DatabaseJsonConvertFailed(String)**

The constructor with parameters.

```csharp
public DatabaseJsonConvertFailed(string message)
```

#### Parameters

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **DatabaseJsonConvertFailed(String, String)**

The constructor with parameters.

```csharp
public DatabaseJsonConvertFailed(string propertyName, string message)
```

#### Parameters

`propertyName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **DatabaseJsonConvertFailed(String, Exception)**

The constructor with parameters.

```csharp
public DatabaseJsonConvertFailed(string message, Exception innerException)
```

#### Parameters

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`innerException` [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>
