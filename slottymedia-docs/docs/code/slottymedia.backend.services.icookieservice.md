# ICookieService

Namespace: SlottyMedia.Backend.Services

```csharp
public interface ICookieService
```

## Methods

### **SetCookie(String, String, Int32)**

```csharp
ValueTask SetCookie(string name, string value, int days)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`days` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>

### **GetCookie(String)**

```csharp
ValueTask<string> GetCookie(string name)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[ValueTask&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1)<br>

### **RemoveCookie(String)**

```csharp
ValueTask<string> RemoveCookie(string name)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[ValueTask&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1)<br>
