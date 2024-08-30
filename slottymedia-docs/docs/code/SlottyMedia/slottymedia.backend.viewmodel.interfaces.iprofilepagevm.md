# IProfilePageVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

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
