# IPostService

Namespace: SlottyMedia.Backend.Services.Interfaces

Interface for post-related services.

```csharp
public interface IPostService
```

## Properties

### **PostRepository**

DatabaseActions property.

```csharp
public abstract IPostRepository PostRepository { get; set; }
```

#### Property Value

IPostRepository<br>

## Methods

### **GetPostsFromForum(Guid, Int32, Int32)**

Retrieves a list of post titles from a forum for a given user, limited by the specified number.

```csharp
Task<List<string>> GetPostsFromForum(Guid userId, int startOfSet, int endOfSet)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user.

`startOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The start index of the set.

`endOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The end index of the set.

#### Returns

[Task&lt;List&lt;String&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of post titles.

#### Exceptions

[PostNotFoundException](./slottymedia.backend.exceptions.services.postexceptions.postnotfoundexception.md)<br>
Thrown when the posts are not found.

[PostGeneralException](./slottymedia.backend.exceptions.services.postexceptions.postgeneralexception.md)<br>
Thrown when a general error occurs.

### **GetAllPosts(Int32, Int32)**

Fetches all posts sorted by date in descending order. Fetches only a specified number of posts
 on the specified page.

```csharp
Task<List<PostDto>> GetAllPosts(int page, int pageSize)
```

#### Parameters

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The page to fetch (one-based).

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The number of posts per page (default is 10).

#### Returns

[Task&lt;List&lt;PostDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
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

### **GetPostsByUserId(Guid, Int32, Int32)**

Gets posts of a user by their id and enables slicing via offsets.

```csharp
Task<List<PostDto>> GetPostsByUserId(Guid userId, int startOfSet, int endOfSet)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user that the posts belong to.

`startOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The start index of the posts sorted by date.

`endOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The end index of the posts sorted by date.

#### Returns

[Task&lt;List&lt;PostDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of PostDto objects.

#### Exceptions

[PostNotFoundException](./slottymedia.backend.exceptions.services.postexceptions.postnotfoundexception.md)<br>
Thrown when the posts are not found.

[PostGeneralException](./slottymedia.backend.exceptions.services.postexceptions.postgeneralexception.md)<br>
Thrown when a general error occurs.
