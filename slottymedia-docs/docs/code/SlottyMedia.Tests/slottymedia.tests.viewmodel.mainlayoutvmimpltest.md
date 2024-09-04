# MainLayoutVmImplTest

Namespace: SlottyMedia.Tests.Viewmodel

Unit tests for the MainLayoutVmImpl class.

```csharp
public class MainLayoutVmImplTest
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [MainLayoutVmImplTest](./slottymedia.tests.viewmodel.mainlayoutvmimpltest.md)

## Constructors

### **MainLayoutVmImplTest()**

```csharp
public MainLayoutVmImplTest()
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

### **RestoreSessionOnInit_ReturnsSession()**

Tests that a session is restored on initialization.

```csharp
public void RestoreSessionOnInit_ReturnsSession()
```

### **RestoreSessionOnInit_NoSessionRestoredReturnsNull()**

Tests that no session is restored and returns null.

```csharp
public void RestoreSessionOnInit_NoSessionRestoredReturnsNull()
```

### **SetUserInfo_SessionNotSetReturnsNull()**

Tests that SetUserInfo returns null when no session is set.

```csharp
public void SetUserInfo_SessionNotSetReturnsNull()
```

### **SetUserInfo_CorruptUserDaoReturnsNull()**

Tests that SetUserInfo returns null when the user DAO is corrupt.

```csharp
public void SetUserInfo_CorruptUserDaoReturnsNull()
```

### **SetUserInfo_ReturnsUserInfoDto()**

Tests that SetUserInfo returns a UserInfoDto when the user DAO is valid.

```csharp
public void SetUserInfo_ReturnsUserInfoDto()
```

### **PersistUserAvatarInDb_ReturnsNullOnNoSession()**

Tests that PersistUserAvatarInDb returns null when no session is set.

```csharp
public void PersistUserAvatarInDb_ReturnsNullOnNoSession()
```

### **PersistsUserAvatarInDb()**

Tests that PersistUserAvatarInDb persists the user avatar in the database.

```csharp
public Task PersistsUserAvatarInDb()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **RestoreSessionOnInit_LogsMessageOnNoSession()**

Tests that RestoreSessionOnInit logs a message when no session is restored.

```csharp
public void RestoreSessionOnInit_LogsMessageOnNoSession()
```

### **SetUserInfo_LogsErrorOnException()**

Tests that SetUserInfo logs an error when an exception is thrown.

```csharp
public void SetUserInfo_LogsErrorOnException()
```
