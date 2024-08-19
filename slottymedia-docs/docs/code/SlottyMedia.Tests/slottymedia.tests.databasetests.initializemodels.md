# InitializeModels

Namespace: SlottyMedia.Tests.DatabaseTests

This class initializes the models for the database tests.

```csharp
public static class InitializeModels
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [InitializeModels](./slottymedia.tests.databasetests.initializemodels.md)

## Methods

### **GetUserDto()**

```csharp
public static UserDao GetUserDto()
```

#### Returns

UserDao<br>

### **GetForumDto(UserDao)**

```csharp
public static ForumDao GetForumDto(UserDao userDao)
```

#### Parameters

`userDao` UserDao<br>

#### Returns

ForumDao<br>

### **GetPostsDto(ForumDao, UserDao)**

```csharp
public static PostsDao GetPostsDto(ForumDao forumDao, UserDao userDao)
```

#### Parameters

`forumDao` ForumDao<br>

`userDao` UserDao<br>

#### Returns

PostsDao<br>
