# SearchService

Namespace: SlottyMedia.Backend.Services

Service for searching users and topics.

```csharp
public class SearchService : SlottyMedia.Backend.Services.Interfaces.ISearchService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [SearchService](./slottymedia.backend.services.searchservice.md)<br>
Implements [ISearchService](./slottymedia.backend.services.interfaces.isearchservice.md)

## Constructors

### **SearchService(IDatabaseActions)**

Constructor to initialize the database actions dependency.

```csharp
public SearchService(IDatabaseActions databaseActions)
```

#### Parameters

`databaseActions` IDatabaseActions<br>
The database actions dependency.

## Methods

### **SearchByUsernameOrTopic(String)**

```csharp
public Task<SearchDto> SearchByUsernameOrTopic(string searchTerm)
```

#### Parameters

`searchTerm` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;SearchDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
