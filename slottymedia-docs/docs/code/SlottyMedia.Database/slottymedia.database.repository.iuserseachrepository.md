# IUserSeachRepository

Namespace: SlottyMedia.Database.Repository

```csharp
public interface IUserSeachRepository : SlottyMedia.Database.IDatabaseRepository`1[[SlottyMedia.Database.Daos.UserDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Implements [IDatabaseRepository&lt;UserDao&gt;](./slottymedia.database.idatabaserepository-1.md)

## Methods

### **GetUsersByUserName(String, Int32, Int32)**

```csharp
Task<List<UserDao>> GetUsersByUserName(string userName, int page, int pageSize)
```

#### Parameters

`userName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Task&lt;List&lt;UserDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
