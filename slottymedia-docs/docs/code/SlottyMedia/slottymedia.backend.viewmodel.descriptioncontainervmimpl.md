# DescriptionContainerVmImpl

Namespace: SlottyMedia.Backend.ViewModel

The DescriptionContainerVmImpl class is responsible for handling the logic for the DescriptionContainerVm.

```csharp
public class DescriptionContainerVmImpl : SlottyMedia.Backend.ViewModel.Interfaces.IDescriptionContainerVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DescriptionContainerVmImpl](./slottymedia.backend.viewmodel.descriptioncontainervmimpl.md)<br>
Implements [IDescriptionContainerVm](./slottymedia.backend.viewmodel.interfaces.idescriptioncontainervm.md)

## Properties

### **ShowDescriptionText**

Flag to determine whether to show the description text or the input field.

```csharp
public bool ShowDescriptionText { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

## Constructors

### **DescriptionContainerVmImpl(IUserService)**

The constructor for the DescriptionContainerVmImpl.

```csharp
public DescriptionContainerVmImpl(IUserService userService)
```

#### Parameters

`userService` [IUserService](./slottymedia.backend.services.interfaces.iuserservice.md)<br>

## Methods

### **SubmitDescriptionAsync(String, Nullable&lt;Guid&gt;)**

```csharp
public Task SubmitDescriptionAsync(string description, Nullable<Guid> userId)
```

#### Parameters

`description` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`userId` [Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
