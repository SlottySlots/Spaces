# ISearchService

Namespace: SlottyMedia.Backend.Services.Interfaces

This interface is used to define the Search Service.

```csharp
public interface ISearchService
```

## Methods

### **SearchByUsernameContaining(String, PageRequest)**

Search function to retrieve all users for a specific search term.

```csharp
Task<IPage<UserDto>> SearchByUsernameContaining(string searchTerm, PageRequest pageRequest)
```

#### Parameters

`searchTerm` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Search Term used for wildcard selection

`pageRequest` PageRequest<br>
The page request

#### Returns

[Task&lt;IPage&lt;UserDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
SearchDto

#### Exceptions

[SearchGeneralExceptions](./slottymedia.backend.exceptions.services.searchexceptions.searchgeneralexceptions.md)<br>
Thrown when a general error occurs during the search.

### **SearchByForumTopicContaining(String, PageRequest)**

Search function to retrieve forums by topic.

```csharp
Task<IPage<ForumDto>> SearchByForumTopicContaining(string searchTerm, PageRequest pageRequest)
```

#### Parameters

`searchTerm` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Search Term used for wildcard search

`pageRequest` PageRequest<br>
The page request

#### Returns

[Task&lt;IPage&lt;ForumDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
SearchDto

#### Exceptions

[SearchGeneralExceptions](./slottymedia.backend.exceptions.services.searchexceptions.searchgeneralexceptions.md)<br>
Thrown when a general error occurs during the search.
