# UserVmImpl

Namespace: SlottyMedia.Backend.ViewModel

Implementation of the IUserVmImpl interface.

```csharp
public class UserVmImpl : SlottyMedia.Backend.ViewModel.Interfaces.IUserVmImpl
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [UserVmImpl](./slottymedia.backend.viewmodel.uservmimpl.md)<br>
Implements [IUserVmImpl](./slottymedia.backend.viewmodel.interfaces.iuservmimpl.md)

## Constructors

### **UserVmImpl(IUserService)**

Initializes a new instance of the UserVmImpl class.

```csharp
public UserVmImpl(IUserService userService)
```

#### Parameters

`userService` [IUserService](./slottymedia.backend.services.interfaces.iuserservice.md)<br>
The user service to be used.

## Methods

### **GetUserById(Guid)**

```csharp
public Task<UserDto> GetUserById(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **UpdateUser(UserDto)**

```csharp
public Task UpdateUser(UserDto user)
```

#### Parameters

`user` [UserDto](./slottymedia.backend.dtos.userdto.md)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
