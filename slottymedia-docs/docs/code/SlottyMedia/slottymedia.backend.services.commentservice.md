# CommentService

Namespace: SlottyMedia.Backend.Services

```csharp
public class CommentService : SlottyMedia.Backend.Services.Interfaces.ICommentService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [CommentService](./slottymedia.backend.services.commentservice.md)<br>
Implements [ICommentService](./slottymedia.backend.services.interfaces.icommentservice.md)

## Constructors

### **CommentService(ICommentRepository)**

```csharp
public CommentService(ICommentRepository commentRepository)
```

#### Parameters

`commentRepository` ICommentRepository<br>

## Methods

### **InsertComment(Guid, Guid, String)**

```csharp
public Task InsertComment(Guid creatorUserId, Guid postId, string content)
```

#### Parameters

`creatorUserId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`content` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UpdateComment(CommentDao)**

```csharp
public Task UpdateComment(CommentDao comment)
```

#### Parameters

`comment` CommentDao<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **DeleteComment(CommentDao)**

```csharp
public Task DeleteComment(CommentDao comment)
```

#### Parameters

`comment` CommentDao<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetCommentsInPost(Guid, Int32, Int32)**

```csharp
public Task<List<CommentDto>> GetCommentsInPost(Guid postId, int page, int pageSize)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Task&lt;List&lt;CommentDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
