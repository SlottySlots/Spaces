# IDescriptionContainerVm

Namespace: SlottyMedia.Backend.ViewModel.Partial.DescriptionContainer

Interface for the DescriptionContainer ViewModel.

```csharp
public interface IDescriptionContainerVm
```

## Properties

### **ShowDescriptionText**

Flag to determine whether to show the description text or the input field.

```csharp
public abstract bool ShowDescriptionText { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

## Methods

### **SubmitDescriptionAsync(String, Nullable&lt;Guid&gt;)**

Submits the description asynchronously.

```csharp
Task SubmitDescriptionAsync(string description, Nullable<Guid> userId)
```

#### Parameters

`description` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The description text to submit.

`userId` [Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The ID of the user to update the description for.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
