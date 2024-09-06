# SearchService

Namespace: SlottyMedia.Backend.Services

Service for searching users and topics.

```csharp
public class SearchService : SlottyMedia.Backend.Services.Interfaces.ISearchService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [SearchService](./slottymedia.backend.services.searchservice.md)<br>
Implements [ISearchService](./slottymedia.backend.services.interfaces.isearchservice.md)

## Constructors

### **SearchService(IUserSeachRepository, IForumSearchRepository)**

Constructor to initialize the database actions dependency.

```csharp
public SearchService(IUserSeachRepository userSearchRepository, IForumSearchRepository forumSearchRepository)
```

#### Parameters

`userSearchRepository` IUserSeachRepository<br>
Repo used to retrieve search results.

`forumSearchRepository` IForumSearchRepository<br>
Repo used to retrieve search results specific to a forum

## Methods

### **SearchByUsername(String)**

```csharp
public Task<SearchDto> SearchByUsername(string searchTerm)
```

#### Parameters

`searchTerm` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;SearchDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **SearchByTopic(String)**

```csharp
public Task<SearchDto> SearchByTopic(string searchTerm)
```

#### Parameters

`searchTerm` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;SearchDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
