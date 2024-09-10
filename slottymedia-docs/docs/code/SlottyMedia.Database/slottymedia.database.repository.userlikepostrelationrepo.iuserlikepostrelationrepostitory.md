# IUserLikePostRelationRepostitory

Namespace: SlottyMedia.Database.Repository.UserLikePostRelationRepo

Interface for the User Like Post Relation Repository.

```csharp
public interface IUserLikePostRelationRepostitory : SlottyMedia.Database.Repository.IDatabaseRepository`1[[SlottyMedia.Database.Daos.UserLikePostRelationDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Implements [IDatabaseRepository&lt;UserLikePostRelationDao&gt;](./slottymedia.database.repository.idatabaserepository-1.md)

## Methods

### **GetLikesForPost(Guid)**

Gets the likes for a specific post.

```csharp
Task<List<UserLikePostRelationDao>> GetLikesForPost(Guid postId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The unique identifier of the post.

#### Returns

[Task&lt;List&lt;UserLikePostRelationDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of user like post
 relations.

#### Exceptions

[DatabaseMissingItemException](./slottymedia.database.exceptions.databasemissingitemexception.md)<br>
Thrown when the entity is not found in the database.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when an unexpected error occurs.

### **GetLikeByUserIdAndPostId(Guid, Guid)**

Gets the like for a specific post by a specific user.

```csharp
Task<UserLikePostRelationDao> GetLikeByUserIdAndPostId(Guid userId, Guid postId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The unique identifier of the user.

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The unique identifier of the post.

#### Returns

[Task&lt;UserLikePostRelationDao&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains the user like post relation.

#### Exceptions

[DatabaseMissingItemException](./slottymedia.database.exceptions.databasemissingitemexception.md)<br>
Thrown when the entity is not found in the database.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when an unexpected error occurs.
