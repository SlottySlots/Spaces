# InitializeModels

Namespace: SlottyMedia.Tests.DatabaseTests

This class initializes the models for the database tests.

```csharp
public static class InitializeModels
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [InitializeModels](./slottymedia.tests.databasetests.initializemodels.md)

## Methods

### **GetRoleDto()**

This method initializes a RoleDto for the tests.

```csharp
public static RoleDao GetRoleDto()
```

#### Returns

RoleDao<br>

### **GetUserDto(Guid)**

This method initializes a UserDto for the tests.

```csharp
public static UserDao GetUserDto(Guid userID)
```

#### Parameters

`userID` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

UserDao<br>

### **GetForumDto(UserDao)**

This method initializes a ForumDto for the tests.

```csharp
public static ForumDao GetForumDto(UserDao userDao)
```

#### Parameters

`userDao` UserDao<br>

#### Returns

ForumDao<br>

### **GetPostsDto(ForumDao, UserDao)**

This method initializes a PostsDto for the tests.

```csharp
public static PostsDao GetPostsDto(ForumDao forumDao, UserDao userDao)
```

#### Parameters

`forumDao` ForumDao<br>

`userDao` UserDao<br>

#### Returns

PostsDao<br>
