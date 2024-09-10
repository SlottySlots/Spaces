# UserRepository

Namespace: SlottyMedia.Database.Repository.UserRepo

This class provides methods to interact with the user table.

```csharp
public class UserRepository : SlottyMedia.Database.Repository.DatabaseRepository`1[[SlottyMedia.Database.Daos.UserDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], SlottyMedia.Database.Repository.IDatabaseRepository`1[[SlottyMedia.Database.Daos.UserDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], IUserRepository
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DatabaseRepository&lt;UserDao&gt;](./slottymedia.database.repository.databaserepository-1.md) → [UserRepository](./slottymedia.database.repository.userrepo.userrepository.md)<br>
Implements [IDatabaseRepository&lt;UserDao&gt;](./slottymedia.database.repository.idatabaserepository-1.md), [IUserRepository](./slottymedia.database.repository.userrepo.iuserrepository.md)

## Constructors

### **UserRepository(Client, DaoHelper, DatabaseRepositroyHelper)**

Base constructor for the [UserRepository](./slottymedia.database.repository.userrepo.userrepository.md).

```csharp
public UserRepository(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper)
```

#### Parameters

`client` Client<br>

`daoHelper` [DaoHelper](./slottymedia.database.helper.daohelper.md)<br>

`databaseRepositroyHelper` [DatabaseRepositroyHelper](./slottymedia.database.helper.databaserepositroyhelper.md)<br>

## Methods

### **GetUserByUsername(String)**

```csharp
public Task<UserDao> GetUserByUsername(string username)
```

#### Parameters

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;UserDao&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetUserByEmail(String)**

```csharp
public Task<UserDao> GetUserByEmail(string email)
```

#### Parameters

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;UserDao&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
