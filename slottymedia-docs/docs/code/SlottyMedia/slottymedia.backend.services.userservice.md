# UserService

Namespace: SlottyMedia.Backend.Services

This class is the User Service. It is responsible for handling all User related operations.

```csharp
public class UserService : SlottyMedia.Backend.Services.Interfaces.IUserService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [UserService](./slottymedia.backend.services.userservice.md)<br>
Implements [IUserService](./slottymedia.backend.services.interfaces.iuserservice.md)

## Constructors

### **UserService(IDatabaseActions, IPostService)**

This constructor creates a new UserService object.

```csharp
public UserService(IDatabaseActions databaseActions, IPostService postService)
```

#### Parameters

`databaseActions` IDatabaseActions<br>
This parameter is used to interact with the database

`postService` [IPostService](./slottymedia.backend.services.interfaces.ipostservice.md)<br>
This parameter is used to interact with the post service

## Methods

### **CreateUser(String, String, String, Guid, String, String)**

```csharp
public Task<UserDto> CreateUser(string userId, string username, string email, Guid roleId, string description, string profilePicture)
```

#### Parameters

`userId` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`roleId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`description` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`profilePicture` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **DeleteUser(UserDto)**

```csharp
public Task<bool> DeleteUser(UserDto user)
```

#### Parameters

`user` [UserDto](./slottymedia.backend.dtos.userdto.md)<br>

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetUserById(Guid)**

```csharp
public Task<UserDto> GetUserById(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **CheckIfUserExistsByUserName(String)**

```csharp
public Task<bool> CheckIfUserExistsByUserName(string username)
```

#### Parameters

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **UpdateUser(UserDao)**

```csharp
public Task<UserDto> UpdateUser(UserDao user)
```

#### Parameters

`user` UserDao<br>

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **UpdateUser(UserDto)**

```csharp
public Task<UserDto> UpdateUser(UserDto user)
```

#### Parameters

`user` [UserDto](./slottymedia.backend.dtos.userdto.md)<br>

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetUserBy(Nullable&lt;Guid&gt;, String, String)**

```csharp
public Task<UserDao> GetUserBy(Nullable<Guid> userID, string username, string email)
```

#### Parameters

`userID` [Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;UserDao&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetProfilePic(Guid)**

```csharp
public Task<ProfilePicDto> GetProfilePic(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;ProfilePicDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetUser(Guid, Int32)**

```csharp
public Task<UserDto> GetUser(Guid userId, int recentForums)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`recentForums` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

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

Gets all spaces a user has wrote in

```csharp
public Task<int> GetCountOfUserSpaces(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
User from which it should be retrieved

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the amount of spaces as task
