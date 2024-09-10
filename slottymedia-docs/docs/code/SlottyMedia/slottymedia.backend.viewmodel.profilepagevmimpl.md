# ProfilePageVmImpl

Namespace: SlottyMedia.Backend.ViewModel

Viewmodel used for the profile page /profile?id=..

```csharp
public class ProfilePageVmImpl : SlottyMedia.Backend.ViewModel.Interfaces.IProfilePageVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ProfilePageVmImpl](./slottymedia.backend.viewmodel.profilepagevmimpl.md)<br>
Implements [IProfilePageVm](./slottymedia.backend.viewmodel.interfaces.iprofilepagevm.md)

## Properties

### **IsLoadingPage**

```csharp
public bool IsLoadingPage { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **IsLoadingPosts**

```csharp
public bool IsLoadingPosts { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **IsUserFollowed**

```csharp
public bool IsUserFollowed { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **AuthPrincipalId**

```csharp
public Nullable<Guid> AuthPrincipalId { get; private set; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **UserInfo**

```csharp
public UserInformationDto UserInfo { get; private set; }
```

#### Property Value

[UserInformationDto](./slottymedia.backend.dtos.userinformationdto.md)<br>

### **Posts**

```csharp
public IPage<PostDto> Posts { get; private set; }
```

#### Property Value

IPage&lt;PostDto&gt;<br>

## Constructors

### **ProfilePageVmImpl(IUserService, IPostService, IAuthService)**

Ctor for dep inject

```csharp
public ProfilePageVmImpl(IUserService userService, IPostService postService, IAuthService authService)
```

#### Parameters

`userService` [IUserService](./slottymedia.backend.services.interfaces.iuserservice.md)<br>

`postService` [IPostService](./slottymedia.backend.services.interfaces.ipostservice.md)<br>

`authService` [IAuthService](./slottymedia.backend.services.interfaces.iauthservice.md)<br>

## Methods

### **Initialize(Guid)**

```csharp
public Task Initialize(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

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

### **FollowThisUser()**

```csharp
public Task FollowThisUser()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UnfollowThisUser()**

```csharp
public Task UnfollowThisUser()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
