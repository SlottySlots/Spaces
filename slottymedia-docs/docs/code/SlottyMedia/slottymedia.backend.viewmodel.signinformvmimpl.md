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

```csharp
public string Email { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **EmailErrorMessage**

```csharp
public string EmailErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Password**

```csharp
public string Password { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **PasswordErrorMessage**

```csharp
public string PasswordErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ServerErrorMessage**

```csharp
public string ServerErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **SignInFormVmImpl(IAuthService, NavigationManager)**

Standard Constructor used for dependency injection

```csharp
public SignInFormVmImpl(IAuthService authService, NavigationManager navigationManager)
```

#### Parameters

`authService` [IAuthService](./slottymedia.backend.services.interfaces.iauthservice.md)<br>
AuthService about to being injected

`navigationManager` NavigationManager<br>

## Methods

### **SubmitSignInForm()**

```csharp
public Task SubmitSignInForm()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
