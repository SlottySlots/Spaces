# IForumSearchRepository

Namespace: SlottyMedia.Database.Repository

Interface for the Forum Search Repository.

```csharp
public interface IForumSearchRepository : SlottyMedia.Database.IDatabaseRepository`1[[SlottyMedia.Database.Daos.ForumDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Implements [IDatabaseRepository&lt;ForumDao&gt;](./slottymedia.database.idatabaserepository-1.md)

## Methods

### **GetForumsByTopic(String, Int32, Int32)**

Gets forums by a specific topic with pagination.

```csharp
Task<List<ForumDao>> GetForumsByTopic(string topic, int page, int pageSize)
```

#### Parameters

`topic` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The topic to search for.

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The page number.

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The size of the page.

#### Returns

[Task&lt;List&lt;ForumDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of forums.
