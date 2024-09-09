# CommentSubmissionFormVmImpl

Namespace: SlottyMedia.Backend.ViewModel.Partial.PostPage

```csharp
public class CommentSubmissionFormVmImpl : ICommentSubmissionFormVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [CommentSubmissionFormVmImpl](./slottymedia.backend.viewmodel.partial.postpage.commentsubmissionformvmimpl.md)<br>
Implements [ICommentSubmissionFormVm](./slottymedia.backend.viewmodel.partial.postpage.icommentsubmissionformvm.md)

## Properties

### **Text**

```csharp
public string Text { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **TextErrorMessage**

```csharp
public string TextErrorMessage { get; private set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ServerErrorMessage**

```csharp
public string ServerErrorMessage { get; private set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **UserInformation**

```csharp
public UserInformationDto UserInformation { get; set; }
```

#### Property Value

[UserInformationDto](./slottymedia.backend.dtos.userinformationdto.md)<br>

### **IsLoading**

```csharp
public bool IsLoading { get; set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

## Constructors

### **CommentSubmissionFormVmImpl(IAuthService, ICommentService, NavigationManager, IUserService)**

Instantiates this class

```csharp
public CommentSubmissionFormVmImpl(IAuthService authService, ICommentService commentService, NavigationManager navigationManager, IUserService userService)
```

#### Parameters

`authService` [IAuthService](./slottymedia.backend.services.interfaces.iauthservice.md)<br>

`commentService` [ICommentService](./slottymedia.backend.services.interfaces.icommentservice.md)<br>

`navigationManager` NavigationManager<br>

`userService` [IUserService](./slottymedia.backend.services.interfaces.iuserservice.md)<br>

## Methods

### **SubmitForm(Guid)**

```csharp
public Task SubmitForm(Guid postId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **Initialize(Nullable&lt;Guid&gt;)**

```csharp
public Task Initialize(Nullable<Guid> userId)
```

#### Parameters

`userId` [Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
