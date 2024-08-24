# ForumDto

Namespace: SlottyMedia.Backend.Dtos

The Forum Data Transfer Object

```csharp
public class ForumDto
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ForumDto](./slottymedia.backend.dtos.forumdto.md)

## Properties

### **ForumId**

The Forum Id.

```csharp
public Guid ForumId { get; set; }
```

#### Property Value

[Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

### **Topic**

The Topic of the Forum.v

```csharp
public string Topic { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **CreatedAt**

The Date and Time the Forum was created.

```csharp
public DateTime CreatedAt { get; set; }
```

#### Property Value

[DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>

## Constructors

### **ForumDto()**

The default constructor.

```csharp
public ForumDto()
```

## Methods

### **Mapper()**

This method maps the ForumDto to a ForumDao.

```csharp
public ForumDao Mapper()
```

#### Returns

ForumDao<br>

### **Mapper(ForumDao)**

THis method maps the ForumDao to a ForumDto.

```csharp
public ForumDto Mapper(ForumDao forumDao)
```

#### Parameters

`forumDao` ForumDao<br>

#### Returns

[ForumDto](./slottymedia.backend.dtos.forumdto.md)<br>

### **ToString()**

The ToString method returns a string representation of the object.

```csharp
public string ToString()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
