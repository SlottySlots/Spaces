# IPostRepository

Namespace: SlottyMedia.Database.Repository.PostRepo

Interface for the Post Repository.

```csharp
public interface IPostRepository : SlottyMedia.Database.IDatabaseRepository`1[[SlottyMedia.Database.Daos.PostsDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Implements [IDatabaseRepository&lt;PostsDao&gt;](./slottymedia.database.idatabaserepository-1.md)

## Methods

### **GetForumCountByUserId(Guid)**

Gets the count of forums by a specific user.

```csharp
Task<int> GetForumCountByUserId(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The unique identifier of the user.

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains the count of forums.

### **GetAllElements(Int32, Int32)**

Gets all elements with pagination.

```csharp
Task<List<PostsDao>> GetAllElements(int page, int pageSize)
```

#### Parameters

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The page number.

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The size of the page.

#### Returns

[Task&lt;List&lt;PostsDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of elements.

### **GetPostsByUserId(Guid, Int32, Int32)**

Gets posts by a specific user with pagination.

```csharp
Task<List<PostsDao>> GetPostsByUserId(Guid userId, int page, int pageSize)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The unique identifier of the user.

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The page number.

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The size of the page.

#### Returns

[Task&lt;List&lt;PostsDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of posts.

### **GetPostsByUserIdByForumId(Guid, Guid, Int32, Int32)**

Gets posts by a specific user and forum with pagination.

```csharp
Task<List<PostsDao>> GetPostsByUserIdByForumId(Guid userId, Guid forumId, int page, int pageSize)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The unique identifier of the user.

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The unique identifier of the forum.

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The page number.

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The size of the page.

#### Returns

[Task&lt;List&lt;PostsDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of posts.

### **GetPostsByForumId(Guid, Int32, Int32)**

Gets posts by a specific forum with pagination.

```csharp
Task<List<PostsDao>> GetPostsByForumId(Guid forumId, int page, int pageSize)
```

#### Parameters

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The unique identifier of the forum.

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The page number.

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The size of the page.

#### Returns

[Task&lt;List&lt;PostsDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of posts.
