# ITopForumRepository

Namespace: SlottyMedia.Database.Repository.ForumRepo

Interface for the Top Forum Repository.

```csharp
public interface ITopForumRepository : SlottyMedia.Database.IDatabaseRepository`1[[SlottyMedia.Database.Daos.TopForumDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Implements [IDatabaseRepository&lt;TopForumDao&gt;](./slottymedia.database.idatabaserepository-1.md)

## Methods

### **DetermineRecentSpaces()**

Determines the recent spaces.

```csharp
Task<List<TopForumDao>> DetermineRecentSpaces()
```

#### Returns

[Task&lt;List&lt;TopForumDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of recent spaces.

### **GetTopForums()**

Gets the top forums.

```csharp
Task<List<TopForumDao>> GetTopForums()
```

#### Returns

[Task&lt;List&lt;TopForumDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of top forums.
