# PostService

Namespace: SlottyMedia.Backend.Services

```csharp
public class PostService : SlottyMedia.Backend.Services.Interfaces.IPostService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PostService](./slottymedia.backend.services.postservice.md)<br>
Implements [IPostService](./slottymedia.backend.services.interfaces.ipostservice.md)

## Constructors

### **PostService(IPostRepository)**

Initializes a new instance of the [PostService](./slottymedia.backend.services.postservice.md) class.

```csharp
public PostService(IPostRepository postRepository)
```

#### Parameters

`postRepository` IPostRepository<br>

## Methods

### **InsertPost(String, Guid, Guid)**

```csharp
public Task InsertPost(string content, Guid creatorUserId, Guid forumId)
```

#### Parameters

`content` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`creatorUserId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UpdatePost(PostsDao)**

```csharp
public Task UpdatePost(PostsDao post)
```

#### Parameters

`post` PostsDao<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **DeletePost(PostsDao)**

```csharp
public Task DeletePost(PostsDao post)
```

#### Parameters

`post` PostsDao<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetPostById(Guid)**

```csharp
public Task<PostDto> GetPostById(Guid postId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;PostDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetForumCountByUserId(Guid)**

```csharp
public Task<int> GetForumCountByUserId(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetAllPosts(PageRequest)**

```csharp
public Task<IPage<PostDto>> GetAllPosts(PageRequest pageRequest)
```

#### Parameters

`pageRequest` PageRequest<br>

#### Returns

[Task&lt;IPage&lt;PostDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **CountAllPosts()**

```csharp
public Task<int> CountAllPosts()
```

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetPostsByUserId(Guid, PageRequest)**

```csharp
public Task<IPage<PostDto>> GetPostsByUserId(Guid userId, PageRequest pageRequest)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`pageRequest` PageRequest<br>

#### Returns

[Task&lt;IPage&lt;PostDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetPostsByForumId(Guid, PageRequest)**

```csharp
public Task<IPage<PostDto>> GetPostsByForumId(Guid forumId, PageRequest pageRequest)
```

#### Parameters

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`pageRequest` PageRequest<br>

#### Returns

[Task&lt;IPage&lt;PostDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
