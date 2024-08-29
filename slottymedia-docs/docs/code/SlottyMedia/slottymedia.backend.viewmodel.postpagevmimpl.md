# PostPageVmImpl

Namespace: SlottyMedia.Backend.ViewModel

```csharp
public class PostPageVmImpl : SlottyMedia.Backend.ViewModel.Interfaces.IPostPageVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PostPageVmImpl](./slottymedia.backend.viewmodel.postpagevmimpl.md)<br>
Implements [IPostPageVm](./slottymedia.backend.viewmodel.interfaces.ipostpagevm.md)

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
public List<CommentDto> Comments { get; private set; }
```

#### Property Value

[List&lt;CommentDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **TotalNumberOfComments**

```csharp
public int TotalNumberOfComments { get; private set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

## Constructors

### **PostPageVmImpl(IPostService, ICommentService)**

Instantiates this VM

```csharp
public PostPageVmImpl(IPostService postService, ICommentService commentService)
```

#### Parameters

`postService` [IPostService](./slottymedia.backend.services.interfaces.ipostservice.md)<br>

`commentService` [ICommentService](./slottymedia.backend.services.interfaces.icommentservice.md)<br>

## Methods

### **LoadPage(Guid)**

```csharp
public Task LoadPage(Guid postId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LoadMoreComments()**

```csharp
public Task LoadMoreComments()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
