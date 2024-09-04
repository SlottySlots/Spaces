# PostVmImpl

Namespace: SlottyMedia.Backend.ViewModel

ViewModel for Post

```csharp
public class PostVmImpl : SlottyMedia.Backend.ViewModel.Interfaces.IPostVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PostVmImpl](./slottymedia.backend.viewmodel.postvmimpl.md)<br>
Implements [IPostVm](./slottymedia.backend.viewmodel.interfaces.ipostvm.md)

## Constructors

### **PostVmImpl(IUserService, ILikeService, ICommentService)**

The constructor for PostVmImpl

```csharp
public PostVmImpl(IUserService userService, ILikeService likeService, ICommentService commentService)
```

#### Parameters

`userService` [IUserService](./slottymedia.backend.services.interfaces.iuserservice.md)<br>

`likeService` [ILikeService](./slottymedia.backend.services.interfaces.ilikeservice.md)<br>

`commentService` [ICommentService](./slottymedia.backend.services.interfaces.icommentservice.md)<br>

## Methods

### **GetOwner(Guid)**

```csharp
public Task<UserDto> GetOwner(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetCommentsCount(Guid)**

```csharp
public Task<int> GetCommentsCount(Guid postId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetUserInformation(Guid)**

```csharp
public Task<UserInformationDto> GetUserInformation(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;UserInformationDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetLikes(Guid)**

```csharp
public Task<List<Guid>> GetLikes(Guid postId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;List&lt;Guid&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **AddLike(Guid, Guid)**

```csharp
public Task AddLike(Guid postId, Guid userId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **RemoveLike(Guid, Guid)**

```csharp
public Task RemoveLike(Guid postId, Guid userId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
