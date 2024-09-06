# IProfilePageVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

Interface used for profilepage viewmodel

```csharp
public interface IProfilePageVm
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

### **IsUserFollowed**

Whether the authentication principal is following the user whose profile is being visited

```csharp
public abstract bool IsUserFollowed { get; }
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

### **UserInfo**

Information about the user whose profile is being visited

```csharp
public abstract UserInformationDto UserInfo { get; }
```

#### Property Value

[UserInformationDto](./slottymedia.backend.dtos.userinformationdto.md)<br>

### **Posts**

The posts that are currently being rendered

```csharp
public abstract IPage<PostDto> Posts { get; }
```

#### Property Value

IPage&lt;PostDto&gt;<br>

## Methods

### **Initialize(Guid)**

Initialized the page's state. This fetches all user-related information and loads
 the first posts for the visited user. Also initializes the [IProfilePageVm.AuthPrincipalId](./slottymedia.backend.viewmodel.interfaces.iprofilepagevm.md#authprincipalid)
 if one is present.

```csharp
Task Initialize(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user whose profile should be visited

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **FollowThisUser()**

Has the authentication principal follow the visited profile. Does
 nothing if no authentication principal is present.

```csharp
Task FollowThisUser()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UnfollowThisUser()**

Has the authentication principal unfollow the visited profile. Does
 nothing if no authentication principal is present.

```csharp
Task UnfollowThisUser()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LoadPosts(Int32)**

Loads more [IProfilePageVm.Posts](./slottymedia.backend.viewmodel.interfaces.iprofilepagevm.md#posts) for the visited profile by changing the current
 page (as in pagination).

```csharp
Task LoadPosts(int pageNumber)
```

#### Parameters

`pageNumber` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The page number

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
