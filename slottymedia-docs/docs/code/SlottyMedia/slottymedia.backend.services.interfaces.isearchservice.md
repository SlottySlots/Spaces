# ISearchService

Namespace: SlottyMedia.Backend.Services.Interfaces

This interface is used to define the Search Service.

```csharp
public interface ISearchService
```

## Methods

### **SearchByUsername(String, Int32, Int32)**

```csharp
Task<SearchDto> SearchByUsername(string searchTerm, int page, int pagesize)
```

#### Parameters

`searchTerm` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`pagesize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Task&lt;SearchDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **SearchByTopic(String, Int32, Int32)**

```csharp
Task<SearchDto> SearchByTopic(string searchTerm, int page, int pagesize)
```

#### Parameters

`searchTerm` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`pagesize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Task&lt;SearchDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
