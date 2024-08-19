# SignInFormVmImpl

Namespace: SlottyMedia.Backend.ViewModel

Viewmodel used for the SignInForm of the Mainlayout

```csharp
public class SignInFormVmImpl : SlottyMedia.Backend.ViewModel.Interfaces.ISignInFormVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [SignInFormVmImpl](./slottymedia.backend.viewmodel.signinformvmimpl.md)<br>
Implements [ISignInFormVm](./slottymedia.backend.viewmodel.interfaces.isigninformvm.md)

## Properties

### **Email**

Corresponds to the email a user sets in the form. This is achieved via data-binding.

```csharp
public string Email { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Password**

Corresponds to the password a user sets in the form. This is achieved via data-binding.

```csharp
public string Password { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **LoginErrorMessage**

Field for setting a user exposing error message.

```csharp
public string LoginErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **SignInFormVmImpl(IAuthService)**

Standard Constructor used for dependency injection

```csharp
public SignInFormVmImpl(IAuthService authService)
```

#### Parameters

`authService` [IAuthService](./slottymedia.backend.services.interfaces.iauthservice.md)<br>
AuthService about to being injected

## Methods

### **SubmitSignInForm()**

Function called on submition of the SignInForm

```csharp
public Task SubmitSignInForm()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

#### Exceptions

[ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentexception)<br>
Exception thrown on a missing email / password

[UserAlreadySignedInException](./slottymedia.backend.exceptions.auth.useralreadysignedinexception.md)<br>
Exception thrown on a already authenticated user
