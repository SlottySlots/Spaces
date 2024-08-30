# CommentSubmissionFormVmImpl

Namespace: SlottyMedia.Backend.ViewModel

```csharp
public class CommentSubmissionFormVmImpl : SlottyMedia.Backend.ViewModel.Interfaces.ICommentSubmissionFormVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [CommentSubmissionFormVmImpl](./slottymedia.backend.viewmodel.commentsubmissionformvmimpl.md)<br>
Implements [ICommentSubmissionFormVm](./slottymedia.backend.viewmodel.interfaces.icommentsubmissionformvm.md)

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

## Constructors

### **CommentSubmissionFormVmImpl(IAuthService, ICommentService, NavigationManager)**

Instantiates this class

```csharp
public CommentSubmissionFormVmImpl(IAuthService authService, ICommentService commentService, NavigationManager navigationManager)
```

#### Parameters

`authService` [IAuthService](./slottymedia.backend.services.interfaces.iauthservice.md)<br>

`commentService` [ICommentService](./slottymedia.backend.services.interfaces.icommentservice.md)<br>

`navigationManager` NavigationManager<br>

## Methods

### **SubmitForm(Guid)**

```csharp
public Task SubmitForm(Guid postId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
