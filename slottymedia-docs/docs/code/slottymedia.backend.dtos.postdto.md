# PostDto

Namespace: SlottyMedia.Backend.Dtos

The Post Data Transfer Object

```csharp
public class PostDto
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PostDto](./slottymedia.backend.dtos.postdto.md)

## Properties

### **Forum**

Gets or sets the forum associated with the post.

```csharp
public ForumDto Forum { get; set; }
```

#### Property Value

[ForumDto](./slottymedia.backend.dtos.forumdto.md)<br>

### **PostId**

Gets or sets the post ID.

```csharp
public Guid PostId { get; set; }
```

#### Property Value

[Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

### **UserDao**

Gets or sets the user ID of the user who created the post.

```csharp
public int UserDao { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **Likes**

Gets or sets the list of user IDs who liked the post.

```csharp
public List<Guid> Likes { get; set; }
```

#### Property Value

[List&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **CreatedAt**

Gets or sets the creation date of the post.

```csharp
public DateTime CreatedAt { get; set; }
```

#### Property Value

[DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>

### **Content**

Gets or sets the content of the post.

```csharp
public string Content { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Comments**

Gets or sets the comments on the post.

```csharp
public CommentDao Comments { get; set; }
```

#### Property Value

CommentDao<br>

## Constructors

### **PostDto()**

Initializes a new instance of the [PostDto](./slottymedia.backend.dtos.postdto.md) class.

```csharp
public PostDto()
```
