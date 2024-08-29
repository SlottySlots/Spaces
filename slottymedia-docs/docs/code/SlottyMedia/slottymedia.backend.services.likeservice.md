# LikeService

Namespace: SlottyMedia.Backend.Services

The service responsible for handling likes.

```csharp
public class LikeService : SlottyMedia.Backend.Services.Interfaces.ILikeService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [LikeService](./slottymedia.backend.services.likeservice.md)<br>
Implements [ILikeService](./slottymedia.backend.services.interfaces.ilikeservice.md)

## Constructors

### **LikeService(IUserLikePostRelationRepostitory)**

The constructor for the LikeService.

```csharp
public LikeService(IUserLikePostRelationRepostitory likeRepository)
```

#### Parameters

`likeRepository` IUserLikePostRelationRepostitory<br>

## Methods

### **InsertLike(Guid, Guid)**

```csharp
public Task<bool> InsertLike(Guid userId, Guid postId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **DeleteLike(Guid, Guid)**

```csharp
public Task<bool> DeleteLike(Guid userId, Guid postId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetLikesForPost(Guid)**

```csharp
public Task<List<Guid>> GetLikesForPost(Guid postId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;List&lt;Guid&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
