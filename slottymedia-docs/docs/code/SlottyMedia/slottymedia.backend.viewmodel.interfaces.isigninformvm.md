# ISignInFormVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

Interface used for dependency injection on the SignInFormVm

```csharp
public interface ISignInFormVm
```

## Properties

### **Email**

The form's email address

```csharp
public abstract string Email { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **EmailErrorMessage**

An optional error message that is caused by the email address

```csharp
public abstract string EmailErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Password**

The form's password

```csharp
public abstract string Password { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **PasswordErrorMessage**

An optional error message that is caused by the password

```csharp
public abstract string PasswordErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ServerErrorMessage**

An optional error message that is caused by some internal server error

```csharp
public abstract string ServerErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Methods

### **SubmitSignInForm()**

Attempts to submit the form. If this is successful, then the user was signed in
 successfully and cookies have been set. Otherwise, displays an appropriate error
 message.

```csharp
Task SubmitSignInForm()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
