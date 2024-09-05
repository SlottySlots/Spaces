# IUserService

Namespace: SlottyMedia.Backend.Services.Interfaces

This interface defines the methods which can be used to interact with the User table in the database.

```csharp
public interface IUserService
```

## Methods

### **GetUserDtoById(Guid)**

This method returns a User object from the database based on the given userId.

```csharp
Task<UserDto> GetUserDtoById(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The UserID inside the Database

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
UserDao

#### Exceptions

[UserNotFoundException](./slottymedia.backend.exceptions.services.userexceptions.usernotfoundexception.md)<br>
Thrown when the user is not found.

[UserGeneralException](./slottymedia.backend.exceptions.services.userexceptions.usergeneralexception.md)<br>
Thrown when a general error occurs.

### **CheckIfUserExistsByUserName(String)**

Fetches a user by their username. Returns null if no user was found.

```csharp
Task<bool> CheckIfUserExistsByUserName(string username)
```

#### Parameters

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The user's username

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
The queried user or null if no such user was found

#### Exceptions

[UserGeneralException](./slottymedia.backend.exceptions.services.userexceptions.usergeneralexception.md)<br>
Thrown when a general error occurs.

### **CreateUser(String, String, String, Guid, String, String)**

This method creates a new User object in the database and returns the created object.

```csharp
Task CreateUser(string userId, string username, string email, Guid roleId, string description, string profilePicture)
```

#### Parameters

`userId` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The UserID from the Authentication Service

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Username, which the User set himself

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Email of the User

`roleId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The Role ID of the User

`description` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Description about the User

`profilePicture` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The ProfilePicture

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
UserDto

#### Exceptions

[UserIudException](./slottymedia.backend.exceptions.services.userexceptions.useriudexception.md)<br>
Thrown when an error occurs during Insert, Update, or Delete operations.

[UserGeneralException](./slottymedia.backend.exceptions.services.userexceptions.usergeneralexception.md)<br>
Thrown when a general error occurs.

### **UpdateUser(UserDao)**

This method updates the given User object in the database and returns the updated object.

```csharp
Task UpdateUser(UserDao user)
```

#### Parameters

`user` UserDao<br>
The User object

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
UserDao

#### Exceptions

[UserIudException](./slottymedia.backend.exceptions.services.userexceptions.useriudexception.md)<br>
Thrown when an error occurs during Insert, Update, or Delete operations.

[UserGeneralException](./slottymedia.backend.exceptions.services.userexceptions.usergeneralexception.md)<br>
Thrown when a general error occurs.

### **DeleteUser(UserDto)**

This method deletes the given User object from the database.

```csharp
Task DeleteUser(UserDto user)
```

#### Parameters

`user` [UserDto](./slottymedia.backend.dtos.userdto.md)<br>
The User Object

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
Return if the User got deleted or not

#### Exceptions

[UserIudException](./slottymedia.backend.exceptions.services.userexceptions.useriudexception.md)<br>
Thrown when an error occurs during Insert, Update, or Delete operations.

[UserGeneralException](./slottymedia.backend.exceptions.services.userexceptions.usergeneralexception.md)<br>
Thrown when a general error occurs.

### **GetProfilePic(Guid)**

This method returns the Profile Picture of the given User.

```csharp
Task<ProfilePicDto> GetProfilePic(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the User

#### Returns

[Task&lt;ProfilePicDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the Profile Picture of the User

#### Exceptions

[UserNotFoundException](./slottymedia.backend.exceptions.services.userexceptions.usernotfoundexception.md)<br>
Thrown when the user is not found.

[UserGeneralException](./slottymedia.backend.exceptions.services.userexceptions.usergeneralexception.md)<br>
Thrown when a general error occurs.

### **GetUser(Guid, Int32)**

This method returns a UserDto object from the database based on the given userId.

```csharp
Task<UserDto> GetUser(Guid userId, int limit)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The Id of the user

`limit` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The maximum number of recent forums to retrieve

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the UserDto object

#### Exceptions

[UserNotFoundException](./slottymedia.backend.exceptions.services.userexceptions.usernotfoundexception.md)<br>
Thrown when the user is not found.

[UserGeneralException](./slottymedia.backend.exceptions.services.userexceptions.usergeneralexception.md)<br>
Thrown when a general error occurs.

### **GetFriends(Guid)**

This method returns a list of friends for the given user.

```csharp
Task<FriendsOfUserDto> GetFriends(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user

#### Returns

[Task&lt;FriendsOfUserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns a FriendsOfUserDto object containing the list of friends

#### Exceptions

[UserNotFoundException](./slottymedia.backend.exceptions.services.userexceptions.usernotfoundexception.md)<br>
Thrown when the user is not found.

[UserGeneralException](./slottymedia.backend.exceptions.services.userexceptions.usergeneralexception.md)<br>
Thrown when a general error occurs.

### **GetCountOfUserFriends(Guid)**

This method retrieves the count of friends for a given user from the database.

```csharp
Task<int> GetCountOfUserFriends(Guid userId)
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
Task<int> GetCountOfUserSpaces(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
User from which it should be retrieved

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the amount of spaces as task

#### Exceptions

[UserGeneralException](./slottymedia.backend.exceptions.services.userexceptions.usergeneralexception.md)<br>
Thrown when a general error occurs.

### **UpdateUser(UserDto)**

Updates the given UserDto object in the database and returns the updated object.

```csharp
Task UpdateUser(UserDto user)
```

#### Parameters

`user` [UserDto](./slottymedia.backend.dtos.userdto.md)<br>
The UserDto object to be updated.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task that represents the asynchronous operation. The task result contains the updated UserDto object.

#### Exceptions

[UserIudException](./slottymedia.backend.exceptions.services.userexceptions.useriudexception.md)<br>
Thrown when an error occurs during Insert, Update, or Delete operations.

[UserGeneralException](./slottymedia.backend.exceptions.services.userexceptions.usergeneralexception.md)<br>
Thrown when a general error occurs.

### **UserFollowRelation(Guid, Guid)**

Checks whether a user follows another user based on their ids

```csharp
Task<bool> UserFollowRelation(Guid userIdToCheck, Guid userIdLoggedIn)
```

#### Parameters

`userIdToCheck` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
UserId to check

`userIdLoggedIn` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
UserId that may follow the one to check

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Boolean representing the state

#### Exceptions

[UserGeneralException](./slottymedia.backend.exceptions.services.userexceptions.usergeneralexception.md)<br>
Thrown when a general error occurs.

### **GetUserDaoById(Guid)**

Gets a user dao based on the user id

```csharp
Task<UserDao> GetUserDaoById(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
Id to retrieve

#### Returns

[Task&lt;UserDao&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns a user dao

#### Exceptions

[UserNotFoundException](./slottymedia.backend.exceptions.services.userexceptions.usernotfoundexception.md)<br>
Thrown when the user is not found.

[UserGeneralException](./slottymedia.backend.exceptions.services.userexceptions.usergeneralexception.md)<br>
Thrown when a general error occurs.

### **FollowUserById(Guid, Guid)**

Method used to follow a user by id

```csharp
Task FollowUserById(Guid userIdFollows, Guid userIdToFollow)
```

#### Parameters

`userIdFollows` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The user that tries to follow another

`userIdToFollow` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The user that the user tries to follow

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
Task

#### Exceptions

[UserIudException](./slottymedia.backend.exceptions.services.userexceptions.useriudexception.md)<br>
Thrown when an error occurs during Insert, Update, or Delete operations.

[UserGeneralException](./slottymedia.backend.exceptions.services.userexceptions.usergeneralexception.md)<br>
Thrown when a general error occurs.

### **UnfollowUserById(Guid, Guid)**

Method used to unfollow a user by id

```csharp
Task UnfollowUserById(Guid userIdFollows, Guid userIdToUnfollow)
```

#### Parameters

`userIdFollows` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The user that tries to unfollow another

`userIdToUnfollow` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The user that the user tries to unfollow

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
Task

#### Exceptions

[UserIudException](./slottymedia.backend.exceptions.services.userexceptions.useriudexception.md)<br>
Thrown when an error occurs during Insert, Update, or Delete operations.

[UserGeneralException](./slottymedia.backend.exceptions.services.userexceptions.usergeneralexception.md)<br>
Thrown when a general error occurs.

### **GetUserInfo(Guid)**

This sets a dto holding information about the current user in order to show the current users infos in the profile
 card

```csharp
Task<UserInformationDto> GetUserInfo(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
User from which the dto should be retrieved

#### Returns

[Task&lt;UserInformationDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns a task of type UserInformationDto. The dto is used to update the state in the view.
