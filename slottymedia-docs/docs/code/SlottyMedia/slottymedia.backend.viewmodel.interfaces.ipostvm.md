# IPostVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

The interface for post view model implementation.

```csharp
public interface IPostVm
```

## Properties

### **AuthPrincipalId**

```csharp
public abstract Nullable<Guid> AuthPrincipalId { get; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **IsPostLiked**

Gets a value indicating whether the post was liked by the user.

```csharp
public abstract bool IsPostLiked { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **IsLoading**

Gets a value indicating whether the post view model is currently loading.

```csharp
public abstract bool IsLoading { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **PostDto**

```csharp
public abstract PostDto PostDto { get; }
```

#### Property Value

[PostDto](./slottymedia.backend.dtos.postdto.md)<br>

### **CommentCount**

Gets the count of comments on the post.

```csharp
public abstract int CommentCount { get; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **LikeCount**

Gets the count of likes on the post.

```csharp
public abstract int LikeCount { get; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **UserInformation**

Gets the user information associated with the post.

```csharp
public abstract UserInformationDto UserInformation { get; }
```

#### Property Value

[UserInformationDto](./slottymedia.backend.dtos.userinformationdto.md)<br>

## Methods

### **Initialize(Guid, Action)**

Initializes the post view model.

```csharp
Task Initialize(Guid postId, Action onStateChanged)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the post.

`onStateChanged` [Action](https://docs.microsoft.com/en-us/dotnet/api/system.action)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task that represents the asynchronous operation.

### **LikeThisPost()**

Likes a post by a user.

```csharp
Task LikeThisPost()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task that represents the asynchronous operation.

### **GoToPostPage()**

```csharp
void GoToPostPage()
```

### **GoToProfilePage()**

```csharp
void GoToProfilePage()
```
