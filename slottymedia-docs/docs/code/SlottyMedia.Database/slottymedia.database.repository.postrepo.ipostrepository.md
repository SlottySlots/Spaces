# IPostRepository

Namespace: SlottyMedia.Database.Repository.PostRepo

Interface for the Post Repository.

```csharp
public interface IPostRepository : SlottyMedia.Database.Repository.IDatabaseRepository`1[[SlottyMedia.Database.Daos.PostsDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Implements [IDatabaseRepository&lt;PostsDao&gt;](./slottymedia.database.repository.idatabaserepository-1.md)

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

### **GetAllElements(PageRequest)**

Gets all elements with pagination.

```csharp
Task<IPage<PostsDao>> GetAllElements(PageRequest pageRequest)
```

#### Parameters

`pageRequest` [PageRequest](./slottymedia.database.pagination.pagerequest.md)<br>
The page request

#### Returns

[Task&lt;IPage&lt;PostsDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of elements.

#### Exceptions

[DatabaseMissingItemException](./slottymedia.database.exceptions.databasemissingitemexception.md)<br>
Thrown when the entity is not found in the database.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when an unexpected error occurs.

### **CountAllPosts()**

Counts all existing posts.

```csharp
Task<int> CountAllPosts()
```

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
The total number of existing posts

### **GetPostsByUserId(Guid, PageRequest)**

Gets posts by a specific user with pagination.

```csharp
Task<IPage<PostsDao>> GetPostsByUserId(Guid userId, PageRequest pageRequest)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The unique identifier of the user.

`pageRequest` [PageRequest](./slottymedia.database.pagination.pagerequest.md)<br>
The page request

#### Returns

[Task&lt;IPage&lt;PostsDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of posts.

#### Exceptions

[DatabaseMissingItemException](./slottymedia.database.exceptions.databasemissingitemexception.md)<br>
Thrown when the entity is not found in the database.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when an unexpected error occurs.

### **GetPostsByUserIdByForumId(Guid, Guid, PageRequest)**

Gets posts by a specific user and forum with pagination.

```csharp
Task<IPage<PostsDao>> GetPostsByUserIdByForumId(Guid userId, Guid forumId, PageRequest pageRequest)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The unique identifier of the user.

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The unique identifier of the forum.

`pageRequest` [PageRequest](./slottymedia.database.pagination.pagerequest.md)<br>
The page request

#### Returns

[Task&lt;IPage&lt;PostsDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of posts.

#### Exceptions

[DatabaseMissingItemException](./slottymedia.database.exceptions.databasemissingitemexception.md)<br>
Thrown when the entity is not found in the database.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when an unexpected error occurs.

### **GetPostsByForumId(Guid, PageRequest)**

Gets posts by a specific forum with pagination.

```csharp
Task<IPage<PostsDao>> GetPostsByForumId(Guid forumId, PageRequest pageRequest)
```

#### Parameters

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The unique identifier of the forum.

`pageRequest` [PageRequest](./slottymedia.database.pagination.pagerequest.md)<br>
The page request

#### Returns

[Task&lt;IPage&lt;PostsDao&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of posts.

#### Exceptions

[DatabaseMissingItemException](./slottymedia.database.exceptions.databasemissingitemexception.md)<br>
Thrown when the entity is not found in the database.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when an unexpected error occurs.
