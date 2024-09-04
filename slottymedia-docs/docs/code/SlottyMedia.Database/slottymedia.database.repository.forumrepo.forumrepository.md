# ForumRepository

Namespace: SlottyMedia.Database.Repository.ForumRepo

Repository class for managing forums in the database.

```csharp
public class ForumRepository : SlottyMedia.Database.Repository.DatabaseRepository`1[[SlottyMedia.Database.Daos.ForumDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], SlottyMedia.Database.Repository.IDatabaseRepository`1[[SlottyMedia.Database.Daos.ForumDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], IForumRepository
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DatabaseRepository&lt;ForumDao&gt;](./slottymedia.database.repository.databaserepository-1.md) → [ForumRepository](./slottymedia.database.repository.forumrepo.forumrepository.md)<br>
Implements [IDatabaseRepository&lt;ForumDao&gt;](./slottymedia.database.repository.idatabaserepository-1.md), [IForumRepository](./slottymedia.database.repository.forumrepo.iforumrepository.md)

## Constructors

### **ForumRepository(Client, DaoHelper, DatabaseRepositroyHelper)**

Base constructor for the [ForumRepository](./slottymedia.database.repository.forumrepo.forumrepository.md).

```csharp
public ForumRepository(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper)
```

#### Parameters

`client` Client<br>
The Supabase client instance.

`daoHelper` [DaoHelper](./slottymedia.database.helper.daohelper.md)<br>
The data access object helper instance.

`databaseRepositroyHelper` [DatabaseRepositroyHelper](./slottymedia.database.helper.databaserepositroyhelper.md)<br>
The database repository helper instance.

## Methods

### **GetForumByName(String)**

```csharp
public Task<ForumDao> GetForumByName(string name)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;ForumDao&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
