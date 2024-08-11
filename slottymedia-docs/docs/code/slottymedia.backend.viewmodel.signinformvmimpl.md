# SignInFormVmImpl

Namespace: SlottyMedia.Backend.ViewModel

```csharp
public class SignInFormVmImpl : SlottyMedia.Backend.ViewModel.Interfaces.ISignInFormVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [SignInFormVmImpl](./slottymedia.backend.viewmodel.signinformvmimpl.md)<br>
Implements [ISignInFormVm](./slottymedia.backend.viewmodel.interfaces.isigninformvm.md)

## Properties

### **Email**

```csharp
public string Email { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Password**

```csharp
public string Password { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **SignInFormVmImpl(IAuthService)**

```csharp
public SignInFormVmImpl(IAuthService authService)
```

#### Parameters

`authService` [IAuthService](./slottymedia.backend.services.interfaces.iauthservice.md)<br>

## Methods

### **SubmitSignInForm()**

```csharp
public Task SubmitSignInForm()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
