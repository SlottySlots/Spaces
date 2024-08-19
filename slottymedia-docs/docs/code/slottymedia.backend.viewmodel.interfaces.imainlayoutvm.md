# IMainLayoutVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

This Interface represents the viewmodel of the MainLayout (root of our application)

```csharp
public interface IMainLayoutVm
```

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

This sets a dto holding information about the current user in order to show the current users infos in the profile card

```csharp
Task<UserInformationDto> SetUserInfo()
```

#### Returns

[Task&lt;UserInformationDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns a task of type UserInformationDto. The dto is used to update the state in the view. It's null if a error occured.
