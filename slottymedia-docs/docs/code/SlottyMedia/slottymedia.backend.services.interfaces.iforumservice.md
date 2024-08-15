# IForumService

Namespace: SlottyMedia.Backend.Services.Interfaces

The IForumService interface is responsible for handling forum related operations.

```csharp
public interface IForumService
```

## Methods

### **InsertForum(ForumDto)**

Inserts a new forum into the database.

```csharp
Task<ForumDto> InsertForum(ForumDto forum)
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
