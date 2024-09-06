# IForumSearchRepository

Namespace: SlottyMedia.Database.Repository.SearchRepo

Interface for the Forum Search Repository.

```csharp
public interface IForumSearchRepository : SlottyMedia.Database.Repository.IDatabaseRepository`1[[SlottyMedia.Database.Daos.ForumDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Implements [IDatabaseRepository&lt;ForumDao&gt;](./slottymedia.database.repository.idatabaserepository-1.md)

## Methods

### **GetForumsByTopic(String, PageRequest)**

Gets forums by a specific topic with pagination.

```csharp
Task<IPage<ForumDao>> GetForumsByTopic(string topic, PageRequest pageRequest)
```

#### Parameters

`topic` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The topic to search for.

`pageRequest` [PageRequest](./slottymedia.database.pagination.pagerequest.md)<br>
The page request

#### Returns

[Task&lt;IPage&lt;ForumDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of forums.

#### Exceptions

[DatabaseMissingItemException](./slottymedia.database.exceptions.databasemissingitemexception.md)<br>
Thrown when the entity is not found in the database.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when an unexpected error occurs.
