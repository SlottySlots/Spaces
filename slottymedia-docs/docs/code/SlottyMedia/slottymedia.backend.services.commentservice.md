# CommentService

Namespace: SlottyMedia.Backend.Services

```csharp
public class CommentService : SlottyMedia.Backend.Services.Interfaces.ICommentService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [CommentService](./slottymedia.backend.services.commentservice.md)<br>
Implements [ICommentService](./slottymedia.backend.services.interfaces.icommentservice.md)

## Constructors

### **CommentService(IDatabaseActions)**

```csharp
public CommentService(IDatabaseActions databaseActions)
```

#### Parameters

`databaseActions` IDatabaseActions<br>

## Methods

### **InsertComment(Guid, Guid, String)**

```csharp
public Task<CommentDto> InsertComment(Guid creatorUserId, Guid postId, string content)
```

#### Parameters

`creatorUserId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`content` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;CommentDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **UpdateComment(CommentDto)**

```csharp
public Task<CommentDto> UpdateComment(CommentDto comment)
```

#### Parameters

`comment` [CommentDto](./slottymedia.backend.dtos.commentdto.md)<br>

#### Returns

[Task&lt;CommentDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **DeleteComment(CommentDto)**

```csharp
public Task DeleteComment(CommentDto comment)
```

#### Parameters

`comment` [CommentDto](./slottymedia.backend.dtos.commentdto.md)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
