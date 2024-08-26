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
public Nullable<Guid> UserId { get; set; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

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

### **ProfilePic**

ProfilePic of a user

```csharp
public string ProfilePic { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **FriendsAmount**

Amount of Follow4Follows of User

```csharp
public int FriendsAmount { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **SpacesAmount**

Amount of Spaces of a User

```csharp
public int SpacesAmount { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

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
