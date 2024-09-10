# PostPageVmImpl

Namespace: SlottyMedia.Backend.ViewModel.Pages.Post

```csharp
public class PostPageVmImpl : IPostPageVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PostPageVmImpl](./slottymedia.backend.viewmodel.pages.post.postpagevmimpl.md)<br>
Implements [IPostPageVm](./slottymedia.backend.viewmodel.pages.post.ipostpagevm.md)

## Properties

### **IsLoadingPage**

```csharp
public bool IsLoadingPage { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **IsLoadingComments**

```csharp
public bool IsLoadingComments { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Post**

```csharp
public PostDto Post { get; private set; }
```

#### Property Value

[PostDto](./slottymedia.backend.dtos.postdto.md)<br>

### **Comments**

```csharp
public IPage<CommentDto> Comments { get; private set; }
```

#### Property Value

IPage&lt;CommentDto&gt;<br>

### **AuthPrincipalId**

```csharp
public Nullable<Guid> AuthPrincipalId { get; private set; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

## Constructors

### **PostPageVmImpl(IPostService, ICommentService, IAuthService)**

Instantiates this VM

```csharp
public PostPageVmImpl(IPostService postService, ICommentService commentService, IAuthService authService)
```

#### Parameters

`postService` [IPostService](./slottymedia.backend.services.interfaces.ipostservice.md)<br>

`commentService` [ICommentService](./slottymedia.backend.services.interfaces.icommentservice.md)<br>

`authService` [IAuthService](./slottymedia.backend.services.interfaces.iauthservice.md)<br>

## Methods

### **Initialize(Guid)**

```csharp
public Task Initialize(Guid postId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LoadCommentsPage(Int32)**

```csharp
public Task LoadCommentsPage(int pageNumber)
```

#### Parameters

`pageNumber` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
