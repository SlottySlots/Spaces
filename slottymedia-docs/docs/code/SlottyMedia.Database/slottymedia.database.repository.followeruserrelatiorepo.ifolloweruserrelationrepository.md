# IFollowerUserRelationRepository

Namespace: SlottyMedia.Database.Repository.FollowerUserRelatioRepo

```csharp
public interface IFollowerUserRelationRepository : SlottyMedia.Database.IDatabaseRepository`1[[SlottyMedia.Database.Daos.FollowerUserRelationDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Implements [IDatabaseRepository&lt;FollowerUserRelationDao&gt;](./slottymedia.database.idatabaserepository-1.md)

## Methods

### **GetCountOfUserFriends(Guid)**

```csharp
Task<int> GetCountOfUserFriends(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetFriends(Guid)**

```csharp
Task<List<FollowerUserRelationDao>> GetFriends(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;List&lt;FollowerUserRelationDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
