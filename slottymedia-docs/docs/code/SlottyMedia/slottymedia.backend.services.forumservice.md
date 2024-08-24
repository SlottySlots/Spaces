# ForumService

Namespace: SlottyMedia.Backend.Services

```csharp
public class ForumService : SlottyMedia.Backend.Services.Interfaces.IForumService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ForumService](./slottymedia.backend.services.forumservice.md)<br>
Implements [IForumService](./slottymedia.backend.services.interfaces.iforumservice.md)

## Constructors

### **ForumService(IDatabaseActions, Client)**

```csharp
public ForumService(IDatabaseActions databaseActions, Client supabaseClient)
```

#### Parameters

`databaseActions` IDatabaseActions<br>

`supabaseClient` Client<br>

## Methods

### **InsertForum(Guid, String)**

```csharp
public Task<ForumDto> InsertForum(Guid creatorUserId, string forumTopic)
```

#### Parameters

`creatorUserId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`forumTopic` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;ForumDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

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

### **GetForums()**

Retrieves all forums from the database.

```csharp
public Task<List<ForumDto>> GetForums()
```

#### Returns

[Task&lt;List&lt;ForumDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A list of ForumDto objects representing all forums.
