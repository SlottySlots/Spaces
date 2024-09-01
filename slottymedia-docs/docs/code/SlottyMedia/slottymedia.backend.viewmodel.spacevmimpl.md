# SpaceVmImpl

Namespace: SlottyMedia.Backend.ViewModel

Implements ISpaceVm to manage the state of the Space Page.

```csharp
public class SpaceVmImpl : SlottyMedia.Backend.ViewModel.Interfaces.ISpaceVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [SpaceVmImpl](./slottymedia.backend.viewmodel.spacevmimpl.md)<br>
Implements [ISpaceVm](./slottymedia.backend.viewmodel.interfaces.ispacevm.md)

## Properties

### **CreatedAt**

```csharp
public DateTime CreatedAt { get; private set; }
```

#### Property Value

[DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>

### **Topic**

```csharp
public string Topic { get; private set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **PostCount**

```csharp
public int PostCount { get; private set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

## Constructors

### **SpaceVmImpl(IForumService, IPostService)**

Initializes the ViewModel with the necessary services.

```csharp
public SpaceVmImpl(IForumService forumService, IPostService postService)
```

#### Parameters

`forumService` [IForumService](./slottymedia.backend.services.interfaces.iforumservice.md)<br>

`postService` [IPostService](./slottymedia.backend.services.interfaces.ipostservice.md)<br>

## Methods

### **GetSpaceInformation(String)**

```csharp
public Task<ForumDto> GetSpaceInformation(string name)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;ForumDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **LoadSpaceDetails(String)**

```csharp
public Task LoadSpaceDetails(string name)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetPostsByForumId(Guid, Int32, Int32)**

Gets post by forum id

```csharp
public Task<List<PostDto>> GetPostsByForumId(Guid forumId, int startOfSet, int endOfSet)
```

#### Parameters

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
Forum the posts belongs to

`startOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Starting index on which the follows are retrieved (they are sorted by date)

`endOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Ending index used to slice the posts in a specific intervall

#### Returns

[Task&lt;List&lt;PostDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
List of PostDtos
