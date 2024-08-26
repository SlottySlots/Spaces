# IUserRepository

Namespace: SlottyMedia.Database.Repository.UserRepo

```csharp
public interface IUserRepository : SlottyMedia.Database.IDatabaseRepository`1[[SlottyMedia.Database.Daos.UserDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Implements [IDatabaseRepository&lt;UserDao&gt;](./slottymedia.database.idatabaserepository-1.md)

## Methods

### **GetUserByUsername(String)**

```csharp
Task<UserDao> GetUserByUsername(string username)
```

#### Parameters

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;UserDao&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetUserByEmail(String)**

```csharp
Task<UserDao> GetUserByEmail(string email)
```

#### Parameters

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;UserDao&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
