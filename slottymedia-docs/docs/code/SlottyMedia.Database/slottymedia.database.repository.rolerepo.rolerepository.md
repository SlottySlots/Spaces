# RoleRepository

Namespace: SlottyMedia.Database.Repository.RoleRepo

This class is used to manage roles in the database.

```csharp
public class RoleRepository : SlottyMedia.Database.Repository.DatabaseRepository`1[[SlottyMedia.Database.Daos.RoleDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], SlottyMedia.Database.IDatabaseRepository`1[[SlottyMedia.Database.Daos.RoleDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], IRoleRepository
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DatabaseRepository&lt;RoleDao&gt;](./slottymedia.database.repository.databaserepository-1.md) → [RoleRepository](./slottymedia.database.repository.rolerepo.rolerepository.md)<br>
Implements [IDatabaseRepository&lt;RoleDao&gt;](./slottymedia.database.idatabaserepository-1.md), [IRoleRepository](./slottymedia.database.repository.rolerepo.irolerepository.md)

## Constructors

### **RoleRepository(Client, DaoHelper, DatabaseRepositroyHelper)**

Base constructor for the [RoleRepository](./slottymedia.database.repository.rolerepo.rolerepository.md).

```csharp
public RoleRepository(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper)
```

#### Parameters

`client` Client<br>
The Supabase client instance.

`daoHelper` [DaoHelper](./slottymedia.database.helper.daohelper.md)<br>
The data access object helper instance.

`databaseRepositroyHelper` [DatabaseRepositroyHelper](./slottymedia.database.helper.databaserepositroyhelper.md)<br>
The database repository helper instance.

## Methods

### **GetRoleIdByName(String)**

```csharp
public Task<Guid> GetRoleIdByName(string roleName)
```

#### Parameters

`roleName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
