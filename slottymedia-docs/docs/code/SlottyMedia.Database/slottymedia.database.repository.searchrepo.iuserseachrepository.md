# IUserSeachRepository

Namespace: SlottyMedia.Database.Repository.SearchRepo

Interface for the User Search Repository.

```csharp
public interface IUserSeachRepository : SlottyMedia.Database.Repository.IDatabaseRepository`1[[SlottyMedia.Database.Daos.UserDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Implements [IDatabaseRepository&lt;UserDao&gt;](./slottymedia.database.repository.idatabaserepository-1.md)

## Methods

### **GetUsersByUserName(String, Int32, Int32)**

Gets users by their username with pagination.

```csharp
Task<List<UserDao>> GetUsersByUserName(string userName, int page, int pageSize)
```

#### Parameters

`userName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The username to search for.

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The page number.

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The size of the page.

#### Returns

[Task&lt;List&lt;UserDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of users.
