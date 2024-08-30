# ProfilePageVmImpl

Namespace: SlottyMedia.Backend.ViewModel

```csharp
public class ProfilePageVmImpl : SlottyMedia.Backend.ViewModel.Interfaces.IProfilePageVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ProfilePageVmImpl](./slottymedia.backend.viewmodel.profilepagevmimpl.md)<br>
Implements [IProfilePageVm](./slottymedia.backend.viewmodel.interfaces.iprofilepagevm.md)

## Constructors

### **ProfilePageVmImpl(IUserService)**

```csharp
public ProfilePageVmImpl(IUserService userService)
```

#### Parameters

`userService` [IUserService](./slottymedia.backend.services.interfaces.iuserservice.md)<br>

## Methods

### **GetUserInfo(Guid)**

```csharp
public Task<UserInformationDto> GetUserInfo(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;UserInformationDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **UserFollowRelation(Guid, Guid)**

```csharp
public Task<Nullable<bool>> UserFollowRelation(Guid userIdToCheck, Guid userIdLoggedIn)
```

#### Parameters

`userIdToCheck` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`userIdLoggedIn` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;Nullable&lt;Boolean&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **FollowUserById(Guid, Guid)**

```csharp
public Task FollowUserById(Guid userIdFollows, Guid userIdToFollow)
```

#### Parameters

`userIdFollows` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`userIdToFollow` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
