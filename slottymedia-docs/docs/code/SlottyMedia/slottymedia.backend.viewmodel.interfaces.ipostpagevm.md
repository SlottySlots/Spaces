# IPostPageVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

```csharp
public interface IPostPageVm
```

## Properties

### **IsLoadingPage**

```csharp
public abstract bool IsLoadingPage { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **IsLoadingComments**

```csharp
public abstract bool IsLoadingComments { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Post**

```csharp
public abstract PostDto Post { get; }
```

#### Property Value

[PostDto](./slottymedia.backend.dtos.postdto.md)<br>

### **Comments**

```csharp
public abstract List<CommentDto> Comments { get; }
```

#### Property Value

[List&lt;CommentDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

## Methods

### **LoadPage(Guid)**

```csharp
Task LoadPage(Guid postId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LoadMoreComments()**

```csharp
Task LoadMoreComments()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
