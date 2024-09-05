# IUserSeachRepository

Namespace: SlottyMedia.Database.Repository.SearchRepo

Interface for the User Search Repository.

```csharp
public interface IUserSeachRepository : SlottyMedia.Database.Repository.IDatabaseRepository`1[[SlottyMedia.Database.Daos.UserDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Implements [IDatabaseRepository&lt;UserDao&gt;](./slottymedia.database.repository.idatabaserepository-1.md)

## Methods

### **GetUsersByUserName(String)**

Gets users by their username with pagination.

```csharp
Task<List<UserDao>> GetUsersByUserName(string userName)
```

#### Parameters

`userName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The username to search for.

#### Returns

[Task&lt;List&lt;UserDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of users.

#### Exceptions

[DatabaseMissingItemException](./slottymedia.database.exceptions.databasemissingitemexception.md)<br>
Thrown when the entity is not found in the database.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when an unexpected error occurs.

[DatabaseJsonConvertFailed](./slottymedia.database.exceptions.databasejsonconvertfailed.md)<br>
Thrown when the Database Result was not able to be converted to a Class Dao
