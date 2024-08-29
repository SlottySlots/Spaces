# ICommentRepository

Namespace: SlottyMedia.Database.Repository.CommentRepo

Interface for the Comment Repository.

```csharp
public interface ICommentRepository : SlottyMedia.Database.IDatabaseRepository`1[[SlottyMedia.Database.Daos.CommentDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Implements [IDatabaseRepository&lt;CommentDao&gt;](./slottymedia.database.idatabaserepository-1.md)

## Methods

### **GetCommentsInPost(Guid, Int32, Int32)**

```csharp
Task<List<CommentDao>> GetCommentsInPost(Guid postId, int page, int pageSize)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Task&lt;List&lt;CommentDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
