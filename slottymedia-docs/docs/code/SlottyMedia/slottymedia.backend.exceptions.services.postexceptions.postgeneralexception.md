# PostGeneralException

Namespace: SlottyMedia.Backend.Exceptions.Services.PostExceptions

Represents a general exception that occurs in the Post service.

```csharp
public class PostGeneralException : SlottyMedia.LoggingProvider.BaseException`1[[SlottyMedia.Backend.Exceptions.Services.PostExceptions.PostGeneralException, SlottyMedia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Runtime.Serialization.ISerializable
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception) → BaseException&lt;PostGeneralException&gt; → [PostGeneralException](./slottymedia.backend.exceptions.services.postexceptions.postgeneralexception.md)<br>
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

### **PostGeneralException(String)**

Initializes a new instance of the [PostGeneralException](./slottymedia.backend.exceptions.services.postexceptions.postgeneralexception.md) class with a specified error message.

```csharp
public PostGeneralException(string message)
```

#### Parameters

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The message that describes the error.

### **PostGeneralException(String, Exception)**

Initializes a new instance of the [PostGeneralException](./slottymedia.backend.exceptions.services.postexceptions.postgeneralexception.md) class with a specified error message and a
 reference to the inner exception that is the cause of this exception.

```csharp
public PostGeneralException(string message, Exception innerException)
```

#### Parameters

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The message that describes the error.

`innerException` [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>
The exception that is the cause of the current exception.
