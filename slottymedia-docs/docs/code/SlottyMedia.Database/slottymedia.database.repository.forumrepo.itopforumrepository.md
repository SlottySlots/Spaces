# ITopForumRepository

Namespace: SlottyMedia.Database.Repository.ForumRepo

```csharp
public interface ITopForumRepository : SlottyMedia.Database.IDatabaseRepository`1[[SlottyMedia.Database.Daos.TopForumDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Implements [IDatabaseRepository&lt;TopForumDao&gt;](./slottymedia.database.idatabaserepository-1.md)

## Methods

### **DetermineRecentSpaces()**

```csharp
Task<List<TopForumDao>> DetermineRecentSpaces()
```

#### Returns

[Task&lt;List&lt;TopForumDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetTopForums()**

```csharp
Task<List<TopForumDao>> GetTopForums()
```

#### Returns

[Task&lt;List&lt;TopForumDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
