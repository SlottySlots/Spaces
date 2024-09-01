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

`endOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Task&lt;List&lt;String&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of post titles.

### **GetAllPosts(Int32, Int32)**

Fetches all posts sorted by date in descending order. Fetches only a specified number of posts
 on the specified page.

```csharp
Task<List<PostDto>> GetAllPosts(int page, int pageSize)
```

#### Parameters

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The page to fetch (one-based)

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The number of posts per page (default is 10)

#### Returns

[Task&lt;List&lt;PostDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetPostById(Guid)**

Attempts to fetch a post by ID. Returns null if such a post could not be found.

```csharp
Task<PostDto> GetPostById(Guid postId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The post's ID

#### Returns

[Task&lt;PostDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
The post or null if not found

### **InsertPost(String, Guid, Guid)**

Inserts a new post into the database.

```csharp
Task InsertPost(string content, Guid creatorUserId, Guid forumId)
```

#### Parameters

`content` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The content of the post

`creatorUserId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The UserId who created the post

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the forum the post should belong to

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task that represents the asynchronous operation. The task result contains the inserted post.

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

### **DeletePost(PostsDao)**

Deletes a post from the database.

```csharp
Task DeletePost(PostsDao post)
```

#### Parameters

`post` PostsDao<br>
The the post to delete.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task that represents the asynchronous operation. The task result indicates whether the deletion was
 successful.

### **GetForumCountByUserId(Guid)**

This method fetches the number of forums the user has created posts in.

```csharp
Task<int> GetForumCountByUserId(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetPostsByUserId(Guid, Int32, Int32)**

Gets posts of a user by their id and enables slicing via offsets

```csharp
Task<List<PostDto>> GetPostsByUserId(Guid userId, int startOfSet, int endOfSet)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
User that the posts belong to

`startOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Startindex of the posts sorted by date

`endOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Endindex of the posts sorted by data

#### Returns

[Task&lt;List&lt;PostDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
List of PostDtos
