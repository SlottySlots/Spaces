# PostServiceTests

Namespace: SlottyMedia.Tests.ServiceTests

Tests the PostService used for CRUD operations on posts.

```csharp
public class PostServiceTests
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PostServiceTests](./slottymedia.tests.servicetests.postservicetests.md)

## Constructors

### **PostServiceTests()**

```csharp
public PostServiceTests()
```

## Methods

### **Setup()**

The setup method that is called before each test.

```csharp
public void Setup()
```

### **TearDown()**

The teardown method that is called after each test.

```csharp
public void TearDown()
```

### **InsertPost_ShouldReturnInsertedPost()**

Tests if InsertPost method returns the inserted post correctly.

```csharp
public Task InsertPost_ShouldReturnInsertedPost()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **InsertPost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests if InsertPost method throws PostIudException when DatabaseIudActionException is thrown.

```csharp
public void InsertPost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **InsertPost_ShouldThrowPostGeneralException_WhenDatabaseExceptionIsThrown()**

Tests if InsertPost method throws PostGeneralException when GeneralDatabaseException is thrown.

```csharp
public void InsertPost_ShouldThrowPostGeneralException_WhenDatabaseExceptionIsThrown()
```

### **UpdatePost_ShouldReturnUpdatedPost()**

Tests if UpdatePost method returns the updated post correctly.

```csharp
public Task UpdatePost_ShouldReturnUpdatedPost()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UpdatePost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests if UpdatePost method throws PostIudException when DatabaseIudActionException is thrown.

```csharp
public void UpdatePost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **UpdatePost_ShouldThrowPostGeneralException_WhenDatabaseExceptionIsThrown()**

Tests if UpdatePost method throws PostGeneralException when GeneralDatabaseException is thrown.

```csharp
public void UpdatePost_ShouldThrowPostGeneralException_WhenDatabaseExceptionIsThrown()
```

### **DeletePost_ShouldReturnTrue()**

Tests if DeletePost method returns true when post is deleted successfully.

```csharp
public Task DeletePost_ShouldReturnTrue()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **DeletePost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests if DeletePost method throws PostIudException when DatabaseIudActionException is thrown.

```csharp
public void DeletePost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **DeletePost_ShouldThrowPostGeneralException_WhenDatabaseExceptionIsThrown()**

Tests if DeletePost method throws PostGeneralException when GeneralDatabaseException is thrown.

```csharp
public void DeletePost_ShouldThrowPostGeneralException_WhenDatabaseExceptionIsThrown()
```

### **GetPostsFromForum_ShouldReturnListOfPostTitles()**

Tests if GetPostsFromForum method returns a list of post titles from a forum.

```csharp
public Task GetPostsFromForum_ShouldReturnListOfPostTitles()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetPostsFromForum_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()**

Tests if GetPostsFromForum method throws PostNotFoundException when DatabaseMissingItemException is thrown.

```csharp
public void GetPostsFromForum_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetPostsFromForum_ShouldThrowPostGeneralException_WhenDatabaseExceptionIsThrown()**

Tests if GetPostsFromForum method throws PostGeneralException when GeneralDatabaseException is thrown.

```csharp
public void GetPostsFromForum_ShouldThrowPostGeneralException_WhenDatabaseExceptionIsThrown()
```

### **GetPostsByUserId_ShouldReturnListOfPostDtos()**

Tests if GetPostsByUserId method returns a list of post DTOs by user ID.

```csharp
public Task GetPostsByUserId_ShouldReturnListOfPostDtos()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetPostsByUserId_ShouldThrowPostGeneralException_WhenDatabaseExceptionIsThrown()**

Tests if GetPostsByUserId method throws PostGeneralException when GeneralDatabaseException is thrown.

```csharp
public void GetPostsByUserId_ShouldThrowPostGeneralException_WhenDatabaseExceptionIsThrown()
```

### **GetPostsByUserIdByForumId_ShouldReturnListOfPostDtos()**

Tests if GetPostsByUserIdByForumId method returns a list of post DTOs by user ID and forum ID.

```csharp
public Task GetPostsByUserIdByForumId_ShouldReturnListOfPostDtos()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetPostsByUserIdByForumId_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()**

Tests if GetPostsByUserIdByForumId method throws PostNotFoundException when DatabaseMissingItemException is thrown.

```csharp
public void GetPostsByUserIdByForumId_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetPostsByForumId_ShouldReturnListOfPostDtos()**

Tests if GetPostsByForumId method returns a list of post DTOs by forum ID.

```csharp
public Task GetPostsByForumId_ShouldReturnListOfPostDtos()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetPostsByForumId_ShouldThrowPostGeneralException_WhenDatabaseExceptionIsThrown()**

Tests if GetPostsByForumId method throws PostGeneralException when GeneralDatabaseException is thrown.

```csharp
public void GetPostsByForumId_ShouldThrowPostGeneralException_WhenDatabaseExceptionIsThrown()
```
