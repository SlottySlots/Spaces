# UserIudException

Namespace: SlottyMedia.Backend.Exceptions.Services.UserExceptions

Represents an exception that occurs during Insert, Update, or Delete operations in the User service.

```csharp
public class UserIudException : SlottyMedia.Backend.Exceptions.BaseException, System.Runtime.Serialization.ISerializable
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception) → [BaseException](./slottymedia.backend.exceptions.baseexception.md) → [UserIudException](./slottymedia.backend.exceptions.services.userexceptions.useriudexception.md)<br>
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

### **UserIudException(String)**

Initializes a new instance of the [UserIudException](./slottymedia.backend.exceptions.services.userexceptions.useriudexception.md) class with a specified error message.

```csharp
public UserIudException(string message)
```

#### Parameters

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The message that describes the error.

### **UserIudException(String, Exception)**

Initializes a new instance of the [UserIudException](./slottymedia.backend.exceptions.services.userexceptions.useriudexception.md) class with a specified error message and a
 reference to the inner exception that is the cause of this exception.

```csharp
public UserIudException(string message, Exception innerException)
```

#### Parameters

`message` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The message that describes the error.

`innerException` [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>
The exception that is the cause of the current exception.