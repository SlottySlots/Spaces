# IForumRepository

Namespace: SlottyMedia.Database.Repository.ForumRepo

```csharp
public interface IForumRepository : SlottyMedia.Database.IDatabaseRepository`1[[SlottyMedia.Database.Daos.ForumDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Implements [IDatabaseRepository&lt;ForumDao&gt;](./slottymedia.database.idatabaserepository-1.md)

## Methods

### **GetElementById(String)**

```csharp
Task<ForumDao> GetElementById(string forumName)
```

#### Parameters

`forumName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;ForumDao&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
