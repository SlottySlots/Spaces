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
public SearchService(IUserSeachRepository userSeachRepository, IForumSearchRepository forumSearchRepository)
```

#### Parameters

`userSeachRepository` IUserSeachRepository<br>

`forumSearchRepository` IForumSearchRepository<br>

## Methods

### **SearchByUsername(String, Int32, Int32)**

```csharp
public Task<SearchDto> SearchByUsername(string searchTerm, int page, int pagesize)
```

#### Parameters

`searchTerm` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`pagesize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Task&lt;SearchDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **SearchByTopic(String, Int32, Int32)**

```csharp
public Task<SearchDto> SearchByTopic(string searchTerm, int page, int pagesize)
```

#### Parameters

`searchTerm` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`pagesize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Task&lt;SearchDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
