# RegisterVm

Namespace: SlottyMedia.Backend.ViewModel

```csharp
public class RegisterVm : SlottyMedia.Backend.ViewModel.Interfaces.IRegisterVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [RegisterVm](./slottymedia.backend.viewmodel.registervm.md)<br>
Implements [IRegisterVm](./slottymedia.backend.viewmodel.interfaces.iregistervm.md)

## Constructors

### **RegisterVm(IAuthService)**

```csharp
public RegisterVm(IAuthService authService)
```

#### Parameters

`authService` [IAuthService](./slottymedia.backend.services.interfaces.iauthservice.md)<br>

## Methods

### **RegisterAsync(String, String)**

```csharp
public Task<Session> RegisterAsync(string email, string password)
```

#### Parameters

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetCurrentSession()**

```csharp
public Session GetCurrentSession()
```

#### Returns

Session<br>
