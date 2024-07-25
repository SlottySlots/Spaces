# CommentDto

Namespace: SlottyMedia.Backend.Models

This class represents the Comment table in the database.

```csharp
public class CommentDto
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [CommentDto](./slottymedia.backend.models.commentdto.md)

## Properties

### **CommentId**

The ID of the Comment. This is the Primary Key. It is auto-generated.

```csharp
public int CommentId { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **ParentCommentId**

The ID of the Parent Comment. This is only set when there is a Parent Comment

```csharp
public string ParentCommentId { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **CreatorUserId**

The ID of the User who created the Comment. This is a Foreign Key to the User Table

```csharp
public string CreatorUserId { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **PostId**

The ID of the Post the Comment is related to. This is a Foreign Key to the Post Table

```csharp
public string PostId { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Content**

The Content of the Comment

```csharp
public string Content { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **CreatedAt**

The Date and Time the Comment was created

```csharp
public DateTime CreatedAt { get; set; }
```

#### Property Value

[DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>

## Constructors

### **CommentDto()**

```csharp
public CommentDto()
```
