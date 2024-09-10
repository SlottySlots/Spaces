# UserService

Namespace: SlottyMedia.Backend.Services

This class is the User Service. It is responsible for handling all User related operations.

```csharp
public class UserService : SlottyMedia.Backend.Services.Interfaces.IUserService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [UserService](./slottymedia.backend.services.userservice.md)<br>
Implements [IUserService](./slottymedia.backend.services.interfaces.iuserservice.md)

## Constructors

### **UserService(IUserRepository, IPostService, IFollowerUserRelationRepository)**

This constructor creates a new UserService object.

```csharp
public UserService(IUserRepository userRepository, IPostService postService, IFollowerUserRelationRepository followerUserRelationRepository)
```

#### Parameters

`userRepository` IUserRepository<br>
Repository used to fetch user table

`postService` [IPostService](./slottymedia.backend.services.interfaces.ipostservice.md)<br>
This parameter is used to interact with the post service

`followerUserRelationRepository` IFollowerUserRelationRepository<br>
Repository used to fetch follower user relations

## Methods

### **CreateUser(String, String, String, Guid, String, String)**

```csharp
public Task CreateUser(string userId, string username, string email, Guid roleId, string description, string profilePicture)
```

#### Parameters

`userId` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`roleId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`description` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`profilePicture` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **DeleteUser(UserDto)**

```csharp
public Task DeleteUser(UserDto user)
```

#### Parameters

`user` [UserDto](./slottymedia.backend.dtos.userdto.md)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetUserDtoById(Guid)**

```csharp
public Task<UserDto> GetUserDtoById(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **ExistsByUserName(String)**

```csharp
public Task<bool> ExistsByUserName(string username)
```

#### Parameters

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **UpdateUser(UserDao)**

```csharp
public Task UpdateUser(UserDao user)
```

#### Parameters

`user` UserDao<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UpdateUser(UserDto)**

```csharp
public Task UpdateUser(UserDto user)
```

#### Parameters

`user` [UserDto](./slottymedia.backend.dtos.userdto.md)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UserFollowRelation(Guid, Guid)**

```csharp
public Task<bool> UserFollowRelation(Guid userIdToCheck, Guid userIdLoggedIn)
```

#### Parameters

`userIdToCheck` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`userIdLoggedIn` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetProfilePic(Guid)**

```csharp
public Task<ProfilePicDto> GetProfilePic(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;ProfilePicDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetFriends(Guid)**

```csharp
public Task<FriendsOfUserDto> GetFriends(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;FriendsOfUserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetCountOfUserFriends(Guid)**

```csharp
public Task<int> GetCountOfUserFriends(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetCountOfUserSpaces(Guid)**

```csharp
public Task<int> GetCountOfUserSpaces(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetUserDaoById(Guid)**

```csharp
public Task<UserDao> GetUserDaoById(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;UserDao&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **FollowUserById(Guid, Guid)**

```csharp
public Task FollowUserById(Guid userIdFollows, Guid userIdToFollow)
```

#### Parameters

`userIdFollows` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`userIdToFollow` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UnfollowUserById(Guid, Guid)**

```csharp
public Task UnfollowUserById(Guid userIdFollows, Guid userIdToUnfollow)
```

#### Parameters

`userIdFollows` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`userIdToUnfollow` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetUserInfo(Guid, Boolean, Boolean)**

```csharp
public Task<UserInformationDto> GetUserInfo(Guid userId, bool fetchFriends, bool fetchSpaces)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`fetchFriends` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

`fetchSpaces` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

#### Returns

[Task&lt;UserInformationDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
