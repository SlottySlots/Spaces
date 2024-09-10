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

### **CreateUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()**

Tests if CreateUser method throws UserGeneralException when GeneralDatabaseException is thrown.

```csharp
public void CreateUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
```

### **DeleteUser_ShouldThrowUserIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests if DeleteUser method throws UserIudException when DatabaseIudActionException is thrown.

```csharp
public void DeleteUser_ShouldThrowUserIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **GetUserById_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()**

Tests if GetUserDtoById method throws UserNotFoundException when DatabaseMissingItemException is thrown.

```csharp
public void GetUserById_ShouldThrowUserNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetUserById_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()**

Tests if GetUserDtoById method throws UserGeneralException when GeneralDatabaseException is thrown.

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

### **GetUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()**

Tests if GetUser method throws UserGeneralException when GeneralDatabaseException is thrown.

```csharp
public void GetUser_ShouldThrowUserGeneralException_WhenDatabaseExceptionIsThrown()
```

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

### **GetCountOfUserFriends_ThrowsUserGeneralException_OnGeneralDatabaseException()**

Tests if GetCountOfUserFriends method throws UserGeneralException when GeneralDatabaseException is thrown.

```csharp
public void GetCountOfUserFriends_ThrowsUserGeneralException_OnGeneralDatabaseException()
```

### **GetCountOfUserFriends_ThrowsUserGeneralException_OnUnexpectedException()**

Tests if GetCountOfUserFriends method throws UserGeneralException when an unexpected exception is thrown.

```csharp
public void GetCountOfUserFriends_ThrowsUserGeneralException_OnUnexpectedException()
```

### **GetCountOfUserSpaces()**

Tests if GetCountOfUserSpaces method returns the correct count of user spaces.

```csharp
public Task GetCountOfUserSpaces()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **FollowUserById_ShouldFollowUser()**

Tests if FollowUserById method successfully follows a user.

```csharp
public Task FollowUserById_ShouldFollowUser()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **FollowUserById_ShouldThrowUserIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests if FollowUserById method throws UserIudException when DatabaseIudActionException is thrown.

```csharp
public void FollowUserById_ShouldThrowUserIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **FollowUserById_ShouldThrowUserGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests if FollowUserById method throws UserGeneralException when GeneralDatabaseException is thrown.

```csharp
public void FollowUserById_ShouldThrowUserGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```

### **UnfollowUserById_ShouldUnfollowUser()**

Tests if UnfollowUserById method successfully unfollows a user.

```csharp
public Task UnfollowUserById_ShouldUnfollowUser()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UnfollowUserById_ShouldThrowUserIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests if UnfollowUserById method throws UserIudException when DatabaseIudActionException is thrown.

```csharp
public void UnfollowUserById_ShouldThrowUserIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **UnfollowUserById_ShouldThrowUserGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests if UnfollowUserById method throws UserGeneralException when GeneralDatabaseException is thrown.

```csharp
public void UnfollowUserById_ShouldThrowUserGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```
