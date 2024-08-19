# CommentService

Namespace: SlottyMedia.Backend.Services

The CommentService class is responsible for handling comment related operations.

```csharp
public class CommentService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [CommentService](./slottymedia.backend.services.commentservice.md)

## Constructors

### **CommentService(IDatabaseActions)**

```csharp
public CommentService(IDatabaseActions databaseActions)
```

#### Parameters

`databaseActions` IDatabaseActions<br>

## Methods

### **InsertComment(Guid, Guid, String)**

Inserts a new comment into the database.

```csharp
public Task<CommentDto> InsertComment(Guid creatorUserId, Guid postId, string content)
```

#### Parameters

`creatorUserId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`content` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;CommentDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the inserted CommentDto object.

#### Exceptions

T:SlottyMedia.Database.Exceptions.GeneralDatabaseException<br>
Throws an exception if an error occurs while inserting the comment.

### **UpdateComment(CommentDto)**

Updates an existing comment in the database.

```csharp
public Task<CommentDto> UpdateComment(CommentDto comment)
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
public Task DeleteComment(CommentDto comment)
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
