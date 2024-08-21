# PostService

Namespace: SlottyMedia.Backend.Services

```csharp
public class PostService : SlottyMedia.Backend.Services.Interfaces.IPostService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PostService](./slottymedia.backend.services.postservice.md)<br>
Implements [IPostService](./slottymedia.backend.services.interfaces.ipostservice.md)

## Properties

### **DatabaseActions**

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

```csharp
public Task<PostDto> InsertPost(string title, string content, Guid creatorUserId, Guid forumId)
```

#### Parameters

`title` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`content` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`creatorUserId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

[Task&lt;PostDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **UpdatePost(PostDto)**

```csharp
public Task<PostDto> UpdatePost(PostDto post)
```

#### Parameters

`post` [PostDto](./slottymedia.backend.dtos.postdto.md)<br>

#### Returns

[Task&lt;PostDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **DeletePost(PostDto)**

```csharp
public Task<bool> DeletePost(PostDto post)
```

#### Parameters

`post` [PostDto](./slottymedia.backend.dtos.postdto.md)<br>

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetPostsFromForum(Guid, Int32, Int32)**

```csharp
public Task<List<string>> GetPostsFromForum(Guid userId, int startOfSet, int endOfSet)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`startOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`endOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Task&lt;List&lt;String&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetPostsByUserId(Guid, Int32, Int32)**

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

Retrieves a list of posts from the database based on the given userId and forumId.

```csharp
public Task<List<PostDto>> GetPostsByUserIdByForumId(Guid userId, int startOfSet, int endOfSet, Guid forumId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the user.

`startOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The starting index of the set.

`endOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The ending index of the set.

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the forum.

#### Returns

[Task&lt;List&lt;PostDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of PostDto objects.

### **GetPostsByForumId(Guid, Int32, Int32)**

Retrieves a list of posts from the database based on the given forumId.

```csharp
public Task<List<PostDto>> GetPostsByForumId(Guid forumId, int startOfSet, int endOfSet)
```

#### Parameters

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the forum.

`startOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The starting index of the set.

`endOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The ending index of the set.

#### Returns

[Task&lt;List&lt;PostDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains a list of PostDto objects.
