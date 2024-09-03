# ISearchService

Namespace: SlottyMedia.Backend.Services.Interfaces

This interface is used to define the Search Service.

```csharp
public interface ISearchService
```

## Methods

### **SearchByUsername(String, Int32, Int32)**

Search function to retrieve all users for a specific search term.

```csharp
Task<SearchDto> SearchByUsername(string searchTerm, int page, int pagesize)
```

#### Parameters

`searchTerm` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Search Term used for wildcard selection

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Current page retrieved (interval times page)

`pagesize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Size of interval

#### Returns

[Task&lt;SearchDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
SearchDto

#### Exceptions

[SearchGeneralExceptions](./slottymedia.backend.exceptions.services.searchexceptions.searchgeneralexceptions.md)<br>
Thrown when a general error occurs during the search.

### **SearchByTopic(String, Int32, Int32)**

Search function to retrieve forums by topic.

```csharp
Task<SearchDto> SearchByTopic(string searchTerm, int page, int pagesize)
```

#### Parameters

`searchTerm` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Search Term used for wildcard search

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Current page retrieved (interval times page)

`pagesize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Size of interval

#### Returns

[Task&lt;SearchDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
SearchDto

#### Exceptions

[SearchGeneralExceptions](./slottymedia.backend.exceptions.services.searchexceptions.searchgeneralexceptions.md)<br>
Thrown when a general error occurs during the search.
