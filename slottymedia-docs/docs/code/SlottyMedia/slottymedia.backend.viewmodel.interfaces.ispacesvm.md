# ISpacesVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

This ViewModel represents the state of the [Spaces](./slottymedia.components.pages.spaces.md) Page.

```csharp
public interface ISpacesVm
```

## Properties

### **Forums**

A list containing all spaces that should be rendered

```csharp
public abstract List<ForumDto> Forums { get; }
```

#### Property Value

[List&lt;ForumDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **IsLoading**

Indicates whether the ViewModel is currently loading data.

```csharp
public abstract bool IsLoading { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

## Methods

### **LoadForums()**

Fetches all forums and populates the [ISpacesVm.Forums](./slottymedia.backend.viewmodel.interfaces.ispacesvm.md#forums) property.

```csharp
Task LoadForums()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
