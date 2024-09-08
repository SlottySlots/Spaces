# IPostVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

The interface for post view model implementation.

```csharp
public interface IPostVm
```

## Properties

### **CommentCount**

Gets the count of comments on the post.

```csharp
public abstract int CommentCount { get; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **InitLiked**

Gets a value indicating whether the post was initially liked by the user.

```csharp
public abstract bool InitLiked { get; }
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

### **Initialize(Guid, Guid)**

Initializes the post view model.

```csharp
Task Initialize(Guid postId, Guid userId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the post.

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task that represents the asynchronous operation.

### **LikePost(Guid, Guid)**

Likes a post by a user.

```csharp
Task LikePost(Guid postId, Guid userId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the post.

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task that represents the asynchronous operation.

### **GetUserInformation(Guid, Boolean)**

Retrieves user information.

```csharp
Task GetUserInformation(Guid userId, bool firstRender)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user.

`firstRender` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Indicates if this is the first render.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task that represents the asynchronous operation.
