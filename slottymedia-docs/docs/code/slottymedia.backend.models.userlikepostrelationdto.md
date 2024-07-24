# UserLikePostRelationDto

Namespace: SlottyMedia.Backend.Models

This class represents the User_Like_Post_Relation table in the database.

```csharp
public class UserLikePostRelationDto : Supabase.Postgrest.Models.BaseModel
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → BaseModel → [UserLikePostRelationDto](./slottymedia.backend.models.userlikepostrelationdto.md)

## Properties

### **UserLikePostRelationId**

The ID of the User_Like_Post_Relation. This is the Primary Key. It is auto-generated.

```csharp
public int UserLikePostRelationId { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **UserId**

The ID of the User who liked the Post. This is a Foreign Key to the User Table.

```csharp
public string UserId { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **PostId**

The ID of the Post that was liked. This is a Foreign Key to the Post Table.

```csharp
public int PostId { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **CreatedAt**

The Date and Time the User_Like_Post_Relation was created.

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

### **UserLikePostRelationDto()**

```csharp
public UserLikePostRelationDto()
```