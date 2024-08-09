# IRegisterVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

Interface providing the contract to register a user in a viewmodel

```csharp
public interface IRegisterVm
```

## Methods

### **RegisterAsync(String, String)**

Registers a user by:
 1. Saving user in db
 2. Saving cookies in clients browser

```csharp
Task<Session> RegisterAsync(string email, string password)
```

#### Parameters

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Email used to register

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Password used to register

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the session returned by viewmodel

### **GetCurrentSession()**

Gets the current session if it exists, otherwise null

```csharp
Session GetCurrentSession()
```

#### Returns

Session<br>
Returns the session set on client-side (if available otherwise null)
