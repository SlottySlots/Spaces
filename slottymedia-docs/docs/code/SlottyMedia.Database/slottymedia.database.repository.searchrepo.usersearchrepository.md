# UserSearchRepository

Namespace: SlottyMedia.Database.Repository.SearchRepo

Repository class for managing user searches in the database.

```csharp
public class UserSearchRepository : SlottyMedia.Database.Repository.DatabaseRepository`1[[SlottyMedia.Database.Daos.UserDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], SlottyMedia.Database.Repository.IDatabaseRepository`1[[SlottyMedia.Database.Daos.UserDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], IUserSeachRepository
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DatabaseRepository&lt;UserDao&gt;](./slottymedia.database.repository.databaserepository-1.md) → [UserSearchRepository](./slottymedia.database.repository.searchrepo.usersearchrepository.md)<br>
Implements [IDatabaseRepository&lt;UserDao&gt;](./slottymedia.database.repository.idatabaserepository-1.md), [IUserSeachRepository](./slottymedia.database.repository.searchrepo.iuserseachrepository.md)

## Constructors

### **UserSearchRepository(Client, DaoHelper, DatabaseRepositroyHelper)**

Base constructor for the [UserSearchRepository](./slottymedia.database.repository.searchrepo.usersearchrepository.md).

```csharp
public UserSearchRepository(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper)
```

#### Parameters

`client` Client<br>
The Supabase client instance.

`daoHelper` [DaoHelper](./slottymedia.database.helper.daohelper.md)<br>
The data access object helper instance.

`databaseRepositroyHelper` [DatabaseRepositroyHelper](./slottymedia.database.helper.databaserepositroyhelper.md)<br>
The database repository helper instance.

## Methods

### **GetUsersByUserName(String)**

```csharp
public Task<List<UserDao>> GetUsersByUserName(string userName)
```

#### Parameters

`userName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;List&lt;UserDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
