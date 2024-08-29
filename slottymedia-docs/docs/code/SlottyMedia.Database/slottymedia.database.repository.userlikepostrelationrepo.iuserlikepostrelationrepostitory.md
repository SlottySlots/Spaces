# IUserLikePostRelationRepostitory

Namespace: SlottyMedia.Database.Repository.UserLikePostRelationRepo

Interface for the User Like Post Relation Repository.

```csharp
public interface IUserLikePostRelationRepostitory : SlottyMedia.Database.IDatabaseRepository`1[[SlottyMedia.Database.Daos.UserLikePostRelationDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Implements [IDatabaseRepository&lt;UserLikePostRelationDao&gt;](./slottymedia.database.idatabaserepository-1.md)

## Methods

### **GetLikesForPost(Guid, Guid)**

Gets the likes for a specific post by a specific user.

```csharp
Task<List<UserLikePostRelationDao>> GetLikesForPost(Guid userId, Guid postId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The unique identifier of the user.

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The unique identifier of the post.

#### Returns

[Task&lt;List&lt;UserLikePostRelationDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of user like post
 relations.
