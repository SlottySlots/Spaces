# IUserVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

Interface for user view model implementation.

```csharp
public interface IUserVm
```

## Methods

### **GetUserById(Guid)**

Asynchronously retrieves a user by their unique identifier.

```csharp
Task<UserDto> GetUserById(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The unique identifier of the user.

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains the user data transfer object.

### **UpdateUser(UserDto)**

Updates the given UserDto object in the database and returns the updated object.

```csharp
Task UpdateUser(UserDto user)
```

#### Parameters

`user` [UserDto](./slottymedia.backend.dtos.userdto.md)<br>
The UserDto object to be updated.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task that represents the asynchronous operation. The task result contains the updated UserDto object.

### **GetUserInformation(Guid)**

Asynchronously retrieves user information by their unique identifier.

```csharp
Task<UserInformationDto> GetUserInformation(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The unique identifier of the user.

#### Returns

[Task&lt;UserInformationDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains the user information data transfer object.
