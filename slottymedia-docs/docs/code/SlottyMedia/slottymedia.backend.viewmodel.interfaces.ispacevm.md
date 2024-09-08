# ISpaceVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

This ViewModel represents the state of the Space Page.

```csharp
public interface ISpaceVm
```

## Properties

### **IsLoadingPage**

Whether the whole page is being loaded

```csharp
public abstract bool IsLoadingPage { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **IsLoadingPosts**

Whether the posts on the page are being loaded

```csharp
public abstract bool IsLoadingPosts { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **AuthPrincipalId**

The authentication principal's user ID (i.e. the user that's logged in)

```csharp
public abstract Nullable<Guid> AuthPrincipalId { get; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **Space**

The space whose page is being visited

```csharp
public abstract ForumDto Space { get; }
```

#### Property Value

[ForumDto](./slottymedia.backend.dtos.forumdto.md)<br>

### **Posts**

The posts that are currently being rendered

```csharp
public abstract IPage<PostDto> Posts { get; }
```

#### Property Value

IPage&lt;PostDto&gt;<br>

## Methods

### **Initialize(Guid)**

Initialized the page's state. This fetches all space-related information and loads
 the first posts for the visited space. Also initializes the [ISpaceVm.AuthPrincipalId](./slottymedia.backend.viewmodel.interfaces.ispacevm.md#authprincipalid)
 if one is present.

```csharp
Task Initialize(Guid forumId)
```

#### Parameters

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the space whose page should be visited

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LoadPosts(Int32)**

Loads more [ISpaceVm.Posts](./slottymedia.backend.viewmodel.interfaces.ispacevm.md#posts) for the visited space by changing the current
 page (as in pagination).

```csharp
Task LoadPosts(int pageNumber)
```

#### Parameters

`pageNumber` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The page number

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
