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
Task<CommentDto> InsertComment(Guid creatorUserId, Guid postId, string content)
```

#### Parameters

`creatorUserId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user who created the comment.

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the post to which the comment belongs.

`content` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The content of the comment.

#### Returns

[Task&lt;CommentDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the inserted CommentDto object.

#### Exceptions

T:SlottyMedia.Database.Exceptions.GeneralDatabaseException<br>
Throws an exception if an error occurs while inserting the comment.

### **UpdateComment(CommentDto)**

Updates an existing comment in the database.

```csharp
Task<CommentDto> UpdateComment(CommentDto comment)
```

#### Parameters

`comment` [CommentDto](./slottymedia.backend.dtos.commentdto.md)<br>
The CommentDto object containing the updated comment details.

#### Returns

[Task&lt;CommentDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the updated CommentDto object.

#### Exceptions

T:SlottyMedia.Database.Exceptions.GeneralDatabaseException<br>
Throws an exception if an error occurs while updating the comment.

### **DeleteComment(CommentDto)**

Deletes a comment from the database.

```csharp
Task DeleteComment(CommentDto comment)
```

#### Parameters

`comment` [CommentDto](./slottymedia.backend.dtos.commentdto.md)<br>
The CommentDto object containing the comment details.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
Returns a Task representing the asynchronous operation.

#### Exceptions

T:SlottyMedia.Database.Exceptions.GeneralDatabaseException<br>
Throws an exception if an error occurs while deleting the comment.
