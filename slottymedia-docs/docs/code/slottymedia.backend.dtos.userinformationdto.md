# UserInformationDto

Namespace: SlottyMedia.Backend.Dtos

The User Information Data Transfer Object. It differs to UserDto by not persisting recentForums.

```csharp
public class UserInformationDto
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [UserInformationDto](./slottymedia.backend.dtos.userinformationdto.md)

## Properties

### **UserId**

Gets or sets the User Id.

```csharp
public Guid UserId { get; set; }
```

#### Property Value

[Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

### **Username**

Gets or sets the Username.

```csharp
public string Username { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Description**

Gets or sets the Description of the User.

```csharp
public string Description { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **CreatedAt**

Gets or sets the date and time when the User was created.

```csharp
public DateTime CreatedAt { get; set; }
```

#### Property Value

[DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>

## Constructors

### **UserInformationDto()**

Initializes a new instance of the [UserInformationDto](./slottymedia.backend.dtos.userinformationdto.md) class.

```csharp
public UserInformationDto()
```

## Methods

### **Mapper()**

This method maps the UserInformationDto to the User Dao.

```csharp
public UserDao Mapper()
```

#### Returns

UserDao<br>

### **Mapper(UserDao)**

Maps the User Dao to the UserInformationDto.

```csharp
public UserInformationDto Mapper(UserDao user)
```

#### Parameters

`user` UserDao<br>

#### Returns

[UserInformationDto](./slottymedia.backend.dtos.userinformationdto.md)<br>
