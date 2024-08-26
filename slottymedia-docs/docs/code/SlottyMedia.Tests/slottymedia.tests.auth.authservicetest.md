# AuthServiceTest

Namespace: SlottyMedia.Tests.Auth

Tests the non-supabase reliant business logic of AuthService.

```csharp
public class AuthServiceTest
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [AuthServiceTest](./slottymedia.tests.auth.authservicetest.md)

## Constructors

### **AuthServiceTest()**

```csharp
public AuthServiceTest()
```

## Methods

### **OneTimeSetup()**

Sets up the test fixture. Initializes the Supabase client and mocks the cookie service.

```csharp
public void OneTimeSetup()
```

### **Setup()**

Sets up each test. Generates a new UUID for the username and email.

```csharp
public void Setup()
```

### **TearDown()**

Tears down each test. Resets the cookie service mock and clears the session.

```csharp
public void TearDown()
```

### **SaveSessionAsync_TokenNotProvided()**

Tests that SaveSessionAsync throws a TokenNotProvidedException when the token is not provided.

```csharp
public void SaveSessionAsync_TokenNotProvided()
```

### **SaveSessionAsync()**

Tests that SaveSessionAsync saves the session and sets the cookies correctly.

```csharp
public void SaveSessionAsync()
```

### **RestoreSessionAsync_TokenNotProvided()**

Tests that RestoreSessionAsync throws a TokenNotProvidedException when the token is not provided.

```csharp
public void RestoreSessionAsync_TokenNotProvided()
```

### **SignOut_CookiesNotRemoved()**

Tests that SignOut does not remove the cookies.

```csharp
public void SignOut_CookiesNotRemoved()
```
