# ISearchService

Namespace: SlottyMedia.Backend.Services.Interfaces

This interface is used to define the Search Service.

```csharp
public interface ISearchService
```

## Methods

### **SearchByUsernameOrTopic(String)**

This method searches for a user by username or topic.

```csharp
Task<List<Nullable<Guid>>> SearchByUsernameOrTopic(string searchTerm)
```

#### Parameters

`searchTerm` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;List&lt;Nullable&lt;Guid&gt;&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
