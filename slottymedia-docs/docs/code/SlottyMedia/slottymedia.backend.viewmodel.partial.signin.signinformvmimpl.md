# SignInFormVmImpl

Namespace: SlottyMedia.Backend.ViewModel.Partial.SignIn

Viewmodel used for the SignInForm of the Mainlayout

```csharp
public class SignInFormVmImpl : ISignInFormVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [SignInFormVmImpl](./slottymedia.backend.viewmodel.partial.signin.signinformvmimpl.md)<br>
Implements [ISignInFormVm](./slottymedia.backend.viewmodel.partial.signin.isigninformvm.md)

## Properties

### **Email**

Email a user used to sign in

```csharp
public string Email { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **EmailErrorMessage**

Error message shown when a error with the email occurs

```csharp
public string EmailErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Password**

Password used by a user

```csharp
public string Password { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **PasswordErrorMessage**

Error message shown when a error with the password occurs

```csharp
public string PasswordErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ServerErrorMessage**

Error message for internal server errors

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
NavigationManager used to reload the page.

## Methods

### **SubmitSignInForm()**

Event setting the session for a user. This is triggered whenever the form is submitted

```csharp
public Task SubmitSignInForm()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
