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

### **CountCommentsInPost(Guid)**

```csharp
public Task<int> CountCommentsInPost(Guid postId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetCommentsInPost(Guid, PageRequest)**

```csharp
public Task<IPage<CommentDto>> GetCommentsInPost(Guid postId, PageRequest pageRequest)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`pageRequest` PageRequest<br>

#### Returns

[Task&lt;IPage&lt;CommentDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
