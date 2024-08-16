# LikeService

Namespace: SlottyMedia.Backend.Services

The service responsible for handling likes.

```csharp
public class LikeService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [LikeService](./slottymedia.backend.services.likeservice.md)

## Constructors

### **LikeService(IDatabaseActions)**

The constructor for the LikeService.

```csharp
public LikeService(IDatabaseActions databaseActions)
```

#### Parameters

`databaseActions` IDatabaseActions<br>

## Methods

### **InsertLike(Guid, Guid)**

Inserts a like for a given user and post.

```csharp
public Task<bool> InsertLike(Guid userId, Guid postId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user.

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the post.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a boolean indicating success.

### **DeleteLike(Guid, Guid)**

Deletes a like for a given user and post.

```csharp
public Task<bool> DeleteLike(Guid userId, Guid postId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user.

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the post.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a boolean indicating success.

### **GetLikesForPost(Guid)**

Retrieves a list of user IDs who liked a given post.

```csharp
public Task<List<Guid>> GetLikesForPost(Guid postId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the post.

#### Returns

[Task&lt;List&lt;Guid&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of user IDs.
