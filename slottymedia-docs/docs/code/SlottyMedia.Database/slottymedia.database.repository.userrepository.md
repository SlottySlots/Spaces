# UserRepository

Namespace: SlottyMedia.Database.Repository

This class provides methods to interact with the user table.

```csharp
public class UserRepository : DatabaseRepository`1, SlottyMedia.Database.IDatabaseRepository`1[[SlottyMedia.Database.Daos.UserDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], SlottyMedia.Database.IUserRepository
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DatabaseRepository&lt;UserDao&gt;](./slottymedia.database.repository.databaserepository-1.md) → [UserRepository](./slottymedia.database.repository.userrepository.md)<br>
Implements [IDatabaseRepository&lt;UserDao&gt;](./slottymedia.database.idatabaserepository-1.md), [IUserRepository](./slottymedia.database.iuserrepository.md)

## Constructors

### **UserRepository(Client, DaoHelper, DatabaseRepositroyHelper)**

Base constructor for the [UserRepository](./slottymedia.database.repository.userrepository.md).

```csharp
public UserRepository(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper)
```

#### Parameters

`client` Client<br>

`daoHelper` [DaoHelper](./slottymedia.database.repository.daohelper.md)<br>

`databaseRepositroyHelper` [DatabaseRepositroyHelper](./slottymedia.database.repository.databaserepositroyhelper.md)<br>
