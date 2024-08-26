# IPostRepository

Namespace: SlottyMedia.Database.Repository.PostRepo

```csharp
public interface IPostRepository : SlottyMedia.Database.IDatabaseRepository`1[[SlottyMedia.Database.Daos.PostsDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Implements [IDatabaseRepository&lt;PostsDao&gt;](./slottymedia.database.idatabaserepository-1.md)

## Methods

### **GetForumCountByUserId(Guid)**

```csharp
Task<int> GetForumCountByUserId(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetAllElements(Int32, Int32)**

```csharp
Task<List<PostsDao>> GetAllElements(int page, int pageSize)
```

#### Parameters

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Task&lt;List&lt;PostsDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetPostsByUserId(Guid, Int32, Int32)**

```csharp
Task<List<PostsDao>> GetPostsByUserId(Guid userId, int page, int pageSize)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Task&lt;List&lt;PostsDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetPostsByUserIdByForumId(Guid, Guid, Int32, Int32)**

```csharp
Task<List<PostsDao>> GetPostsByUserIdByForumId(Guid userId, Guid forumId, int page, int pageSize)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Task&lt;List&lt;PostsDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetPostsByForumId(Guid, Int32, Int32)**

```csharp
Task<List<PostsDao>> GetPostsByForumId(Guid forumId, int page, int pageSize)
```

#### Parameters

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Task&lt;List&lt;PostsDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
