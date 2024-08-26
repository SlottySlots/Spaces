# SignUpServiceTest

Namespace: SlottyMedia.Tests.Auth

Tests the Service used for registering a new user in the database.

```csharp
public class SignUpServiceTest
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [SignUpServiceTest](./slottymedia.tests.auth.signupservicetest.md)

## Constructors

### **SignUpServiceTest()**

```csharp
public SignUpServiceTest()
```

## Methods

### **OneTimeSetup()**

Sets up the test fixture. Initializes the Supabase client and mocks the necessary services.

```csharp
public void OneTimeSetup()
```

### **Setup()**

Sets up each test. Generates a new UUID for the username, email, and password.

```csharp
public void Setup()
```

### **TearDown()**

Tears down each test. Resets the mocks and clears the session.

```csharp
public void TearDown()
```

### **SignUp_UserAlreadyExists()**

Tests that SignUp throws a UsernameAlreadyExistsException when the username already exists.

```csharp
public void SignUp_UserAlreadyExists()
```

### **SignUp()**

Tests that SignUp successfully registers a new user and sets the session.

```csharp
public Task SignUp()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
