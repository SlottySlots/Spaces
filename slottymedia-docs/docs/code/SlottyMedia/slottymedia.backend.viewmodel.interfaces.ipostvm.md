# IPostVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

The interface for post view model implementation.

```csharp
public interface IPostVm
```

## Methods

### **GetOwner(Guid)**

Retrieves the owner of a post by user ID.

```csharp
Task<UserDto> GetOwner(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user.

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains the user DTO.

### **GetCommentsCount(Guid)**

Retrieves the count of comments for a post.

```csharp
Task<int> GetCommentsCount(Guid postId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the post.

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains the count of comments.

### **GetUserInformation(Guid)**

Retrieves user information by user ID.

```csharp
Task<UserInformationDto> GetUserInformation(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user.

#### Returns

[Task&lt;UserInformationDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains the user information DTO.

### **GetLikes(Guid)**

Retrieves the list of likes for a post.

```csharp
Task<List<Guid>> GetLikes(Guid postId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the post.

#### Returns

[Task&lt;List&lt;Guid&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains the list of user IDs who liked the
 post.

### **AddLike(Guid, Guid)**

Adds a like to a post by a user.

```csharp
Task AddLike(Guid postId, Guid userId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the post.

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task that represents the asynchronous operation.

### **RemoveLike(Guid, Guid)**

Removes a like from a post by a user.

```csharp
Task RemoveLike(Guid postId, Guid userId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the post.

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task that represents the asynchronous operation.
