# IForumRepository

Namespace: SlottyMedia.Database.Repository.ForumRepo

Interface for the Forum Repository.

```csharp
public interface IForumRepository : SlottyMedia.Database.Repository.IDatabaseRepository`1[[SlottyMedia.Database.Daos.ForumDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Implements [IDatabaseRepository&lt;ForumDao&gt;](./slottymedia.database.repository.idatabaserepository-1.md)

## Methods

### **GetForumByName(String)**

Fetches a forum by its name.

```csharp
Task<ForumDao> GetForumByName(string name)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The forum's name

#### Returns

[Task&lt;ForumDao&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
The forum
