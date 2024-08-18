# ForumService

Namespace: SlottyMedia.Backend.Services

The ForumService class is responsible for handling forum related operations.

```csharp
public class ForumService : SlottyMedia.Backend.Services.Interfaces.IForumService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ForumService](./slottymedia.backend.services.forumservice.md)<br>
Implements [IForumService](./slottymedia.backend.services.interfaces.iforumservice.md)

## Constructors

### **ForumService(IDatabaseActions)**

```csharp
public ForumService(IDatabaseActions databaseActions)
```

#### Parameters

`databaseActions` IDatabaseActions<br>

## Methods

### **InsertForum(ForumDto)**

Inserts a new forum into the database.

```csharp
public Task<ForumDto> InsertForum(ForumDto forum)
```

#### Parameters

`forum` [ForumDto](./slottymedia.backend.dtos.forumdto.md)<br>
The ForumDto object containing the forum details.

#### Returns

[Task&lt;ForumDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns the inserted ForumDto object.

#### Exceptions

T:SlottyMedia.Database.Exceptions.GeneralDatabaseException<br>
Throws an exception if an error occurs while inserting the forum.

### **DeleteForum(ForumDto)**

Deletes a forum from the database based on the given forum ID.

```csharp
public Task DeleteForum(ForumDto forum)
```

#### Parameters

`forum` [ForumDto](./slottymedia.backend.dtos.forumdto.md)<br>
The the forum to delete.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
Returns a Task representing the asynchronous operation.

#### Exceptions

T:SlottyMedia.Database.Exceptions.GeneralDatabaseException<br>
Throws an exception if an error occurs while deleting the forum.