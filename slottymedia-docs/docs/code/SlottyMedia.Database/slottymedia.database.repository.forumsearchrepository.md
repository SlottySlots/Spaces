# ForumSearchRepository

Namespace: SlottyMedia.Database.Repository

```csharp
public class ForumSearchRepository : DatabaseRepository`1, SlottyMedia.Database.IDatabaseRepository`1[[SlottyMedia.Database.Daos.ForumDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], IForumSearchRepository
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DatabaseRepository&lt;ForumDao&gt;](./slottymedia.database.repository.databaserepository-1.md) → [ForumSearchRepository](./slottymedia.database.repository.forumsearchrepository.md)<br>
Implements [IDatabaseRepository&lt;ForumDao&gt;](./slottymedia.database.idatabaserepository-1.md), [IForumSearchRepository](./slottymedia.database.repository.iforumsearchrepository.md)

## Constructors

### **ForumSearchRepository(Client, DaoHelper, DatabaseRepositroyHelper)**

Base constructor for the [ForumSearchRepository](./slottymedia.database.repository.forumsearchrepository.md).

```csharp
public ForumSearchRepository(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper)
```

#### Parameters

`client` Client<br>

`daoHelper` [DaoHelper](./slottymedia.database.helper.daohelper.md)<br>

`databaseRepositroyHelper` [DatabaseRepositroyHelper](./slottymedia.database.helper.databaserepositroyhelper.md)<br>

## Methods

### **GetForumsByTopic(String, Int32, Int32)**

```csharp
public Task<List<ForumDao>> GetForumsByTopic(string topic, int page, int pageSize)
```

#### Parameters

`topic` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Task&lt;List&lt;ForumDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
