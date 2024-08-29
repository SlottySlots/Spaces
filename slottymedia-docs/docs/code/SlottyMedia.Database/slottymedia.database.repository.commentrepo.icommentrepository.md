# ICommentRepository

Namespace: SlottyMedia.Database.Repository.CommentRepo

Interface for the Comment Repository.

```csharp
public interface ICommentRepository : SlottyMedia.Database.IDatabaseRepository`1[[SlottyMedia.Database.Daos.CommentDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Implements [IDatabaseRepository&lt;CommentDao&gt;](./slottymedia.database.idatabaserepository-1.md)

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

### **GetCommentsInPost(Guid, Int32, Int32)**

Fetches all comments in the given post. Utilizes pagination in order to limit
 the total number of queried posts: Only posts on the given page will be fetched.

```csharp
Task<List<CommentDao>> GetCommentsInPost(Guid postId, int page, int pageSize)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The post whose comments should be fetched

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The page to fetch (one-based)

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The size of each page (default is 10)

#### Returns

[Task&lt;List&lt;CommentDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A list containing the queried posts
