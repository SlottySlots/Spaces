# UserSearchRepository

Namespace: SlottyMedia.Database.Repository

```csharp
public class UserSearchRepository : DatabaseRepository`1, SlottyMedia.Database.IDatabaseRepository`1[[SlottyMedia.Database.Daos.UserDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], IUserSeachRepository
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DatabaseRepository&lt;UserDao&gt;](./slottymedia.database.repository.databaserepository-1.md) → [UserSearchRepository](./slottymedia.database.repository.usersearchrepository.md)<br>
Implements [IDatabaseRepository&lt;UserDao&gt;](./slottymedia.database.idatabaserepository-1.md), [IUserSeachRepository](./slottymedia.database.repository.iuserseachrepository.md)

## Constructors

### **UserSearchRepository(Client, DaoHelper, DatabaseRepositroyHelper)**

Base constructor for the [UserSearchRepository](./slottymedia.database.repository.usersearchrepository.md).

```csharp
public UserSearchRepository(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper)
```

#### Parameters

`client` Client<br>

`daoHelper` [DaoHelper](./slottymedia.database.helper.daohelper.md)<br>

`databaseRepositroyHelper` [DatabaseRepositroyHelper](./slottymedia.database.helper.databaserepositroyhelper.md)<br>

## Methods

### **GetUsersByUserName(String, Int32, Int32)**

```csharp
public Task<List<UserDao>> GetUsersByUserName(string userName, int page, int pageSize)
```

#### Parameters

`userName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Task&lt;List&lt;UserDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
