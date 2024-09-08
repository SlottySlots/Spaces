# SpacesCardVmImpl

Namespace: SlottyMedia.Backend.ViewModel

```csharp
public class SpacesCardVmImpl : SlottyMedia.Backend.ViewModel.Interfaces.ISpacesCardVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [SpacesCardVmImpl](./slottymedia.backend.viewmodel.spacescardvmimpl.md)<br>
Implements [ISpacesCardVm](./slottymedia.backend.viewmodel.interfaces.ispacescardvm.md)

## Properties

### **TrendingSpaces**

```csharp
public List<ForumDto> TrendingSpaces { get; set; }
```

#### Property Value

[List&lt;ForumDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **RecentSpaces**

```csharp
public List<ForumDto> RecentSpaces { get; set; }
```

#### Property Value

[List&lt;ForumDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **NumOfPostsInSpace**

```csharp
public Dictionary<Guid, int> NumOfPostsInSpace { get; set; }
```

#### Property Value

[Dictionary&lt;Guid, Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2)<br>

## Constructors

### **SpacesCardVmImpl(IForumService)**

Initializes this ViewModel

```csharp
public SpacesCardVmImpl(IForumService forumService)
```

#### Parameters

`forumService` [IForumService](./slottymedia.backend.services.interfaces.iforumservice.md)<br>

## Methods

### **Fetch()**

```csharp
public Task Fetch()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
