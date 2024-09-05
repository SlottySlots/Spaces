# ISearchService

Namespace: SlottyMedia.Backend.Services.Interfaces

This interface is used to define the Search Service.

```csharp
public interface ISearchService
```

## Methods

### **SearchByUsername(String)**

Search function to retrieve all users for a specific search term.

```csharp
Task<SearchDto> SearchByUsername(string searchTerm)
```

#### Parameters

`searchTerm` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Search Term used for wildcard selection

#### Returns

[Task&lt;SearchDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
SearchDto

#### Exceptions

[SearchGeneralExceptions](./slottymedia.backend.exceptions.services.searchexceptions.searchgeneralexceptions.md)<br>
Thrown when a general error occurs during the search.

### **SearchByTopic(String)**

Search function to retrieve forums by topic.

```csharp
Task<SearchDto> SearchByTopic(string searchTerm)
```

#### Parameters

`searchTerm` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Search Term used for wildcard search

#### Returns

[Task&lt;SearchDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
SearchDto

#### Exceptions

[SearchGeneralExceptions](./slottymedia.backend.exceptions.services.searchexceptions.searchgeneralexceptions.md)<br>
Thrown when a general error occurs during the search.
