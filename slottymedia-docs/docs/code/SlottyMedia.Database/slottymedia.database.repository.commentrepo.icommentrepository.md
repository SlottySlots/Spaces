# ICommentRepository

Namespace: SlottyMedia.Database.Repository.CommentRepo

Interface for the Comment Repository.

```csharp
public interface ICommentRepository : SlottyMedia.Database.Repository.IDatabaseRepository`1[[SlottyMedia.Database.Daos.CommentDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Implements [IDatabaseRepository&lt;CommentDao&gt;](./slottymedia.database.repository.idatabaserepository-1.md)

## Methods

### **CountCommentsInPost(Guid)**

Counts the total number of comments in the given post.

```csharp
Task<int> CountCommentsInPost(Guid postId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The post to query

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
The total number of comments

### **GetCommentsInPost(Guid, PageRequest)**

Fetches all comments in the given post. Utilizes pagination in order to limit
 the total number of queried posts: Only posts on the given page will be fetched.

```csharp
Task<IPage<CommentDao>> GetCommentsInPost(Guid postId, PageRequest pageRequest)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The post whose comments should be fetched

`pageRequest` [PageRequest](./slottymedia.database.pagination.pagerequest.md)<br>
The page request

#### Returns

[Task&lt;IPage&lt;CommentDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A list containing the queried posts
