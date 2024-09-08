# PostVmImpl

Namespace: SlottyMedia.Backend.ViewModel

ViewModel for Post

```csharp
public class PostVmImpl : SlottyMedia.Backend.ViewModel.Interfaces.IPostVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PostVmImpl](./slottymedia.backend.viewmodel.postvmimpl.md)<br>
Implements [IPostVm](./slottymedia.backend.viewmodel.interfaces.ipostvm.md)

## Properties

### **CommentCount**

```csharp
public int CommentCount { get; private set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **InitLiked**

```csharp
public bool InitLiked { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **IsLoading**

```csharp
public bool IsLoading { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **LikeCount**

```csharp
public int LikeCount { get; private set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **UserInformation**

```csharp
public UserInformationDto UserInformation { get; private set; }
```

#### Property Value

[UserInformationDto](./slottymedia.backend.dtos.userinformationdto.md)<br>

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

### **Initialize(Guid, Guid)**

```csharp
public Task Initialize(Guid postId, Guid userId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LikePost(Guid, Guid)**

```csharp
public Task LikePost(Guid postId, Guid userId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetUserInformation(Guid, Boolean)**

```csharp
public Task GetUserInformation(Guid userId, bool firstRender)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`firstRender` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
