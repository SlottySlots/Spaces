# IAuthVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

Interface used as auth viewmodel

```csharp
public interface IAuthVm
```

## Methods

### **GetCurrentSession()**

Gets the current logged in session of a user

```csharp
Session GetCurrentSession()
```

#### Returns

Session<br>
Session. Can be null if user isn't logged in
