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
Task<ForumDto> InsertForum(Guid creatorUserId, string forumTopic)
```

#### Parameters

`creatorUserId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The Creator UserID

`forumTopic` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Topic from the Forum

#### Returns

[Task&lt;ForumDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the inserted ForumDto object.

#### Exceptions

T:SlottyMedia.Database.Exceptions.GeneralDatabaseException<br>
Throws an exception if an error occurs while inserting the forum.

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

T:SlottyMedia.Database.Exceptions.GeneralDatabaseException<br>
Throws an exception if an error occurs while deleting the forum.

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

### **GetForumsByNameContaining(String, Int32, Int32)**

Fetches all forums by name where the name contains the given substring.
 Fetches only a specified number of forums on the specified page.

```csharp
Task<List<ForumDto>> GetForumsByNameContaining(string name, int page, int pageSize)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The substring that should be contained by the forums' name

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The page to fetch (one-based)

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The size of each page (default is 10)

#### Returns

[Task&lt;List&lt;ForumDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
All forums where the name of each forum contains the given substring
