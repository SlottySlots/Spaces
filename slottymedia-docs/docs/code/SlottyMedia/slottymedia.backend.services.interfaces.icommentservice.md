# ICommentService

Namespace: SlottyMedia.Backend.Services.Interfaces

The ICommentService interface is responsible for handling comment related operations.

```csharp
public interface ICommentService
```

## Methods

### **InsertComment(Guid, Guid, String)**

Inserts a new comment into the database.

```csharp
Task InsertComment(Guid creatorUserId, Guid postId, string content)
```

#### Parameters

`creatorUserId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user who created the comment.

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the post to which the comment belongs.

`content` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The content of the comment.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
Returns the inserted CommentDto object.

#### Exceptions

T:SlottyMedia.Database.Exceptions.GeneralDatabaseException<br>
Throws an exception if an error occurs while inserting the comment.

### **UpdateComment(CommentDao)**

Updates an existing comment in the database.

```csharp
Task UpdateComment(CommentDao comment)
```

#### Parameters

`comment` CommentDao<br>
The CommentDto object containing the updated comment details.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
Returns the updated CommentDto object.

#### Exceptions

T:SlottyMedia.Database.Exceptions.GeneralDatabaseException<br>
Throws an exception if an error occurs while updating the comment.

### **DeleteComment(CommentDao)**

Deletes a comment from the database.

```csharp
Task DeleteComment(CommentDao comment)
```

#### Parameters

`comment` CommentDao<br>
The CommentDto object containing the comment details.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
Returns a Task representing the asynchronous operation.

#### Exceptions

T:SlottyMedia.Database.Exceptions.GeneralDatabaseException<br>
Throws an exception if an error occurs while deleting the comment.

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
Task<List<CommentDto>> GetCommentsInPost(Guid postId, int page, int pageSize)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The post whose comments should be fetched

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The page to fetch (one-based)

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The size of each page (default is 10)

#### Returns

[Task&lt;List&lt;CommentDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A list containing the queried posts
