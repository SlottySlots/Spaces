# SignInFormVmImplTest

Namespace: SlottyMedia.Tests.Viewmodel.auth

Unit tests for the SignInFormVmImpl class.

```csharp
public class SignInFormVmImplTest
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [SignInFormVmImplTest](./slottymedia.tests.viewmodel.auth.signinformvmimpltest.md)

## Constructors

### **SignInFormVmImplTest()**

```csharp
public SignInFormVmImplTest()
```

## Methods

### **OneTimeSetup()**

Sets up the test environment before any tests are run.

```csharp
public void OneTimeSetup()
```

### **TearDown()**

Resets the mocks after each test.

```csharp
public void TearDown()
```

### **SubmitSignInForm_WhenEmailEmpty_ShouldDisplayErrorMessage(String, String)**

Tests that an error message is displayed when the email is empty or null.

```csharp
public Task SubmitSignInForm_WhenEmailEmpty_ShouldDisplayErrorMessage(string email, string password)
```

#### Parameters

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The email input.

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The password input.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **SubmitSignInForm_WhenPasswordEmpty_ShouldDisplayErrorMessage(String, String)**

Tests that an error message is displayed when the password is empty or null.

```csharp
public Task SubmitSignInForm_WhenPasswordEmpty_ShouldDisplayErrorMessage(string email, string password)
```

#### Parameters

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The email input.

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The password input.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
