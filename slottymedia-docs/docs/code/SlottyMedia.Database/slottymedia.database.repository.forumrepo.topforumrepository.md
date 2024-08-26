# TopForumRepository

Namespace: SlottyMedia.Database.Repository.ForumRepo

```csharp
public class TopForumRepository : SlottyMedia.Database.Repository.DatabaseRepository`1[[SlottyMedia.Database.Daos.TopForumDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], SlottyMedia.Database.IDatabaseRepository`1[[SlottyMedia.Database.Daos.TopForumDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], ITopForumRepository
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DatabaseRepository&lt;TopForumDao&gt;](./slottymedia.database.repository.databaserepository-1.md) → [TopForumRepository](./slottymedia.database.repository.forumrepo.topforumrepository.md)<br>
Implements [IDatabaseRepository&lt;TopForumDao&gt;](./slottymedia.database.idatabaserepository-1.md), [ITopForumRepository](./slottymedia.database.repository.forumrepo.itopforumrepository.md)

## Constructors

### **TopForumRepository(Client, DaoHelper, DatabaseRepositroyHelper)**

Base constructor for the [TopForumRepository](./slottymedia.database.repository.forumrepo.topforumrepository.md).

```csharp
public TopForumRepository(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper)
```

#### Parameters

`client` Client<br>

`daoHelper` [DaoHelper](./slottymedia.database.helper.daohelper.md)<br>

`databaseRepositroyHelper` [DatabaseRepositroyHelper](./slottymedia.database.helper.databaserepositroyhelper.md)<br>

## Methods

### **DetermineRecentSpaces()**

```csharp
public Task<List<TopForumDao>> DetermineRecentSpaces()
```

#### Returns

[Task&lt;List&lt;TopForumDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetTopForums()**

```csharp
public Task<List<TopForumDao>> GetTopForums()
```

#### Returns

[Task&lt;List&lt;TopForumDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
