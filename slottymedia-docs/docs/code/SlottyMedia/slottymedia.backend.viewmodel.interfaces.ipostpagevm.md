# IPostPageVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

This ViewModel represents the state of the [PostPage](./slottymedia.components.pages.postpage.md).

```csharp
public interface IPostPageVm
```

## Properties

### **IsLoadingPage**

Indicates whether the post is being fetched (i.e. the whole page is loading)

```csharp
public abstract bool IsLoadingPage { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **IsLoadingComments**

Indicates whether additional comments are being fetched

```csharp
public abstract bool IsLoadingComments { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Post**

The post that will be showcased. If `null`, then the post is either being fetched or it does not exist.

```csharp
public abstract PostDto Post { get; }
```

#### Property Value

[PostDto](./slottymedia.backend.dtos.postdto.md)<br>

### **Comments**

The comments that belong to the post

```csharp
public abstract List<CommentDto> Comments { get; }
```

#### Property Value

[List&lt;CommentDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **TotalNumberOfComments**

Indicates the total number of comments in the showcased post

```csharp
public abstract int TotalNumberOfComments { get; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

## Methods

### **LoadPage(Guid)**

Attempts to load the given post. If no such post exists, then [IPostPageVm.Post](./slottymedia.backend.viewmodel.interfaces.ipostpagevm.md#post) will be `null`.
 Otherwise, it will be a [PostDto](./slottymedia.backend.dtos.postdto.md) that corresponds to the requested post.

```csharp
Task LoadPage(Guid postId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the post to showcase

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LoadMoreComments()**

Attempts to load more comments than were already showcased. Does nothing if no further comments exist.

```csharp
Task LoadMoreComments()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
