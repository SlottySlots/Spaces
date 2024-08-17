# TokenNotProvidedException

Namespace: SlottyMedia.Backend.Exceptions.auth

Exception to handle missing Access- and RefreshToken f.e. when handling Sessions

```csharp
public class TokenNotProvidedException : SlottyMedia.LoggingProvider.BaseException`1[[SlottyMedia.Backend.Exceptions.auth.TokenNotProvidedException, SlottyMedia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Runtime.Serialization.ISerializable
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception) → BaseException&lt;TokenNotProvidedException&gt; → [TokenNotProvidedException](./slottymedia.backend.exceptions.auth.tokennotprovidedexception.md)<br>
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

### **TokenNotProvidedException(Boolean, Boolean)**

Initializes a TokenNotProvidedException. It als implements an inner exception showing which token is missin

```csharp
public TokenNotProvidedException(bool accessTokenProvided, bool refreshTokenProvided)
```

#### Parameters

`accessTokenProvided` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Boolean indicating the existence of an AccessToken

`refreshTokenProvided` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Boolean indicating the existence of a RefreshToken
