# ForumService

Namespace: SlottyMedia.Backend.Services

```csharp
public class ForumService : SlottyMedia.Backend.Services.Interfaces.IForumService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ForumService](./slottymedia.backend.services.forumservice.md)<br>
Implements [IForumService](./slottymedia.backend.services.interfaces.iforumservice.md)

## Constructors

### **ForumService(IForumRepository, ITopForumRepository, ISearchService)**

```csharp
public ForumService(IForumRepository forumRepository, ITopForumRepository topForumRepository, ISearchService searchService)
```

#### Parameters

`forumRepository` IForumRepository<br>

`topForumRepository` ITopForumRepository<br>

`searchService` [ISearchService](./slottymedia.backend.services.interfaces.isearchservice.md)<br>

## Methods

### **InsertForum(Guid, String)**

```csharp
public Task InsertForum(Guid creatorUserId, string forumTopic)
```

#### Parameters

`creatorUserId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`forumTopic` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **DeleteForum(ForumDto)**

```csharp
public Task DeleteForum(ForumDto forum)
```

#### Parameters

`forum` [ForumDto](./slottymedia.backend.dtos.forumdto.md)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetForumByName(String)**

```csharp
public Task<ForumDto> GetForumByName(string forumName)
```

#### Parameters

`forumName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;ForumDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetForumById(Guid)**

```csharp
public Task<ForumDto> GetForumById(Guid forumId)
```

#### Parameters

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;ForumDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetAllForums(PageRequest)**

```csharp
public Task<IPage<ForumDto>> GetAllForums(PageRequest pageRequest)
```

#### Parameters

`pageRequest` PageRequest<br>

#### Returns

[Task&lt;IPage&lt;ForumDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **DetermineRecentSpaces()**

```csharp
public Task<List<ForumDto>> DetermineRecentSpaces()
```

#### Returns

[Task&lt;List&lt;ForumDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetTopForums()**

```csharp
public Task<List<ForumDto>> GetTopForums()
```

#### Returns

[Task&lt;List&lt;ForumDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
