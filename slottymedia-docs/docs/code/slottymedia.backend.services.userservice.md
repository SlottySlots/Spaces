# UserService

Namespace: SlottyMedia.Backend.Services

```csharp
public class UserService : SlottyMedia.Backend.Services.Interfaces.IUserService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [UserService](./slottymedia.backend.services.userservice.md)<br>
Implements [IUserService](./slottymedia.backend.services.interfaces.iuserservice.md)

## Constructors

### **UserService(Client)**

This constructor creates a new UserService object..

```csharp
public UserService(Client supabaseClient)
```

#### Parameters

`supabaseClient` Client<br>
Supabase Client to interact with the database

## Methods

### **CreateUser(String, String, String, Nullable&lt;Int64&gt;)**

This method creates a new User object in the database and returns the created object.

```csharp
public Task<UserDto> CreateUser(string userId, string username, string description, Nullable<long> profilePicture)
```

#### Parameters

`userId` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The ID we get from the Supabase Authentication Service

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Username of the User

`description` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Description of the User

`profilePicture` [Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The Profile Picture of the User

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the Created UserDto. If it was unable to create a User, it will return null

### **DeleteUser(UserDto)**

This method deletes the given User object from the database.

```csharp
public Task<bool> DeleteUser(UserDto user)
```

#### Parameters

`user` [UserDto](./slottymedia.backend.models.userdto.md)<br>
The User Object to delete

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns wheter it was possible to Delete the User or not. IF it was Possible it will return true.

### **GetUserById(String)**

This method returns a User object from the database based on the given userId.

```csharp
public Task<UserDto> GetUserById(string userId)
```

#### Parameters

`userId` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The ID of the User to get from the Database

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the User Object from the Database. If no User was found, null will be returned

### **UpdateUser(UserDto)**

This method updates the given User object in the database and returns the updated object.

```csharp
public Task<UserDto> UpdateUser(UserDto user)
```

#### Parameters

`user` [UserDto](./slottymedia.backend.models.userdto.md)<br>
The updated User Dto

#### Returns

[Task&lt;UserDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the Updated User Interface. If it was unable to Update the User, it will return null.
