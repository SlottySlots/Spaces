# SpacesVmImpl

Namespace: SlottyMedia.Backend.ViewModel.Pages.Space

```csharp
public class SpacesVmImpl : ISpacesVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [SpacesVmImpl](./slottymedia.backend.viewmodel.pages.space.spacesvmimpl.md)<br>
Implements [ISpacesVm](./slottymedia.backend.viewmodel.pages.space.ispacesvm.md)

## Properties

### **Forums**

```csharp
public List<ForumDto> Forums { get; private set; }
```

#### Property Value

[List&lt;ForumDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **IsLoading**

```csharp
public bool IsLoading { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

## Constructors

### **SpacesVmImpl(IForumService)**

Initializes this ViewModel

```csharp
public SpacesVmImpl(IForumService forumService)
```

#### Parameters

`forumService` [IForumService](./slottymedia.backend.services.interfaces.iforumservice.md)<br>

## Methods

### **LoadForums()**

```csharp
public Task LoadForums()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
