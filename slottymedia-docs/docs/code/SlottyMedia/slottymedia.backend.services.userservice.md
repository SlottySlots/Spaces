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

This method creates a new User object in the database and returns the created object. This method does not check if
 the User already exists.

```csharp
public Task<UserDto> CreateUser(string userId, string username, string email, Guid roleId, string description, string profilePicture)
```

#### Parameters

`userId` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The ID we get from the Supabase Authentication Service

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Username of the User

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`roleId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`description` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Description of the User (optional)

`profilePicture` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Profile Picture of the User (optional)

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the created UserDto. If it was unable to create a User, it will throw an exception.

### **DeleteUser(UserDto)**

This method deletes the given User object from the database.

```csharp
public Task<bool> DeleteUser(UserDto user)
```

#### Parameters

`user` [UserDto](./slottymedia.backend.dtos.userdto.md)<br>
The UserDto object to delete

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns true if the User was successfully deleted, otherwise false.

### **GetUserById(Guid)**

This method returns a User object from the database based on the given userId.

```csharp
public Task<UserDto> GetUserById(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the User to get from the Database

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the UserDto object from the Database. If no User was found, it will throw an exception.

### **CheckIfUserExistsByUserName(String)**

Gets a UserDTO by its username (usernames are duplicate free)

```csharp
public Task<bool> CheckIfUserExistsByUserName(string username)
```

#### Parameters

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Username used for retrieving a user

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
The corresponding UserDTO

### **UpdateUser(UserDao)**

This method updates the given User object in the database and returns the updated object.

```csharp
public Task<UserDto> UpdateUser(UserDao user)
```

#### Parameters

`user` UserDao<br>
The updated UserDto

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the updated UserDto. If it was unable to update the User, it will throw an exception.

### **GetUserBy(Nullable&lt;Guid&gt;, String, String)**

Retrieves a user from the database based on the provided criteria (ID, username, or email).

```csharp
public Task<UserDao> GetUserBy(Nullable<Guid> userID, string username, string email)
```

#### Parameters

`userID` [Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The ID of the user to retrieve (optional).

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The username of the user to retrieve (optional).

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The email of the user to retrieve (optional).

#### Returns

[Task&lt;UserDao&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the UserDao object if found, otherwise null.

#### Exceptions

[UserNotFoundException](./slottymedia.backend.exceptions.services.userexceptions.usernotfoundexception.md)<br>
Thrown when no user is found with the provided criteria.

[UserGeneralException](./slottymedia.backend.exceptions.services.userexceptions.usergeneralexception.md)<br>
Thrown when a general database error occurs.

### **GetProfilePic(Guid)**

This method returns the Profile Picture of the given User.

```csharp
public Task<ProfilePicDto> GetProfilePic(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the User

#### Returns

[Task&lt;ProfilePicDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the ProfilePicDto containing the Profile Picture of the User.

#### Exceptions

[UserNotFoundException](./slottymedia.backend.exceptions.services.userexceptions.usernotfoundexception.md)<br>
Throws an exception if the user is not found

### **GetUser(Guid, Int32)**

This method returns a UserDto object from the database based on the given userId.

```csharp
public Task<UserDto> GetUser(Guid userId, int recentForums)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user

`recentForums` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The maximum number of recent forums to retrieve

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the UserDto object with recent forums.

### **GetFriends(Guid)**

This method returns a list of friends for the given user.

```csharp
public Task<FriendsOfUserDto> GetFriends(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user

#### Returns

[Task&lt;FriendsOfUserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns a FriendsOfUserDto object containing the list of friends.

### **GetCountOfUserFriends(Guid)**

This method retrieves the count of friends for a given user from the database.

```csharp
public Task<int> GetCountOfUserFriends(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user whose friends count is to be retrieved.

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the count of friends for the specified user.

#### Exceptions

[UserGeneralException](./slottymedia.backend.exceptions.services.userexceptions.usergeneralexception.md)<br>
Thrown when a general database error occurs while fetching the friends count.

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
