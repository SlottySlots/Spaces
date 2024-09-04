# IPostService

Namespace: SlottyMedia.Backend.Services.Interfaces

Interface for post-related services.

```csharp
public interface IPostService
```

## Methods

### **GetAllPosts(PageRequest)**

Fetches all posts sorted by date in descending order. Fetches only a specified number of posts
 on the specified page.

```csharp
Task<IPage<PostDto>> GetAllPosts(PageRequest pageRequest)
```

#### Parameters

`pageRequest` PageRequest<br>
The page request

#### Returns

[Task&lt;IPage&lt;PostDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of PostDto objects.

#### Exceptions

[PostNotFoundException](./slottymedia.backend.exceptions.services.postexceptions.postnotfoundexception.md)<br>
Thrown when the posts are not found.

[PostGeneralException](./slottymedia.backend.exceptions.services.postexceptions.postgeneralexception.md)<br>
Thrown when a general error occurs.

### **CountAllPosts()**

Counts all existing posts.

```csharp
Task<int> CountAllPosts()
```

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
The total number of existing posts

### **GetPostById(Guid)**

Attempts to fetch a post by ID. Returns null if such a post could not be found.

```csharp
Task<PostDto> GetPostById(Guid postId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The post's ID.

#### Returns

[Task&lt;PostDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains the post or null if not found.

#### Exceptions

[PostNotFoundException](./slottymedia.backend.exceptions.services.postexceptions.postnotfoundexception.md)<br>
Thrown when the post is not found.

[PostGeneralException](./slottymedia.backend.exceptions.services.postexceptions.postgeneralexception.md)<br>
Thrown when a general error occurs.

### **InsertPost(String, Guid, Guid)**

Inserts a new post into the database.

```csharp
Task InsertPost(string content, Guid creatorUserId, Guid forumId)
```

#### Parameters

`content` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The content of the post.

`creatorUserId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The UserId who created the post.

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the forum the post should belong to.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task that represents the asynchronous operation. The task result contains the inserted post.

#### Exceptions

[PostIudException](./slottymedia.backend.exceptions.services.postexceptions.postiudexception.md)<br>
Thrown when an error occurs during Insert, Update, or Delete operations.

[PostGeneralException](./slottymedia.backend.exceptions.services.postexceptions.postgeneralexception.md)<br>
Thrown when a general error occurs.

### **UpdatePost(PostsDao)**

Updates an existing post in the database.

```csharp
Task UpdatePost(PostsDao post)
```

#### Parameters

`post` PostsDao<br>
The post to update.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task that represents the asynchronous operation. The task result contains the updated post.

#### Exceptions

[PostIudException](./slottymedia.backend.exceptions.services.postexceptions.postiudexception.md)<br>
Thrown when an error occurs during Insert, Update, or Delete operations.

[PostGeneralException](./slottymedia.backend.exceptions.services.postexceptions.postgeneralexception.md)<br>
Thrown when a general error occurs.

### **DeletePost(PostsDao)**

Deletes a post from the database.

```csharp
Task DeletePost(PostsDao post)
```

#### Parameters

`post` PostsDao<br>
The post to delete.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task that represents the asynchronous operation. The task result indicates whether the deletion was
 successful.

#### Exceptions

[PostIudException](./slottymedia.backend.exceptions.services.postexceptions.postiudexception.md)<br>
Thrown when an error occurs during Insert, Update, or Delete operations.

[PostGeneralException](./slottymedia.backend.exceptions.services.postexceptions.postgeneralexception.md)<br>
Thrown when a general error occurs.

### **GetForumCountByUserId(Guid)**

This method fetches the number of forums the user has created posts in.

```csharp
Task<int> GetForumCountByUserId(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user.

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains the number of forums.

#### Exceptions

[PostGeneralException](./slottymedia.backend.exceptions.services.postexceptions.postgeneralexception.md)<br>
Thrown when a general error occurs.

### **GetPostsByUserId(Guid, PageRequest)**

Gets posts of a user by their id and enables slicing via offsets.

```csharp
Task<IPage<PostDto>> GetPostsByUserId(Guid userId, PageRequest pageRequest)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user that the posts belong to.

`pageRequest` PageRequest<br>
The page request

#### Returns

[Task&lt;IPage&lt;PostDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of PostDto objects.

#### Exceptions

[PostNotFoundException](./slottymedia.backend.exceptions.services.postexceptions.postnotfoundexception.md)<br>
Thrown when the posts are not found.

[PostGeneralException](./slottymedia.backend.exceptions.services.postexceptions.postgeneralexception.md)<br>
Thrown when a general error occurs.

### **GetPostsByForumId(Guid, PageRequest)**

```csharp
Task<IPage<PostDto>> GetPostsByForumId(Guid forumId, PageRequest pageRequest)
```

#### Parameters

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`pageRequest` PageRequest<br>

#### Returns

[Task&lt;IPage&lt;PostDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
