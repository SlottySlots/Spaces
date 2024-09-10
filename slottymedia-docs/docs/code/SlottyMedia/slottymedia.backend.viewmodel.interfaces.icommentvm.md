# ICommentVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

Interface for the Comment ViewModel.

```csharp
public interface ICommentVm
```

## Properties

### **UserInformation**

Gets the user information data transfer object to be rendered.

```csharp
public abstract UserInformationDto UserInformation { get; }
```

#### Property Value

[UserInformationDto](./slottymedia.backend.dtos.userinformationdto.md)<br>

### **IsLoading**

Gets a value indicating whether the data is still loading.

```csharp
public abstract bool IsLoading { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

## Methods

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
