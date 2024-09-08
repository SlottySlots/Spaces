# IMainLayoutVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

This Interface represents the viewmodel of the MainLayout (root of our application)

```csharp
public interface IMainLayoutVm
```

## Properties

### **UserInformation**

Gets the user information data transfer object to be rendered.

```csharp
public abstract UserInformationDto UserInformation { get; }
```

#### Property Value

[UserInformationDto](./slottymedia.backend.dtos.userinformationdto.md)<br>

## Methods

### **RestoreSessionOnInit()**

This sets the session on initialization of the page.

```csharp
Task<Session> RestoreSessionOnInit()
```

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the restored session, or null if nothing was restored.

### **SetUserInfo()**

This sets a dto holding information about the current user in order to show the current users infos in the profile
 card

```csharp
Task<UserInformationDto> SetUserInfo()
```

#### Returns

[Task&lt;UserInformationDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns a task of type UserInformationDto. The dto is used to update the state in the view. It's null if a error
 occured.

### **PersistUserAvatarInDb(String)**

This function persists a new avatar of the currently authenticated user

```csharp
Task<string> PersistUserAvatarInDb(string base64Encoding)
```

#### Parameters

`base64Encoding` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The base64Encoding to persist to db

#### Returns

[Task&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns a task of type string. The string represents the base64 encoding persisted in db. Or null if a error
 occured;

### **Initialize(Nullable&lt;Guid&gt;)**

Initializes the ViewModel with the specified user ID.

```csharp
Task Initialize(Nullable<Guid> userId)
```

#### Parameters

`userId` [Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The ID of the user to load information for.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task representing the asynchronous operation.
