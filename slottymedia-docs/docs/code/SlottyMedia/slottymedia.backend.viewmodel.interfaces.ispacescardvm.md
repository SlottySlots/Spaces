# ISpacesCardVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

```csharp
public interface ISpacesCardVm
```

## Properties

### **TrendingSpaces**

A list containing all trending spaces

```csharp
public abstract List<ForumDto> TrendingSpaces { get; set; }
```

#### Property Value

[List&lt;ForumDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **RecentSpaces**

A list containing all recent spaces

```csharp
public abstract List<ForumDto> RecentSpaces { get; set; }
```

#### Property Value

[List&lt;ForumDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **NumOfPostsInSpace**

A dictionary that maps a space ID to the toal number of posts in that
 space. Only spaces listed in [ISpacesCardVm.TrendingSpaces](./slottymedia.backend.viewmodel.interfaces.ispacescardvm.md#trendingspaces) and [ISpacesCardVm.RecentSpaces](./slottymedia.backend.viewmodel.interfaces.ispacescardvm.md#recentspaces)
 will be considered.

```csharp
public abstract Dictionary<Guid, int> NumOfPostsInSpace { get; set; }
```

#### Property Value

[Dictionary&lt;Guid, Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2)<br>

## Methods

### **Fetch()**

Fetches all trending spaces, recent spaces and evaluates how many posts exist per space.

```csharp
Task Fetch()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
