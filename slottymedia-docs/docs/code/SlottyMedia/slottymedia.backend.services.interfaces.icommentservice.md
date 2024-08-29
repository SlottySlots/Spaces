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

### **GetCommentsInPost(Guid, Int32, Int32)**

```csharp
Task<List<CommentDto>> GetCommentsInPost(Guid postId, int page, int pageSize)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Task&lt;List&lt;CommentDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
