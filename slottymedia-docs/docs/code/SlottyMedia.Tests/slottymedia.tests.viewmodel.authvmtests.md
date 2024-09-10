# AuthVmTests

Namespace: SlottyMedia.Tests.Viewmodel

Unit tests for the AuthVm class.

```csharp
public class AuthVmTests
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [AuthVmTests](./slottymedia.tests.viewmodel.authvmtests.md)

## Constructors

### **AuthVmTests()**

```csharp
public AuthVmTests()
```

## Methods

### **SetUp()**

Sets up the test environment by initializing mocks and the AuthVm instance.

```csharp
public void SetUp()
```

### **GetCurrentSession_ReturnsCurrentSession()**

Tests that GetCurrentSession method returns the current session.

```csharp
public void GetCurrentSession_ReturnsCurrentSession()
```

### **GetCurrentUserId_ReturnsUserIdWhenSessionExists()**

Tests that GetCurrentUserId method returns the user ID when a session exists.

```csharp
public void GetCurrentUserId_ReturnsUserIdWhenSessionExists()
```

### **GetCurrentUserId_ThrowsExceptionWhenSessionIsNull()**

Tests that GetCurrentUserId method throws an exception when the session is null.

```csharp
public void GetCurrentUserId_ThrowsExceptionWhenSessionIsNull()
```

### **IsAuthenticated_ReturnsTrueWhenAuthenticated()**

Tests that IsAuthenticated method returns true when the user is authenticated.

```csharp
public void IsAuthenticated_ReturnsTrueWhenAuthenticated()
```

### **IsAuthenticated_ReturnsFalseWhenNotAuthenticated()**

Tests that IsAuthenticated method returns false when the user is not authenticated.

```csharp
public void IsAuthenticated_ReturnsFalseWhenNotAuthenticated()
```
