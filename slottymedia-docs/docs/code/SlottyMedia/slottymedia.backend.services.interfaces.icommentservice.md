# ICommentService

Namespace: SlottyMedia.Backend.Services.Interfaces

The ICommentService interface is responsible for handling comment related operations.

```csharp
public interface ICommentService
```

## Methods

### **GetCommentById(Guid)**

Fetches a comment by its ID.

```csharp
Task<CommentDto> GetCommentById(Guid commentId)
```

#### Parameters

`commentId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The comment's ID

#### Returns

[Task&lt;CommentDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
The comment

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

[CommentIudException](./slottymedia.backend.exceptions.services.commentexceptions.commentiudexception.md)<br>
Thrown when an error occurs during Insert, Update, or Delete operations.

[CommentGeneralException](./slottymedia.backend.exceptions.services.commentexceptions.commentgeneralexception.md)<br>
Thrown when a general error occurs.

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

[CommentIudException](./slottymedia.backend.exceptions.services.commentexceptions.commentiudexception.md)<br>
Thrown when an error occurs during Insert, Update, or Delete operations.

[CommentGeneralException](./slottymedia.backend.exceptions.services.commentexceptions.commentgeneralexception.md)<br>
Thrown when a general error occurs.

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

[CommentIudException](./slottymedia.backend.exceptions.services.commentexceptions.commentiudexception.md)<br>
Thrown when an error occurs during Insert, Update, or Delete operations.

[CommentGeneralException](./slottymedia.backend.exceptions.services.commentexceptions.commentgeneralexception.md)<br>
Thrown when a general error occurs.

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
Task<IPage<CommentDto>> GetCommentsInPost(Guid postId, PageRequest pageRequest)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The post whose comments should be fetched

`pageRequest` PageRequest<br>
The page request

#### Returns

[Task&lt;IPage&lt;CommentDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A list containing the queried posts
