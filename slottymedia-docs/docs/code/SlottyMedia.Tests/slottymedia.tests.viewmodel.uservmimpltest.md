# UserVmImplTest

Namespace: SlottyMedia.Tests.Viewmodel

Unit tests for the UserVm class.

```csharp
public class UserVmImplTest
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [UserVmImplTest](./slottymedia.tests.viewmodel.uservmimpltest.md)

## Constructors

### **UserVmImplTest()**

```csharp
public UserVmImplTest()
```

## Methods

### **Setup()**

Initializes the test setup.

```csharp
public void Setup()
```

### **GetUserById_ReturnsUserDto_WhenUserExists()**

Tests that GetUserById returns a UserDto when the user exists.

```csharp
public Task GetUserById_ReturnsUserDto_WhenUserExists()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetUserById_ThrowsException_WhenUserServiceThrows()**

Tests that GetUserById throws an exception when the user service throws an exception.

```csharp
public void GetUserById_ThrowsException_WhenUserServiceThrows()
```

### **UpdateUser_CallsUserServiceUpdateUser()**

Tests that UpdateUser calls the UpdateUser method of the user service.

```csharp
public Task UpdateUser_CallsUserServiceUpdateUser()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UpdateUser_LogsError_WhenUserServiceThrows()**

Tests that UpdateUser logs an error when the user service throws an exception.

```csharp
public Task UpdateUser_LogsError_WhenUserServiceThrows()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
