# ProfilePageVmImplTests

Namespace: SlottyMedia.Tests.Viewmodel

Unit tests for the  class.

```csharp
public class ProfilePageVmImplTests
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ProfilePageVmImplTests](./slottymedia.tests.viewmodel.profilepagevmimpltests.md)

## Constructors

### **ProfilePageVmImplTests()**

```csharp
public ProfilePageVmImplTests()
```

## Methods

### **SetUp()**

Sets up the test environment before each test.
 Initializes the mocks and the view model instance.

```csharp
public void SetUp()
```

### **GetUserInfo_ShouldReturnUserInformationDto_WhenUserExists()**

Tests that GetUserInfo returns a UserInformationDto when the user exists.

```csharp
public Task GetUserInfo_ShouldReturnUserInformationDto_WhenUserExists()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task representing the asynchronous operation.

### **GetUserInfo_ShouldReturnNull_WhenUserDoesNotExist()**

Tests that GetUserInfo returns null when the user does not exist.

```csharp
public Task GetUserInfo_ShouldReturnNull_WhenUserDoesNotExist()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task representing the asynchronous operation.

### **UserFollowRelation_ShouldReturnTrue_WhenUserFollowsAnother()**

Tests that UserFollowRelation returns true when a user follows another user.

```csharp
public Task UserFollowRelation_ShouldReturnTrue_WhenUserFollowsAnother()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task representing the asynchronous operation.

### **UserFollowRelation_ShouldReturnFalse_WhenUserDoesNotFollowAnother()**

Tests that UserFollowRelation returns false when a user does not follow another user.

```csharp
public Task UserFollowRelation_ShouldReturnFalse_WhenUserDoesNotFollowAnother()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task representing the asynchronous operation.

### **UserFollowRelation_ShouldReturnNull_WhenUserIdsAreSame()**

Tests that UserFollowRelation returns null when the user IDs are the same.

```csharp
public Task UserFollowRelation_ShouldReturnNull_WhenUserIdsAreSame()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task representing the asynchronous operation.

### **FollowUserById_ShouldCallFollowUserByIdOnUserService()**

Tests that FollowUserById calls FollowUserById on the user service.

```csharp
public Task FollowUserById_ShouldCallFollowUserByIdOnUserService()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task representing the asynchronous operation.

### **UnfollowUserById_ShouldCallUnfollowUserByIdOnUserService()**

Tests that UnfollowUserById calls UnfollowUserById on the user service.

```csharp
public Task UnfollowUserById_ShouldCallUnfollowUserByIdOnUserService()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task representing the asynchronous operation.

### **GetPostsByUserId_ShouldReturnListOfPostDtos()**

Tests that GetPostsByUserId returns a list of PostDto.

```csharp
public Task GetPostsByUserId_ShouldReturnListOfPostDtos()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task representing the asynchronous operation.
