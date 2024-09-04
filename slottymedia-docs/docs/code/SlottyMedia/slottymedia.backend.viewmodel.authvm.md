# AuthVm

Namespace: SlottyMedia.Backend.ViewModel

This class implements the IAuthVm interface

```csharp
public class AuthVm : SlottyMedia.Backend.ViewModel.Interfaces.IAuthVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [AuthVm](./slottymedia.backend.viewmodel.authvm.md)<br>
Implements [IAuthVm](./slottymedia.backend.viewmodel.interfaces.iauthvm.md)

## Constructors

### **AuthVm(IAuthService)**

This constructor initializes the AuthService

```csharp
public AuthVm(IAuthService authVmImpl)
```

#### Parameters

`authVmImpl` [IAuthService](./slottymedia.backend.services.interfaces.iauthservice.md)<br>

## Methods

### **GetCurrentSession()**

```csharp
public Session GetCurrentSession()
```

#### Returns

Session<br>
