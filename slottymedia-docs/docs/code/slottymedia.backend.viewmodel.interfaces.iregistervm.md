# IRegisterVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

```csharp
public interface IRegisterVm
```

## Methods

### **RegisterAsync(String, String)**

```csharp
Task<Session> RegisterAsync(string email, string password)
```

#### Parameters

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetCurrentSession()**

```csharp
Session GetCurrentSession()
```

#### Returns

Session<br>
