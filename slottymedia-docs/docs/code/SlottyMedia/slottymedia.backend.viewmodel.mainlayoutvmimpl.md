# MainLayoutVmImpl

Namespace: SlottyMedia.Backend.ViewModel

ViewModel of the MainLayout which is essentially the root view of SlottyMedia

```csharp
public class MainLayoutVmImpl : SlottyMedia.Backend.ViewModel.Interfaces.IMainLayoutVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [MainLayoutVmImpl](./slottymedia.backend.viewmodel.mainlayoutvmimpl.md)<br>
Implements [IMainLayoutVm](./slottymedia.backend.viewmodel.interfaces.imainlayoutvm.md)

## Constructors

### **MainLayoutVmImpl(IAuthService, IDatabaseActions)**

```csharp
public MainLayoutVmImpl(IAuthService authService, IDatabaseActions databaseActions)
```

#### Parameters

`authService` [IAuthService](./slottymedia.backend.services.interfaces.iauthservice.md)<br>

`databaseActions` IDatabaseActions<br>

## Methods

### **RestoreSessionOnInit()**

This sets the session on initialization of the page.

```csharp
public Task<Session> RestoreSessionOnInit()
```

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the restored session, or null if nothing was restored.

### **SetUserInfo()**

This sets a dto holding information about the current user in order to show the current users infos in the profile card

```csharp
public Task<UserInformationDto> SetUserInfo()
```

#### Returns

[Task&lt;UserInformationDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns a task of type UserInformationDto. The dto is used to update the state in the view.

### **PersistUserAvatarInDb(String)**

This function persists a new avatar of the currently authenticated user

```csharp
public Task<string> PersistUserAvatarInDb(string base64Encoding)
```

#### Parameters

`base64Encoding` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The base64Encoding to persist to db

#### Returns

[Task&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns a task of type string. The string represents the base64 encoding persisted in db.
