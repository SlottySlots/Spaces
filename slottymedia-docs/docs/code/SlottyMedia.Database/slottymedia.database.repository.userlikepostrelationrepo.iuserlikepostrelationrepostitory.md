# IUserLikePostRelationRepostitory

Namespace: SlottyMedia.Database.Repository.UserLikePostRelationRepo

```csharp
public interface IUserLikePostRelationRepostitory : SlottyMedia.Database.IDatabaseRepository`1[[SlottyMedia.Database.Daos.UserLikePostRelationDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Implements [IDatabaseRepository&lt;UserLikePostRelationDao&gt;](./slottymedia.database.idatabaserepository-1.md)

## Methods

### **GetLikesForPost(Guid, Guid)**

```csharp
Task<List<UserLikePostRelationDao>> GetLikesForPost(Guid userId, Guid postId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;List&lt;UserLikePostRelationDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
