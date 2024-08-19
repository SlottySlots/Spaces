# CommentDao

Namespace: SlottyMedia.Database.Daos

This class represents the Comment table in the database.

```csharp
public class CommentDao : Supabase.Postgrest.Models.BaseModel
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → BaseModel → [CommentDao](./slottymedia.database.daos.commentdao.md)

## Properties

### **CommentId**

The ID of the Comment. This is the Primary Key. It is auto-generated.

```csharp
public Nullable<Guid> CommentId { get; set; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **ParentCommentId**

The ID of the Parent Comment. This is only set when there is a Parent Comment.

```csharp
public Nullable<Guid> ParentCommentId { get; set; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **ParentComment**

The list of parent comments.

```csharp
public List<CommentDao> ParentComment { get; set; }
```

#### Property Value

[List&lt;CommentDao&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **CreatorUser**

The User who created the Comment. This is a Reference to the User Table. It is a Foreign Key.

```csharp
public UserDao CreatorUser { get; set; }
```

#### Property Value

[UserDao](./slottymedia.database.daos.userdao.md)<br>

### **CreatorUserId**

The ID of the User who created the Comment. This is a Foreign Key to the User Table.

```csharp
public Nullable<Guid> CreatorUserId { get; set; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **Post**

The Post the Comment is related to. This is a Reference to the Post Table. It is a Foreign Key.

```csharp
public PostsDao Post { get; set; }
```

#### Property Value

[PostsDao](./slottymedia.database.daos.postsdao.md)<br>

### **PostId**

The ID of the Post the Comment is related to. This is a Foreign Key to the Post Table.

```csharp
public Nullable<Guid> PostId { get; set; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **Content**

The Content of the Comment.

```csharp
public string Content { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **CreatedAt**

The Date and Time the Comment was created.

```csharp
public DateTime CreatedAt { get; set; }
```

#### Property Value

[DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>

### **BaseUrl**

```csharp
public string BaseUrl { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **RequestClientOptions**

```csharp
public ClientOptions RequestClientOptions { get; set; }
```

#### Property Value

ClientOptions<br>

### **TableName**

```csharp
public string TableName { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **PrimaryKey**

```csharp
public Dictionary<PrimaryKeyAttribute, object> PrimaryKey { get; }
```

#### Property Value

[Dictionary&lt;PrimaryKeyAttribute, Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2)<br>

## Constructors

### **CommentDao()**

Default constructor.

```csharp
public CommentDao()
```

### **CommentDao(Guid, Guid, String, Nullable&lt;Guid&gt;)**

This constructor is used to create a new Comment. The CommentId is auto-generated.

```csharp
public CommentDao(Guid creatorUserId, Guid postId, string content, Nullable<Guid> parentCommentId)
```

#### Parameters

`creatorUserId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The user who created the comment

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The postId of the comment

`content` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The content of the comment

`parentCommentId` [Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The ID of the parent comment, if any

## Methods

### **ToString()**

```csharp
public string ToString()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
