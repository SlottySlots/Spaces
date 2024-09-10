# TopSpaceDao

Namespace: SlottyMedia.Database.Daos

This class represents the Forum table in the database.

```csharp
public class TopSpaceDao : Supabase.Postgrest.Models.BaseModel
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → BaseModel → [TopSpaceDao](./slottymedia.database.daos.topspacedao.md)

## Properties

### **ForumId**

The ID of the Forum. This is the Primary Key. It is auto-generated.

```csharp
public Nullable<Guid> ForumId { get; set; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **ForumTopic**

The Title of the Forum.

```csharp
public string ForumTopic { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **post_count**

The Count of Posts in the Forum.

```csharp
public Nullable<int> post_count { get; set; }
```

#### Property Value

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

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

### **TopSpaceDao()**

The default constructor.

```csharp
public TopSpaceDao()
```

### **TopSpaceDao(String)**

The constructor with parameters.

```csharp
public TopSpaceDao(string forumTopic)
```

#### Parameters

`forumTopic` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Topic of the Forum

## Methods

### **ToString()**

The ToString method returns a string representation of the object.

```csharp
public string ToString()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
