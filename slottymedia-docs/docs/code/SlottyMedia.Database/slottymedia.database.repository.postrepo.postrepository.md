# PostRepository

Namespace: SlottyMedia.Database.Repository.PostRepo

Repository class for managing posts in the database.

```csharp
public class PostRepository : SlottyMedia.Database.Repository.DatabaseRepository`1[[SlottyMedia.Database.Daos.PostsDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], SlottyMedia.Database.Repository.IDatabaseRepository`1[[SlottyMedia.Database.Daos.PostsDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], IPostRepository
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DatabaseRepository&lt;PostsDao&gt;](./slottymedia.database.repository.databaserepository-1.md) → [PostRepository](./slottymedia.database.repository.postrepo.postrepository.md)<br>
Implements [IDatabaseRepository&lt;PostsDao&gt;](./slottymedia.database.repository.idatabaserepository-1.md), [IPostRepository](./slottymedia.database.repository.postrepo.ipostrepository.md)

## Constructors

### **PostRepository(Client, DaoHelper, DatabaseRepositroyHelper)**

Base constructor for the [PostRepository](./slottymedia.database.repository.postrepo.postrepository.md).

```csharp
public PostRepository(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper)
```

#### Parameters

`client` Client<br>
The Supabase client instance.

`daoHelper` [DaoHelper](./slottymedia.database.helper.daohelper.md)<br>
The data access object helper instance.

`databaseRepositroyHelper` [DatabaseRepositroyHelper](./slottymedia.database.helper.databaserepositroyhelper.md)<br>
The database repository helper instance.

## Methods

### **GetAllElements()**

Fetches all posts and orders them by date created in descending order.

```csharp
public Task<List<PostsDao>> GetAllElements()
```

#### Returns

[Task&lt;List&lt;PostsDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
The posts in a list

### **GetAllElements(PageRequest)**

Fetches all posts and orders them by date created in descending order.
 Only fetches posts on the specified page of the specified size.

```csharp
public Task<IPage<PostsDao>> GetAllElements(PageRequest pageRequest)
```

#### Parameters

`pageRequest` [PageRequest](./slottymedia.database.pagination.pagerequest.md)<br>
The page request

#### Returns

[Task&lt;IPage&lt;PostsDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
The page containing the requested posts

### **GetForumCountByUserId(Guid)**

```csharp
public Task<int> GetForumCountByUserId(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **CountAllPosts()**

```csharp
public Task<int> CountAllPosts()
```

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetPostsByUserId(Guid, PageRequest)**

```csharp
public Task<IPage<PostsDao>> GetPostsByUserId(Guid userId, PageRequest pageRequest)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`pageRequest` [PageRequest](./slottymedia.database.pagination.pagerequest.md)<br>

#### Returns

[Task&lt;IPage&lt;PostsDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetPostsByUserIdByForumId(Guid, Guid, PageRequest)**

```csharp
public Task<IPage<PostsDao>> GetPostsByUserIdByForumId(Guid userId, Guid forumId, PageRequest pageRequest)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`pageRequest` [PageRequest](./slottymedia.database.pagination.pagerequest.md)<br>

#### Returns

[Task&lt;IPage&lt;PostsDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetPostsByForumId(Guid, PageRequest)**

```csharp
public Task<IPage<PostsDao>> GetPostsByForumId(Guid forumId, PageRequest pageRequest)
```

#### Parameters

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`pageRequest` [PageRequest](./slottymedia.database.pagination.pagerequest.md)<br>

#### Returns

[Task&lt;IPage&lt;PostsDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
