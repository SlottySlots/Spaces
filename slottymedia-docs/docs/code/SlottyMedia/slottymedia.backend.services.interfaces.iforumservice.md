# IForumService

Namespace: SlottyMedia.Backend.Services.Interfaces

The IForumService interface is responsible for handling forum related operations.

```csharp
public interface IForumService
```

## Methods

### **InsertForum(Guid, String)**

Inserts a new forum into the database.

```csharp
Task InsertForum(Guid creatorUserId, string forumTopic)
```

#### Parameters

`creatorUserId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The Creator UserID

`forumTopic` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Topic from the Forum

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
Returns the inserted ForumDto object.

#### Exceptions

[ForumIudException](./slottymedia.backend.exceptions.services.forumexceptions.forumiudexception.md)<br>
Thrown when an error occurs during Insert, Update, or Delete operations.

[ForumGeneralException](./slottymedia.backend.exceptions.services.forumexceptions.forumgeneralexception.md)<br>
Thrown when a general error occurs.

### **DeleteForum(ForumDto)**

Deletes a forum from the database based on the given forum ID.

```csharp
Task DeleteForum(ForumDto forum)
```

#### Parameters

`forum` [ForumDto](./slottymedia.backend.dtos.forumdto.md)<br>
The forum to delete.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
Returns a Task representing the asynchronous operation.

#### Exceptions

[ForumIudException](./slottymedia.backend.exceptions.services.forumexceptions.forumiudexception.md)<br>
Thrown when an error occurs during Insert, Update, or Delete operations.

[ForumGeneralException](./slottymedia.backend.exceptions.services.forumexceptions.forumgeneralexception.md)<br>
Thrown when a general error occurs.

### **GetForumByName(String)**

Retrieves a forum with the given name.

```csharp
Task<ForumDto> GetForumByName(string forumName)
```

#### Parameters

`forumName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The forum's name.

#### Returns

[Task&lt;ForumDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
The requested forum

#### Exceptions

[ForumNotFoundException](./slottymedia.backend.exceptions.services.forumexceptions.forumnotfoundexception.md)<br>
Thrown when the forum is not found.

[ForumGeneralException](./slottymedia.backend.exceptions.services.forumexceptions.forumgeneralexception.md)<br>
Thrown when a general error occurs.

### **GetAllForums(PageRequest)**

```csharp
Task<IPage<ForumDto>> GetAllForums(PageRequest pageRequest)
```

#### Parameters

`pageRequest` PageRequest<br>

#### Returns

[Task&lt;IPage&lt;ForumDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **DetermineRecentSpaces()**

Retrieves the 3 most recent forums based on the creation date.

```csharp
Task<List<ForumDto>> DetermineRecentSpaces()
```

#### Returns

[Task&lt;List&lt;ForumDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of the 3 most recent
 ForumDto objects.

#### Exceptions

[ForumNotFoundException](./slottymedia.backend.exceptions.services.forumexceptions.forumnotfoundexception.md)<br>
Thrown when the forums are not found.

[ForumGeneralException](./slottymedia.backend.exceptions.services.forumexceptions.forumgeneralexception.md)<br>
Thrown when a general error occurs.

### **GetTopForums()**

Retrieves the top forums.

```csharp
Task<List<ForumDto>> GetTopForums()
```

#### Returns

[Task&lt;List&lt;ForumDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of ForumDto objects
 representing the top forums.

#### Exceptions

[ForumNotFoundException](./slottymedia.backend.exceptions.services.forumexceptions.forumnotfoundexception.md)<br>
Thrown when the forums are not found.

[ForumGeneralException](./slottymedia.backend.exceptions.services.forumexceptions.forumgeneralexception.md)<br>
Thrown when a general error occurs.
