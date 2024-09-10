# UserVm

Namespace: SlottyMedia.Backend.ViewModel

Implementation of the IUserVm interface.

```csharp
public class UserVm : SlottyMedia.Backend.ViewModel.Interfaces.IUserVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [UserVm](./slottymedia.backend.viewmodel.uservm.md)<br>
Implements [IUserVm](./slottymedia.backend.viewmodel.interfaces.iuservm.md)

## Constructors

### **UserVm(IUserService)**

Initializes a new instance of the UserVm class.

```csharp
public UserVm(IUserService userService)
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

### **GetUserInformation(Guid)**

```csharp
public Task<UserInformationDto> GetUserInformation(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;UserInformationDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
