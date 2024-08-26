# FollowerUserRelationRepository

Namespace: SlottyMedia.Database.Repository.FollowerUserRelatioRepo

```csharp
public class FollowerUserRelationRepository : SlottyMedia.Database.Repository.DatabaseRepository`1[[SlottyMedia.Database.Daos.FollowerUserRelationDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], SlottyMedia.Database.IDatabaseRepository`1[[SlottyMedia.Database.Daos.FollowerUserRelationDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], IFollowerUserRelationRepository
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DatabaseRepository&lt;FollowerUserRelationDao&gt;](./slottymedia.database.repository.databaserepository-1.md) → [FollowerUserRelationRepository](./slottymedia.database.repository.followeruserrelatiorepo.followeruserrelationrepository.md)<br>
Implements [IDatabaseRepository&lt;FollowerUserRelationDao&gt;](./slottymedia.database.idatabaserepository-1.md), [IFollowerUserRelationRepository](./slottymedia.database.repository.followeruserrelatiorepo.ifolloweruserrelationrepository.md)

## Constructors

### **FollowerUserRelationRepository(Client, DaoHelper, DatabaseRepositroyHelper)**

Base constructor for the [FollowerUserRelationRepository](./slottymedia.database.repository.followeruserrelatiorepo.followeruserrelationrepository.md).

```csharp
public FollowerUserRelationRepository(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper)
```

#### Parameters

`client` Client<br>

`daoHelper` [DaoHelper](./slottymedia.database.helper.daohelper.md)<br>

`databaseRepositroyHelper` [DatabaseRepositroyHelper](./slottymedia.database.helper.databaserepositroyhelper.md)<br>

## Methods

### **GetCountOfUserFriends(Guid)**

```csharp
public Task<int> GetCountOfUserFriends(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetFriends(Guid)**

```csharp
public Task<List<FollowerUserRelationDao>> GetFriends(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;List&lt;FollowerUserRelationDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
