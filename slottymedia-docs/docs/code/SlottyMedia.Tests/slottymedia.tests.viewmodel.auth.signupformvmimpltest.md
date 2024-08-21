# SignUpFormVmImplTest

Namespace: SlottyMedia.Tests.Viewmodel.auth

This tests the viewmodel user in the Register.razor page

```csharp
public class SignUpFormVmImplTest
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [SignUpFormVmImplTest](./slottymedia.tests.viewmodel.auth.signupformvmimpltest.md)

## Constructors

### **SignUpFormVmImplTest()**

```csharp
public SignUpFormVmImplTest()
```

## Methods

### **OneTimeSetup()**

Sets up the necessary mocks and initializes the service before any tests are run.

```csharp
public void OneTimeSetup()
```

### **TearDown()**

Resets the mocks after each test.

```csharp
public void TearDown()
```

### **SubmitSignUpForm_UsernameNotProvided()**

Tests that an ArgumentException is thrown when the username is not provided.

```csharp
public void SubmitSignUpForm_UsernameNotProvided()
```

### **SubmitSignUpForm_EmailNotProvided()**

Tests that an ArgumentException is thrown when the email is not provided.

```csharp
public void SubmitSignUpForm_EmailNotProvided()
```

### **SubmitSignUpForm_PasswordNotProvided()**

Tests that an ArgumentException is thrown when the password is not provided.

```csharp
public void SubmitSignUpForm_PasswordNotProvided()
```

### **SubmitSignUpForm_UserNameAlreadyExists()**

Tests that a UsernameAlreadyExistsException is thrown when the username already exists.

```csharp
public void SubmitSignUpForm_UserNameAlreadyExists()
```

### **SubmitSignUpForm_EmailAlreadyExists()**

Tests that an EmailAlreadyExistsException is thrown when the email already exists.

```csharp
public void SubmitSignUpForm_EmailAlreadyExists()
```
