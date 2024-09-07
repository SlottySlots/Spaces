# SpaceVmImpl

Namespace: SlottyMedia.Backend.ViewModel

Implements ISpaceVm to manage the state of the Space Page.

```csharp
public class SpaceVmImpl : SlottyMedia.Backend.ViewModel.Interfaces.ISpaceVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [SpaceVmImpl](./slottymedia.backend.viewmodel.spacevmimpl.md)<br>
Implements [ISpaceVm](./slottymedia.backend.viewmodel.interfaces.ispacevm.md)

## Properties

### **IsLoadingPosts**

```csharp
public bool IsLoadingPosts { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **IsLoadingPage**

```csharp
public bool IsLoadingPage { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **AuthPrincipalId**

```csharp
public Nullable<Guid> AuthPrincipalId { get; private set; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **Space**

```csharp
public ForumDto Space { get; private set; }
```

#### Property Value

[ForumDto](./slottymedia.backend.dtos.forumdto.md)<br>

### **Posts**

```csharp
public IPage<PostDto> Posts { get; private set; }
```

#### Property Value

IPage&lt;PostDto&gt;<br>

## Constructors

### **SpaceVmImpl(IForumService, IPostService, IAuthService)**

Initializes the ViewModel with the necessary services.

```csharp
public SpaceVmImpl(IForumService forumService, IPostService postService, IAuthService authService)
```

#### Parameters

`forumService` [IForumService](./slottymedia.backend.services.interfaces.iforumservice.md)<br>

`postService` [IPostService](./slottymedia.backend.services.interfaces.ipostservice.md)<br>

`authService` [IAuthService](./slottymedia.backend.services.interfaces.iauthservice.md)<br>

## Methods

### **Initialize(Guid)**

```csharp
public Task Initialize(Guid forumId)
```

#### Parameters

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LoadPosts(Int32)**

```csharp
public Task LoadPosts(int pageNumber)
```

#### Parameters

`pageNumber` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
