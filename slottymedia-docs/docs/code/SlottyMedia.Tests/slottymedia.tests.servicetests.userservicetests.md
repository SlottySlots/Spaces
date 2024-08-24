# UserServiceTests

Namespace: SlottyMedia.Tests.ServiceTests

Tests the UserService used for user related actions in the database.

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

The setup method that is called before each test.

```csharp
public void Setup()
```

### **TearDown()**

The teardown method that is called after each test.

```csharp
public void TearDown()
```

### **CreateUser_ShouldReturnUser_WhenUserIsCreated()**

Tests if CreateUser method returns the created user correctly.

```csharp
public Task CreateUser_ShouldReturnUser_WhenUserIsCreated()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **CreateUser_ShouldThrowUserIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests if CreateUser method throws UserIudException when DatabaseIudActionException is thrown.

```csharp
public void CreateUser_ShouldThrowUserIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **CreateUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()**

Tests if CreateUser method throws UserGeneralException when GeneralDatabaseException is thrown.

```csharp
public void CreateUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
```

### **DeleteUser_ShouldReturnTrue_WhenUserIsDeleted()**

Tests if DeleteUser method returns true when user is deleted successfully.

```csharp
public Task DeleteUser_ShouldReturnTrue_WhenUserIsDeleted()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **DeleteUser_ShouldThrowUserIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests if DeleteUser method throws UserIudException when DatabaseIudActionException is thrown.

```csharp
public void DeleteUser_ShouldThrowUserIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **DeleteUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()**

Tests if DeleteUser method throws UserGeneralException when GeneralDatabaseException is thrown.

```csharp
public void DeleteUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
```

### **GetUserById_ShouldReturnUser_WhenUserExists()**

Tests if GetUserById method returns the user correctly when user exists.

```csharp
public Task GetUserById_ShouldReturnUser_WhenUserExists()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetUserById_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()**

Tests if GetUserById method throws UserNotFoundException when DatabaseMissingItemException is thrown.

```csharp
public void GetUserById_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetUserById_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()**

Tests if GetUserById method throws UserGeneralException when GeneralDatabaseException is thrown.

```csharp
public void GetUserById_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
```

### **GetUserByUsername_ShouldBeTrue_WhenUserExists()**

Tests if CheckIfUserExistsByUserName method returns true when user exists.

```csharp
public Task GetUserByUsername_ShouldBeTrue_WhenUserExists()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UpdateUser_ShouldReturnUpdatedUser_WhenUserIsUpdated()**

Tests if UpdateUser method returns the updated user correctly.

```csharp
public Task UpdateUser_ShouldReturnUpdatedUser_WhenUserIsUpdated()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UpdateUser_ShouldThrowUserIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests if UpdateUser method throws UserIudException when DatabaseIudActionException is thrown.

```csharp
public void UpdateUser_ShouldThrowUserIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **UpdateUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()**

Tests if UpdateUser method throws UserGeneralException when GeneralDatabaseException is thrown.

```csharp
public void UpdateUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
```

### **GetProfilePic_ShouldReturnProfilePic_WhenUserExists()**

Tests if GetProfilePic method returns the profile picture correctly when user exists.

```csharp
public Task GetProfilePic_ShouldReturnProfilePic_WhenUserExists()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetProfilePic_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()**

Tests if GetProfilePic method throws UserNotFoundException when DatabaseMissingItemException is thrown.

```csharp
public void GetProfilePic_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetProfilePic_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()**

Tests if GetProfilePic method throws UserGeneralException when GeneralDatabaseException is thrown.

```csharp
public void GetProfilePic_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
```

### **GetUser_ShouldReturnUserDto_WhenUserExists()**

Tests if GetUser method returns the user DTO correctly when user exists.

```csharp
public Task GetUser_ShouldReturnUserDto_WhenUserExists()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetUser_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()**

Tests if GetUser method throws UserNotFoundException when DatabaseMissingItemException is thrown.

```csharp
public void GetUser_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()**

Tests if GetUser method throws UserGeneralException when GeneralDatabaseException is thrown.

```csharp
public void GetUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
```

### **GetFriends_ShouldReturnFriendsList_WhenUserHasFriends()**

Tests if GetFriends method returns the friends list correctly when user has friends.

```csharp
public Task GetFriends_ShouldReturnFriendsList_WhenUserHasFriends()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetFriends_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()**

Tests if GetFriends method throws UserNotFoundException when DatabaseMissingItemException is thrown.

```csharp
public void GetFriends_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetFriends_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()**

Tests if GetFriends method throws UserGeneralException when GeneralDatabaseException is thrown.

```csharp
public void GetFriends_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
```

### **GetCountOfUserFriends_ReturnsCorrectCount()**

Tests if GetCountOfUserFriends method returns the correct count of user friends.

```csharp
public Task GetCountOfUserFriends_ReturnsCorrectCount()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

**Remarks:**

This test ensures that the GetCountOfUserFriends method correctly returns the expected count of friends for a user.

### **GetCountOfUserFriends_ThrowsUserGeneralException_OnGeneralDatabaseException()**

Tests if GetCountOfUserFriends method throws UserGeneralException when GeneralDatabaseException is thrown.

```csharp
public void GetCountOfUserFriends_ThrowsUserGeneralException_OnGeneralDatabaseException()
```

**Remarks:**

This test ensures that the GetCountOfUserFriends method throws a UserGeneralException when a
 GeneralDatabaseException occurs.

### **GetCountOfUserFriends_ThrowsUserGeneralException_OnUnexpectedException()**

Tests if GetCountOfUserFriends method throws UserGeneralException when an unexpected exception is thrown.

```csharp
public void GetCountOfUserFriends_ThrowsUserGeneralException_OnUnexpectedException()
```

**Remarks:**

This test ensures that the GetCountOfUserFriends method throws a UserGeneralException when an unexpected exception
 occurs.

### **GetCountOfUserSpaces()**

Tests if GetCountOfUserSpaces method returns the correct count of user spaces.

```csharp
public Task GetCountOfUserSpaces()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
