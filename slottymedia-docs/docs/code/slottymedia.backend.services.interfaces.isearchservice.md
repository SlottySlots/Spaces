# ISearchService

Namespace: SlottyMedia.Backend.Services.Interfaces

```csharp
public interface ISearchService
```

## Methods

### **SearchByUsernameOrTopic(String)**

```csharp
Task<List<Nullable<Guid>>> SearchByUsernameOrTopic(string searchTerm)
```

#### Parameters

`searchTerm` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;List&lt;Nullable&lt;Guid&gt;&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
