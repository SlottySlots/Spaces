# IAuthVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

Interface used as auth viewmodel

```csharp
public interface IAuthVm
```

## Methods

### **GetCurrentSession()**

Gets the current logged in session of a user.

```csharp
Session GetCurrentSession()
```

#### Returns

Session<br>
The current session of the user. Can be null if the user isn't logged in.

### **GetCurrentUserId()**

Gets the user ID of the current logged in user.

```csharp
Guid GetCurrentUserId()
```

#### Returns

[Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The user ID as a Guid.

### **IsAuthenticated()**

Checks if the user is authenticated.

```csharp
bool IsAuthenticated()
```

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
True if the user is authenticated, otherwise false.
