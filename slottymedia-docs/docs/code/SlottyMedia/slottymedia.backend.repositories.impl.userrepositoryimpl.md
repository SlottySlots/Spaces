# UserRepositoryImpl

Namespace: SlottyMedia.Backend.Repositories.Impl

```csharp
public class UserRepositoryImpl : SupabaseRepository`1, SlottyMedia.Backend.Repositories.IRepository`1[[SlottyMedia.Database.Daos.UserDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], SlottyMedia.Backend.Repositories.IUserRepository
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [SupabaseRepository&lt;UserDao&gt;](./slottymedia.backend.repositories.impl.supabaserepository-1.md) → [UserRepositoryImpl](./slottymedia.backend.repositories.impl.userrepositoryimpl.md)<br>
Implements [IRepository&lt;UserDao&gt;](./slottymedia.backend.repositories.irepository-1.md), [IUserRepository](./slottymedia.backend.repositories.iuserrepository.md)

## Constructors

### **UserRepositoryImpl(Client)**

Instantiates a [UserRepositoryImpl](./slottymedia.backend.repositories.impl.userrepositoryimpl.md)

```csharp
public UserRepositoryImpl(Client supabase)
```

#### Parameters

`supabase` Client<br>
An object that exposes the Supabase API

## Methods

### **GetById(Guid)**

```csharp
public Task<UserDao> GetById(Guid entityId)
```

#### Parameters

`entityId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;UserDao&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetUserByUsername(String)**

```csharp
public Task<UserDao> GetUserByUsername(string username)
```

#### Parameters

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;UserDao&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
