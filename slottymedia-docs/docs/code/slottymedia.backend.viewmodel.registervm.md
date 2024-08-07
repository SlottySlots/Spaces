# RegisterVm

Namespace: SlottyMedia.Backend.ViewModel

Implementation of the IRegisterVM interface. It provides the logic of registering a user in supabase

```csharp
public class RegisterVm : SlottyMedia.Backend.ViewModel.Interfaces.IRegisterVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [RegisterVm](./slottymedia.backend.viewmodel.registervm.md)<br>
Implements [IRegisterVm](./slottymedia.backend.viewmodel.interfaces.iregistervm.md)

## Constructors

### **RegisterVm(IAuthService)**

Constructor for creating the register viewmodel

```csharp
public RegisterVm(IAuthService authService)
```

#### Parameters

`authService` [IAuthService](./slottymedia.backend.services.interfaces.iauthservice.md)<br>
Authentication service for methods shared in different authentication viewmodel

#### Exceptions

[ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception)<br>
Provides a exception if dependency injection fails

## Methods

### **RegisterAsync(String, String)**

Registers a user by using the SignUp method in _authService

```csharp
public Task<Session> RegisterAsync(string email, string password)
```

#### Parameters

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Email used to register a user

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Password used to register a user

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the new session of the registered user

### **GetCurrentSession()**

Gets the current session if existing

```csharp
public Session GetCurrentSession()
```

#### Returns

Session<br>
Returns the session set on client and server-side otherwise return null
