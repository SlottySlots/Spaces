# ForumSearchRepository

Namespace: SlottyMedia.Database.Repository.SearchRepo

Repository class for managing forum searches in the database.

```csharp
public class ForumSearchRepository : SlottyMedia.Database.Repository.DatabaseRepository`1[[SlottyMedia.Database.Daos.ForumDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], SlottyMedia.Database.Repository.IDatabaseRepository`1[[SlottyMedia.Database.Daos.ForumDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], IForumSearchRepository
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DatabaseRepository&lt;ForumDao&gt;](./slottymedia.database.repository.databaserepository-1.md) → [ForumSearchRepository](./slottymedia.database.repository.searchrepo.forumsearchrepository.md)<br>
Implements [IDatabaseRepository&lt;ForumDao&gt;](./slottymedia.database.repository.idatabaserepository-1.md), [IForumSearchRepository](./slottymedia.database.repository.searchrepo.iforumsearchrepository.md)

## Constructors

### **ForumSearchRepository(Client, DaoHelper, DatabaseRepositroyHelper)**

Base constructor for the [ForumSearchRepository](./slottymedia.database.repository.searchrepo.forumsearchrepository.md).

```csharp
public ForumSearchRepository(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper)
```

#### Parameters

`client` Client<br>
The Supabase client instance.

`daoHelper` [DaoHelper](./slottymedia.database.helper.daohelper.md)<br>
The data access object helper instance.

`databaseRepositroyHelper` [DatabaseRepositroyHelper](./slottymedia.database.helper.databaserepositroyhelper.md)<br>
The database repository helper instance.

## Methods

### **GetForumsByTopic(String, PageRequest)**

```csharp
public Task<IPage<ForumDao>> GetForumsByTopic(string topic, PageRequest pageRequest)
```

#### Parameters

`topic` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`pageRequest` [PageRequest](./slottymedia.database.pagination.pagerequest.md)<br>

#### Returns

[Task&lt;IPage&lt;ForumDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
