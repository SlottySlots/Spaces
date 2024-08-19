# CommentDto

Namespace: SlottyMedia.Backend.Dtos

The Comment Data Transfer Object

```csharp
public class CommentDto
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [CommentDto](./slottymedia.backend.dtos.commentdto.md)

## Properties

### **CommentId**

Gets or sets the Comment Id.

```csharp
public Guid CommentId { get; set; }
```

#### Property Value

[Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

### **ParentComment**

Gets or sets the list of parent comments.

```csharp
public List<CommentDto> ParentComment { get; set; }
```

#### Property Value

[List&lt;CommentDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **CreatorUserId**

Gets or sets the ID of the user who created the comment.

```csharp
public Nullable<Guid> CreatorUserId { get; set; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **PostId**

Gets or sets the ID of the post the comment is related to.

```csharp
public Guid PostId { get; set; }
```

#### Property Value

[Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

### **Content**

Gets or sets the content of the comment.

```csharp
public string Content { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **CreatedAt**

Gets or sets the date and time when the comment was created.

```csharp
public DateTime CreatedAt { get; set; }
```

#### Property Value

[DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>

## Constructors

### **CommentDto()**

Initializes a new instance of the [CommentDto](./slottymedia.backend.dtos.commentdto.md) class.

```csharp
public CommentDto()
```

## Methods

### **Mapper()**

This method maps the Comment Dto to the Comment Dao.

```csharp
public CommentDao Mapper()
```

#### Returns

CommentDao<br>

### **Mapper(CommentDao)**

Maps the Comment Dao to the Comment Dto.

```csharp
public CommentDto Mapper(CommentDao comment)
```

#### Parameters

`comment` CommentDao<br>

#### Returns

[CommentDto](./slottymedia.backend.dtos.commentdto.md)<br>
