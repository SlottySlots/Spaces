# SignupFormVmImpl

Namespace: SlottyMedia.Backend.ViewModel.Partial.SignUp

Viewmodel used to signing up a user.

```csharp
public class SignupFormVmImpl : ISignupFormVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [SignupFormVmImpl](./slottymedia.backend.viewmodel.partial.signup.signupformvmimpl.md)<br>
Implements [ISignupFormVm](./slottymedia.backend.viewmodel.partial.signup.isignupformvm.md)

## Properties

### **Username**

UserName a user can set. This is achieved via data-binding.

```csharp
public string Username { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **UsernameErrorMessage**

Error message exposed when a user isn't providing a username

```csharp
public string UsernameErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Email**

Email a user can set. This is achieved via data-binding.

```csharp
public string Email { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **EmailErrorMessage**

Error message exposed when a user isn't providing a email

```csharp
public string EmailErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Password**

Password a user can set. This is achieved via data-binding.

```csharp
public string Password { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **PasswordErrorMessage**

Error message exposed when a user isn't providing a password

```csharp
public string PasswordErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ServerErrorMessage**

Generic error message shown when server throws an unknown exception

```csharp
public string ServerErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **SignupFormVmImpl(ISignupService)**

Standard Constructor used for dependency injection

```csharp
public SignupFormVmImpl(ISignupService signupService)
```

#### Parameters

`signupService` [ISignupService](./slottymedia.backend.services.interfaces.isignupservice.md)<br>
Sign Up service for dependency injection

## Methods

### **SubmitSignupForm()**

Function called when user submits a form

```csharp
public Task SubmitSignupForm()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

#### Exceptions

[ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentexception)<br>
Thrown when user isn't providing all information needed for a signup
