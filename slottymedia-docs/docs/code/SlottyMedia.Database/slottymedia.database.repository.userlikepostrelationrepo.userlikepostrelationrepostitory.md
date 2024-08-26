# UserLikePostRelationRepostitory

Namespace: SlottyMedia.Database.Repository.UserLikePostRelationRepo

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

`daoHelper` [DaoHelper](./slottymedia.database.helper.daohelper.md)<br>

`databaseRepositroyHelper` [DatabaseRepositroyHelper](./slottymedia.database.helper.databaserepositroyhelper.md)<br>

## Methods

### **GetLikesForPost(Guid, Guid)**

```csharp
public Task<List<UserLikePostRelationDao>> GetLikesForPost(Guid userId, Guid postId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;List&lt;UserLikePostRelationDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
