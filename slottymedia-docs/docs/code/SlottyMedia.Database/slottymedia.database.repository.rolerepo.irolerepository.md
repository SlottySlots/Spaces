# IRoleRepository

Namespace: SlottyMedia.Database.Repository.RoleRepo

Interface for Role Repository, extending the IDatabaseRepository for RoleDao.

```csharp
public interface IRoleRepository : SlottyMedia.Database.IDatabaseRepository`1[[SlottyMedia.Database.Daos.RoleDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Implements [IDatabaseRepository&lt;RoleDao&gt;](./slottymedia.database.idatabaserepository-1.md)

## Methods

### **GetRoleIdByName(String)**

Retrieves the role ID by the role name.

```csharp
Task<Guid> GetRoleIdByName(string roleName)
```

#### Parameters

`roleName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the role.

#### Returns

[Task&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains the role ID.

### **AddElement(RoleDao)**

Adds a new RoleDao element to the repository.

```csharp
Task<RoleDao> AddElement(RoleDao element)
```

#### Parameters

`element` [RoleDao](./slottymedia.database.daos.roledao.md)<br>
The RoleDao element to add.

#### Returns

[Task&lt;RoleDao&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains the added RoleDao element.

### **UpdateElement(RoleDao)**

Updates an existing RoleDao element in the repository.

```csharp
Task UpdateElement(RoleDao element)
```

#### Parameters

`element` [RoleDao](./slottymedia.database.daos.roledao.md)<br>
The RoleDao element to update.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task that represents the asynchronous operation.

### **DeleteElement(RoleDao)**

Deletes a RoleDao entity from the repository.

```csharp
Task DeleteElement(RoleDao entity)
```

#### Parameters

`entity` [RoleDao](./slottymedia.database.daos.roledao.md)<br>
The RoleDao entity to delete.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task that represents the asynchronous operation.
