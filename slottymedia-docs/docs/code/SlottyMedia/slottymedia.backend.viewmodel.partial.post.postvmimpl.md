# PostVmImpl

Namespace: SlottyMedia.Backend.ViewModel.Partial.Post

ViewModel for Post

```csharp
public class PostVmImpl : IPostVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PostVmImpl](./slottymedia.backend.viewmodel.partial.post.postvmimpl.md)<br>
Implements [IPostVm](./slottymedia.backend.viewmodel.partial.post.ipostvm.md)

## Properties

### **AuthPrincipalId**

```csharp
public Nullable<Guid> AuthPrincipalId { get; private set; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **IsPostLiked**

```csharp
public bool IsPostLiked { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **IsLoading**

```csharp
public bool IsLoading { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **PostDto**

```csharp
public PostDto PostDto { get; private set; }
```

#### Property Value

[PostDto](./slottymedia.backend.dtos.postdto.md)<br>

### **CommentCount**

```csharp
public int CommentCount { get; private set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

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

### **PostVmImpl(IPostService, IUserService, ILikeService, ICommentService, IAuthService, NavigationManager)**

The constructor for PostVmImpl

```csharp
public PostVmImpl(IPostService postService, IUserService userService, ILikeService likeService, ICommentService commentService, IAuthService authService, NavigationManager navigationManager)
```

#### Parameters

`postService` [IPostService](./slottymedia.backend.services.interfaces.ipostservice.md)<br>

`userService` [IUserService](./slottymedia.backend.services.interfaces.iuserservice.md)<br>

`likeService` [ILikeService](./slottymedia.backend.services.interfaces.ilikeservice.md)<br>

`commentService` [ICommentService](./slottymedia.backend.services.interfaces.icommentservice.md)<br>

`authService` [IAuthService](./slottymedia.backend.services.interfaces.iauthservice.md)<br>

`navigationManager` NavigationManager<br>

## Methods

### **Initialize(Guid, Action)**

```csharp
public Task Initialize(Guid postId, Action onStateChanged)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`onStateChanged` [Action](https://docs.microsoft.com/en-us/dotnet/api/system.action)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LikeThisPost()**

```csharp
public Task LikeThisPost()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GoToPostPage()**

```csharp
public void GoToPostPage()
```

### **GoToProfilePage()**

```csharp
public void GoToProfilePage()
```
