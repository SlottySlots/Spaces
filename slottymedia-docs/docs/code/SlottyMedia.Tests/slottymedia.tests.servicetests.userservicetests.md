# UserServiceTests

Namespace: SlottyMedia.Tests.ServiceTests

```csharp
public class UserServiceTests
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [UserServiceTests](./slottymedia.tests.servicetests.userservicetests.md)

## Constructors

### **UserServiceTests()**

```csharp
public UserServiceTests()
```

## Methods

### **Setup()**

```csharp
public void Setup()
```

### **TearDown()**

```csharp
public void TearDown()
```

### **CreateUser_ShouldReturnUser_WhenUserIsCreated()**

```csharp
public Task CreateUser_ShouldReturnUser_WhenUserIsCreated()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **CreateUser_ShouldThrowUserIudException_WhenDatabaseIudActionExceptionIsThrown()**

```csharp
public void CreateUser_ShouldThrowUserIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **CreateUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()**

```csharp
public void CreateUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
```

### **DeleteUser_ShouldReturnTrue_WhenUserIsDeleted()**

```csharp
public Task DeleteUser_ShouldReturnTrue_WhenUserIsDeleted()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **DeleteUser_ShouldThrowUserIudException_WhenDatabaseIudActionExceptionIsThrown()**

```csharp
public void DeleteUser_ShouldThrowUserIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **DeleteUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()**

```csharp
public void DeleteUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
```

### **GetUserById_ShouldReturnUser_WhenUserExists()**

```csharp
public Task GetUserById_ShouldReturnUser_WhenUserExists()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetUserById_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()**

```csharp
public void GetUserById_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetUserById_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()**

```csharp
public void GetUserById_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
```

### **GetUserByUsername_ShouldBeTrue_WhenUserExists()**

```csharp
public Task GetUserByUsername_ShouldBeTrue_WhenUserExists()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UpdateUser_ShouldReturnUpdatedUser_WhenUserIsUpdated()**

```csharp
public Task UpdateUser_ShouldReturnUpdatedUser_WhenUserIsUpdated()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UpdateUser_ShouldThrowUserIudException_WhenDatabaseIudActionExceptionIsThrown()**

```csharp
public void UpdateUser_ShouldThrowUserIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **UpdateUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()**

```csharp
public void UpdateUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
```

### **GetProfilePic_ShouldReturnProfilePic_WhenUserExists()**

```csharp
public Task GetProfilePic_ShouldReturnProfilePic_WhenUserExists()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetProfilePic_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()**

```csharp
public void GetProfilePic_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetProfilePic_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()**

```csharp
public void GetProfilePic_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
```

### **GetUser_ShouldReturnUserDto_WhenUserExists()**

```csharp
public Task GetUser_ShouldReturnUserDto_WhenUserExists()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetUser_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()**

```csharp
public void GetUser_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()**

```csharp
public void GetUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
```

### **GetFriends_ShouldReturnFriendsList_WhenUserHasFriends()**

```csharp
public Task GetFriends_ShouldReturnFriendsList_WhenUserHasFriends()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetFriends_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()**

```csharp
public void GetFriends_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetFriends_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()**

```csharp
public void GetFriends_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
```
