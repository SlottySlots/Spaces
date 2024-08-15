# PostsDao

Namespace: SlottyMedia.Database.Daos

This class represents the Posts table in the database.

```csharp
public class PostsDao : Supabase.Postgrest.Models.BaseModel
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → BaseModel → [PostsDao](./slottymedia.database.daos.postsdao.md)

## Properties

### **PostId**

The ID of the Post. This is the Primary Key. It is auto-generated.

```csharp
public Nullable<Guid> PostId { get; set; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **User**

The User who created the Post. This is a Reference to the User Table. It is a Foreign Key. Be aware, that this
 Field will not be filled when you insert the Post into the Database.

```csharp
public UserDao User { get; set; }
```

#### Property Value

[UserDao](./slottymedia.database.daos.userdao.md)<br>

### **UserId**

The ID of the User who created the Post. This is a Foreign Key to the User Table.

```csharp
public Nullable<Guid> UserId { get; set; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **Forum**

The Forum the Post is associated with. This is a Reference to the Forum Table. It is a Foreign Key. Be aware, that
 this
 Field will not be filled when you insert the Post into the Database.

```csharp
public ForumDao Forum { get; set; }
```

#### Property Value

[ForumDao](./slottymedia.database.daos.forumdao.md)<br>

### **ForumId**

The ID of the Forum the Post is associated with. This is a Foreign Key to the Forum Table.

```csharp
public Nullable<Guid> ForumId { get; set; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **Headline**

The Headline of the Post.

```csharp
public string Headline { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Content**

The Content of the Post.

```csharp
public string Content { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Comments**

The Comments of the Post. This is a Reference to the Comment Table. It is a Foreign Key. Be aware, that this

```csharp
public List<CommentDao> Comments { get; set; }
```

#### Property Value

[List&lt;CommentDao&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **CreatedAt**

The Date and Time the Post was created.

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

### **PostsDao()**

The default constructor.

```csharp
public PostsDao()
```

### **PostsDao(Guid, Guid, String, String)**

The constructor with parameters.

```csharp
public PostsDao(Guid userId, Guid forumId, string headline, string content)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The UserId of the Post

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ForumId of the Post

`headline` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Headline of the Post

`content` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Content of the Post
