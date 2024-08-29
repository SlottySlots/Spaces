# UserLikePostRelationRepostitory

Namespace: SlottyMedia.Database.Repository.UserLikePostRelationRepo

Repository class for managing user like post relations in the database.

```csharp
public class UserLikePostRelationRepostitory : SlottyMedia.Database.Repository.DatabaseRepository`1[[SlottyMedia.Database.Daos.UserLikePostRelationDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], SlottyMedia.Database.IDatabaseRepository`1[[SlottyMedia.Database.Daos.UserLikePostRelationDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], IUserLikePostRelationRepostitory
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DatabaseRepository&lt;UserLikePostRelationDao&gt;](./slottymedia.database.repository.databaserepository-1.md) → [UserLikePostRelationRepostitory](./slottymedia.database.repository.userlikepostrelationrepo.userlikepostrelationrepostitory.md)<br>
Implements [IDatabaseRepository&lt;UserLikePostRelationDao&gt;](./slottymedia.database.idatabaserepository-1.md), [IUserLikePostRelationRepostitory](./slottymedia.database.repository.userlikepostrelationrepo.iuserlikepostrelationrepostitory.md)

## Constructors

### **UserLikePostRelationRepostitory(Client, DaoHelper, DatabaseRepositroyHelper)**

Base constructor for the [UserLikePostRelationRepostitory](./slottymedia.database.repository.userlikepostrelationrepo.userlikepostrelationrepostitory.md).

```csharp
public UserLikePostRelationRepostitory(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper)
```

#### Parameters

`client` Client<br>
The Supabase client instance.

`daoHelper` [DaoHelper](./slottymedia.database.helper.daohelper.md)<br>
The data access object helper instance.

`databaseRepositroyHelper` [DatabaseRepositroyHelper](./slottymedia.database.helper.databaserepositroyhelper.md)<br>
The database repository helper instance.

## Methods

### **GetLikesForPost(Guid, Guid)**

Gets the likes for a specific post by a specific user.

```csharp
public Task<List<UserLikePostRelationDao>> GetLikesForPost(Guid userId, Guid postId)
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
