# ITopForumRepository

Namespace: SlottyMedia.Database.Repository.ForumRepo

Interface for the Top Forum Repository.

```csharp
public interface ITopForumRepository : SlottyMedia.Database.Repository.IDatabaseRepository`1[[SlottyMedia.Database.Daos.TopForumDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Implements [IDatabaseRepository&lt;TopForumDao&gt;](./slottymedia.database.repository.idatabaserepository-1.md)

## Methods

### **DetermineRecentSpaces()**

Determines the recent spaces.

```csharp
Task<List<TopForumDao>> DetermineRecentSpaces()
```

#### Returns

[Task&lt;List&lt;TopForumDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of recent spaces.

#### Exceptions

[DatabaseMissingItemException](./slottymedia.database.exceptions.databasemissingitemexception.md)<br>
Thrown when the entity is not found in the database.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when an unexpected error occurs.

[DatabaseJsonConvertFailed](./slottymedia.database.exceptions.databasejsonconvertfailed.md)<br>
Thrown when the Database Result was not able to be converted to a Class Dao

### **GetTopForums()**

Gets the top forums.

```csharp
Task<List<TopForumDao>> GetTopForums()
```

#### Returns

[Task&lt;List&lt;TopForumDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of top forums.

#### Exceptions

[DatabaseMissingItemException](./slottymedia.database.exceptions.databasemissingitemexception.md)<br>
Thrown when the entity is not found in the database.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when an unexpected error occurs.

[DatabaseJsonConvertFailed](./slottymedia.database.exceptions.databasejsonconvertfailed.md)<br>
Thrown when the Database Result was not able to be converted to a Class Dao
