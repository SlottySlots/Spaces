# ICommentVm

Namespace: SlottyMedia.Backend.ViewModel.Partial.PostPage

Interface for the Comment ViewModel.

```csharp
public interface ICommentVm
```

## Properties

### **IsLoading**

Whether the necessary comment-related data is still being loaded.

```csharp
public abstract bool IsLoading { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Dto**

The comment that should be rendered.

```csharp
public abstract CommentDto Dto { get; }
```

#### Property Value

[CommentDto](./slottymedia.backend.dtos.commentdto.md)<br>

### **UserInfo**

User-related information about the comment's creator.

```csharp
public abstract UserInformationDto UserInfo { get; }
```

#### Property Value

[UserInformationDto](./slottymedia.backend.dtos.userinformationdto.md)<br>

## Methods

### **Initialize(Guid)**

Initializes this view model with the provided comment ID.
 This loads all comment-related information.

```csharp
Task Initialize(Guid commentId)
```

#### Parameters

`commentId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the comment that should be loaded

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GoToCreatorProfile()**

Navigates to the comment creator's profile page.

```csharp
void GoToCreatorProfile()
```
