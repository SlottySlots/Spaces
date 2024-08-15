# FollowerUserRelationDao

Namespace: SlottyMedia.Database.Daos

This class represents the Follower_User_Relation table in the database.

```csharp
public class FollowerUserRelationDao : Supabase.Postgrest.Models.BaseModel
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → BaseModel → [FollowerUserRelationDao](./slottymedia.database.daos.followeruserrelationdao.md)

## Properties

### **FollowerUserRelationId**

The ID of the Follower_User_Relation. This is the Primary Key. It is auto-generated.

```csharp
public Nullable<Guid> FollowerUserRelationId { get; set; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **FollowerUser**

The User who is following another User. This is a Reference to the User Table.

```csharp
public UserDao FollowerUser { get; set; }
```

#### Property Value

[UserDao](./slottymedia.database.daos.userdao.md)<br>

### **FollowerUserId**

The ID of the User who is following another User. This is a Foreign Key to the User Table.

```csharp
public Nullable<Guid> FollowerUserId { get; set; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **FollowedUser**

The User who is being followed. This is a Reference to the User Table.

```csharp
public UserDao FollowedUser { get; set; }
```

#### Property Value

[UserDao](./slottymedia.database.daos.userdao.md)<br>

### **FollowedUserId**

The ID of the User who is being followed. This is a Foreign Key to the User Table.

```csharp
public Nullable<Guid> FollowedUserId { get; set; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **CreatedAt**

The Date and Time the Follower_User_Relation was created.

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

### **FollowerUserRelationDao()**

Default constructor.

```csharp
public FollowerUserRelationDao()
```

### **FollowerUserRelationDao(Guid, Guid)**

Constructor to create a new FollowerUserRelation.

```csharp
public FollowerUserRelationDao(Guid followerUserId, Guid followedUserId)
```

#### Parameters

`followerUserId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the User who is following another User.

`followedUserId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the User who is being followed.
