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

A boolean flag indicating whether the posts on the page are being loaded.

```csharp
public bool IsLoadingPosts { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **IsLoadingPage**

A boolean flag indicating whether the entire page is being loaded.

```csharp
public bool IsLoadingPage { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **AuthPrincipalId**

The ID of the authenticated user (the currently logged-in user).

```csharp
public Nullable<Guid> AuthPrincipalId { get; private set; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **Space**

Holds the details of the current space (ForumDto).

```csharp
public ForumDto Space { get; private set; }
```

#### Property Value

[ForumDto](./slottymedia.backend.dtos.forumdto.md)<br>

### **Posts**

Contains the paginated posts belonging to the space.

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

Loads the details of a specific space based on the provided forum ID.
 This method also loads the posts for the space and sets the loading states accordingly.
 The space to load information from.

```csharp
public Task Initialize(Guid forumId)
```

#### Parameters

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LoadPosts(Int32)**

Loads the posts for the space. This method is called when loading a specific page of posts.

```csharp
public Task LoadPosts(int pageNumber)
```

#### Parameters

`pageNumber` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The page number to load posts from.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
