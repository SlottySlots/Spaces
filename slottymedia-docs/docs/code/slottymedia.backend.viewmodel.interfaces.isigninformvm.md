# ISignInFormVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

```csharp
public interface ISignInFormVm
```

## Properties

### **Email**

Email to authenticate a user

```csharp
public abstract string Email { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Password**

Password to authenticate a user

```csharp
public abstract string Password { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **LoginErrorMessage**

```csharp
public abstract string LoginErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Methods

### **SubmitSignInForm()**

Used to sign in a user by email and password

```csharp
Task SubmitSignInForm()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
