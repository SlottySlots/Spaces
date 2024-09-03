# IProfilePageVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

Interface used for profilepage viewmodel

```csharp
public interface IProfilePageVm
```

## Methods

### **GetUserInfo(Guid)**

Gets UserInformationDto based on provided userId

```csharp
Task<UserInformationDto> GetUserInfo(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
UserId to look up in db

#### Returns

[Task&lt;UserInformationDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
UserInformationDto?

### **UserFollowRelation(Guid, Guid)**

Checks whether a user follows another user based on their ids

```csharp
Task<Nullable<bool>> UserFollowRelation(Guid userIdToCheck, Guid userIdLoggedIn)
```

#### Parameters

`userIdToCheck` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
UserId to check

`userIdLoggedIn` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
UserId that may follow the one to check

#### Returns

[Task&lt;Nullable&lt;Boolean&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Boolean representing the state. Returns null if to check id is same as the logged in.

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

### **GetPostsByUserId(Guid, Int32, Int32)**

Gets posts of a user by their id and enables slicing via offsets

```csharp
Task<List<PostDto>> GetPostsByUserId(Guid userId, int startOfSet, int endOfSet)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
User that the posts belong to

`startOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Startindex of the posts sorted by date

`endOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Endindex of the posts sorted by data

#### Returns

[Task&lt;List&lt;PostDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
List of PostDtos
