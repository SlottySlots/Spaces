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

### **SearchByUsernameContaining(String, PageRequest)**

```csharp
public Task<IPage<UserDto>> SearchByUsernameContaining(string searchTerm, PageRequest pageRequest)
```

#### Parameters

`searchTerm` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`pageRequest` PageRequest<br>

#### Returns

[Task&lt;IPage&lt;UserDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **SearchByForumTopicContaining(String, PageRequest)**

```csharp
public Task<IPage<ForumDto>> SearchByForumTopicContaining(string searchTerm, PageRequest pageRequest)
```

#### Parameters

`searchTerm` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`pageRequest` PageRequest<br>

#### Returns

[Task&lt;IPage&lt;ForumDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
