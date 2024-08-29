# FollowerUserRelationRepository

Namespace: SlottyMedia.Database.Repository.FollowerUserRelatioRepo

Repository class for managing follower-user relations in the database.

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
The Supabase client instance.

`daoHelper` [DaoHelper](./slottymedia.database.helper.daohelper.md)<br>
The data access object helper instance.

`databaseRepositroyHelper` [DatabaseRepositroyHelper](./slottymedia.database.helper.databaserepositroyhelper.md)<br>
The database repository helper instance.

## Methods

### **GetCountOfUserFriends(Guid)**

Gets the count of friends for a specific user.

```csharp
public Task<int> GetCountOfUserFriends(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user.

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains the count of friends.

### **GetFriends(Guid)**

Retrieves the list of friends for a specific user.

```csharp
public Task<List<FollowerUserRelationDao>> GetFriends(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user.

#### Returns

[Task&lt;List&lt;FollowerUserRelationDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of follower-user relations.

### **GetFollowsOfUserById(Guid)**

```csharp
public Task<List<FollowerUserRelationDao>> GetFollowsOfUserById(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;List&lt;FollowerUserRelationDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
