# IFollowerUserRelationRepository

Namespace: SlottyMedia.Database.Repository.FollowerUserRelatioRepo

Interface for the Follower User Relation Repository.

```csharp
public interface IFollowerUserRelationRepository : SlottyMedia.Database.IDatabaseRepository`1[[SlottyMedia.Database.Daos.FollowerUserRelationDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Implements [IDatabaseRepository&lt;FollowerUserRelationDao&gt;](./slottymedia.database.idatabaserepository-1.md)

## Methods

### **GetCountOfUserFriends(Guid)**

Gets the count of friends for a specific user.

```csharp
Task<int> GetCountOfUserFriends(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The unique identifier of the user.

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains the count of friends.

### **GetFriends(Guid)**

Gets the list of friends for a specific user.

```csharp
Task<List<FollowerUserRelationDao>> GetFriends(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The unique identifier of the user.

#### Returns

[Task&lt;List&lt;FollowerUserRelationDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains the list of friends.

### **GetFollowsOfUserById(Guid)**

Gets a list of FollowerUserRelationDaos by userId

```csharp
Task<List<FollowerUserRelationDao>> GetFollowsOfUserById(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
UserId to retrieve its follows

#### Returns

[Task&lt;List&lt;FollowerUserRelationDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
List of FollowerUserRelationDaos matching the userid
