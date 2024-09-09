# CommentVmImpl

Namespace: SlottyMedia.Backend.ViewModel.Partial.PostPage

```csharp
public class CommentVmImpl : ICommentVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [CommentVmImpl](./slottymedia.backend.viewmodel.partial.postpage.commentvmimpl.md)<br>
Implements [ICommentVm](./slottymedia.backend.viewmodel.partial.postpage.icommentvm.md)

## Properties

### **IsLoading**

```csharp
public bool IsLoading { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Dto**

```csharp
public CommentDto Dto { get; private set; }
```

#### Property Value

[CommentDto](./slottymedia.backend.dtos.commentdto.md)<br>

### **UserInfo**

```csharp
public UserInformationDto UserInfo { get; private set; }
```

#### Property Value

[UserInformationDto](./slottymedia.backend.dtos.userinformationdto.md)<br>

## Constructors

### **CommentVmImpl(ICommentService, IUserService, NavigationManager)**

The constructor for the CommentVmImpl.

```csharp
public CommentVmImpl(ICommentService commentService, IUserService userService, NavigationManager navigationManager)
```

#### Parameters

`commentService` [ICommentService](./slottymedia.backend.services.interfaces.icommentservice.md)<br>

`userService` [IUserService](./slottymedia.backend.services.interfaces.iuserservice.md)<br>

`navigationManager` NavigationManager<br>

## Methods

### **Initialize(Guid)**

```csharp
public Task Initialize(Guid commentId)
```

#### Parameters

`commentId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GoToCreatorProfile()**

```csharp
public void GoToCreatorProfile()
```
