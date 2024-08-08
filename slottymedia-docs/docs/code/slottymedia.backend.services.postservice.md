# PostService

Namespace: SlottyMedia.Backend.Services

This class represents the Post Service. It is used to interact with the Post table in the database.

```csharp
public class PostService : SlottyMedia.Backend.Services.Interfaces.IPostService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PostService](./slottymedia.backend.services.postservice.md)<br>
Implements [IPostService](./slottymedia.backend.services.interfaces.ipostservice.md)

## Properties

### **DatabaseActions**

DatabaseActions property.

```csharp
public IDatabaseActions DatabaseActions { get; set; }
```

#### Property Value

IDatabaseActions<br>

## Constructors

### **PostService(IDatabaseActions)**

Initializes a new instance of the [PostService](./slottymedia.backend.services.postservice.md) class.

```csharp
public PostService(IDatabaseActions databaseActions)
```

#### Parameters

`databaseActions` IDatabaseActions<br>
The database actions interface.

## Methods

### **InsertPost(String, String, Guid, Guid)**

Inserts a new post into the database.

```csharp
public Task<PostsDao> InsertPost(string title, string content, Guid creatorUserId, Guid forumId)
```

#### Parameters

`title` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The title of the post.

`content` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The content of the post.

`creatorUserId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user who created the post.

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the forum where the post is created.

#### Returns

[Task&lt;PostsDao&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains the inserted post.

### **UpdatePost(PostsDao)**

Updates an existing post in the database.

```csharp
public Task<PostsDao> UpdatePost(PostsDao post)
```

#### Parameters

`post` PostsDao<br>
The post to update.

#### Returns

[Task&lt;PostsDao&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains the updated post.

### **DeletePost(PostsDao)**

Deletes a post from the database.

```csharp
public Task<bool> DeletePost(PostsDao post)
```

#### Parameters

`post` PostsDao<br>
The post to delete.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result indicates whether the deletion was successful.

### **GetPostsFromForum(Guid, Int32, Int32)**

Retrieves a list of post titles from a forum for a given user, limited by the specified number.

```csharp
public Task<List<string>> GetPostsFromForum(Guid userId, int startOfSet, int endOfSet)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user.

`startOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`endOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Task&lt;List&lt;String&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of post titles.

### **GetPostsByUserId(Guid, Int32, Int32)**

This method returns a list of posts from the database based on the given userId.

```csharp
public Task<List<PostDto>> GetPostsByUserId(Guid userId, int startOfSet, int endOfSet)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`startOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`endOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Task&lt;List&lt;PostDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetPostsByUserIdByForumId(Guid, Int32, Int32, Guid)**

This method returns a list of posts from the database based on the given userId and forumId.

```csharp
public Task<List<PostDto>> GetPostsByUserIdByForumId(Guid userId, int startOfSet, int endOfSet, Guid forumId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`startOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`endOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;List&lt;PostDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetPostsByForumId(Guid, Int32, Int32)**

This method returns a list of posts from the database based on the given forumId.

```csharp
public Task<List<PostDto>> GetPostsByForumId(Guid forumId, int startOfSet, int endOfSet)
```

#### Parameters

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`startOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`endOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Task&lt;List&lt;PostDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>