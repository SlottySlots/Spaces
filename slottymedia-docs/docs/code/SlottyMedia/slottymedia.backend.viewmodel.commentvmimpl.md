# CommentVmImpl

Namespace: SlottyMedia.Backend.ViewModel

The CommentVmImpl class is responsible for handling the logic for the CommentVm.

```csharp
public class CommentVmImpl : SlottyMedia.Backend.ViewModel.Interfaces.ICommentVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [CommentVmImpl](./slottymedia.backend.viewmodel.commentvmimpl.md)<br>
Implements [ICommentVm](./slottymedia.backend.viewmodel.interfaces.icommentvm.md)

## Properties

### **UserInformation**

The user information data transfer object to be rendered.

```csharp
public UserInformationDto UserInformation { get; set; }
```

#### Property Value

[UserInformationDto](./slottymedia.backend.dtos.userinformationdto.md)<br>

### **IsLoading**

Gets a value indicating whether the data is still loading.

```csharp
public bool IsLoading { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

## Constructors

### **CommentVmImpl(IUserService)**

The constructor for the CommentVmImpl.

```csharp
public CommentVmImpl(IUserService userService)
```

#### Parameters

`userService` [IUserService](./slottymedia.backend.services.interfaces.iuserservice.md)<br>
The user service to be used for fetching user information.

## Methods

### **Initialize(Nullable&lt;Guid&gt;)**

Initializes the ViewModel with the specified user ID.

```csharp
public Task Initialize(Nullable<Guid> userId)
```

#### Parameters

`userId` [Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The ID of the user to load information for.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task representing the asynchronous operation.
