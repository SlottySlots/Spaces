# PostServiceTests

Namespace: SlottyMedia.Tests.ServiceTests

Unit tests for the PostService class.

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

Sets up the test environment before each test.

```csharp
public void Setup()
```

### **TearDown()**

Cleans up the test environment after each test.

```csharp
public void TearDown()
```

### **InsertPost_ShouldReturnTrue_WhenPostIsInsertedSuccessfully()**

Tests that InsertPost returns true when a post is inserted successfully.

```csharp
public Task InsertPost_ShouldReturnTrue_WhenPostIsInsertedSuccessfully()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **InsertPost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests that InsertPost throws PostIudException when DatabaseIudActionException is thrown.

```csharp
public void InsertPost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **InsertPost_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests that InsertPost throws PostGeneralException when GeneralDatabaseException is thrown.

```csharp
public void InsertPost_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```

### **DeletePost_ShouldReturnTrue_WhenPostIsDeletedSuccessfully()**

Tests that DeletePost returns true when a post is deleted successfully.

```csharp
public Task DeletePost_ShouldReturnTrue_WhenPostIsDeletedSuccessfully()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **DeletePost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests that DeletePost throws PostIudException when DatabaseIudActionException is thrown.

```csharp
public void DeletePost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **DeletePost_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests that DeletePost throws PostGeneralException when GeneralDatabaseException is thrown.

```csharp
public void DeletePost_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```

### **GetPostsForUser_ShouldReturnPosts_WhenPostsAreFound()**

Tests that GetPostsForUser returns posts when posts are found.

```csharp
public Task GetPostsForUser_ShouldReturnPosts_WhenPostsAreFound()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetPostsForUser_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()**

Tests that GetPostsForUser throws PostNotFoundException when DatabaseMissingItemException is thrown.

```csharp
public void GetPostsForUser_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetPostsForUser_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests that GetPostsForUser throws PostGeneralException when GeneralDatabaseException is thrown.

```csharp
public void GetPostsForUser_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```

### **UpdatePost_ShouldReturnTrue_WhenPostIsUpdatedSuccessfully()**

Tests that UpdatePost returns true when a post is updated successfully.

```csharp
public Task UpdatePost_ShouldReturnTrue_WhenPostIsUpdatedSuccessfully()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UpdatePost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests that UpdatePost throws PostIudException when DatabaseIudActionException is thrown.

```csharp
public void UpdatePost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **UpdatePost_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests that UpdatePost throws PostGeneralException when GeneralDatabaseException is thrown.

```csharp
public void UpdatePost_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```

### **GetPostsFromForum_ShouldReturnPosts_WhenPostsAreFound()**

Tests that GetPostsFromForum returns posts when posts are found.

```csharp
public Task GetPostsFromForum_ShouldReturnPosts_WhenPostsAreFound()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetPostsFromForum_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()**

Tests that GetPostsFromForum throws PostNotFoundException when DatabaseMissingItemException is thrown.

```csharp
public void GetPostsFromForum_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetPostsFromForum_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests that GetPostsFromForum throws PostGeneralException when GeneralDatabaseException is thrown.

```csharp
public void GetPostsFromForum_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```

### **GetPostById_ShouldReturnPost_WhenPostIsFound()**

Tests that GetPostById returns a post when a post is found.

```csharp
public Task GetPostById_ShouldReturnPost_WhenPostIsFound()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetPostById_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()**

Tests that GetPostById throws PostNotFoundException when DatabaseMissingItemException is thrown.

```csharp
public void GetPostById_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetPostById_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests that GetPostById throws PostGeneralException when GeneralDatabaseException is thrown.

```csharp
public void GetPostById_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```

### **GetForumCountByUserId_ShouldReturnCorrectCount()**

Tests that GetForumCountByUserId returns the correct count.

```csharp
public Task GetForumCountByUserId_ShouldReturnCorrectCount()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetForumCountByUserId_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests that GetForumCountByUserId throws PostGeneralException when GeneralDatabaseException is thrown.

```csharp
public void GetForumCountByUserId_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```

### **GetAllPosts_ShouldReturnPosts_WhenPostsAreFound()**

Tests that GetAllPosts returns posts when posts are found.

```csharp
public Task GetAllPosts_ShouldReturnPosts_WhenPostsAreFound()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetAllPosts_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()**

Tests that GetAllPosts throws PostNotFoundException when DatabaseMissingItemException is thrown.

```csharp
public void GetAllPosts_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetAllPosts_ShouldThrowPostGeneralException_WhenGeneralExceptionIsThrown()**

Tests that GetAllPosts throws PostGeneralException when a general exception is thrown.

```csharp
public void GetAllPosts_ShouldThrowPostGeneralException_WhenGeneralExceptionIsThrown()
```

### **GetPostsByUserIdByForumId_ShouldReturnPosts_WhenPostsAreFound()**

Tests that GetPostsByUserIdByForumId returns posts when posts are found.

```csharp
public Task GetPostsByUserIdByForumId_ShouldReturnPosts_WhenPostsAreFound()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetPostsByUserIdByForumId_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()**

Tests that GetPostsByUserIdByForumId throws PostNotFoundException when DatabaseMissingItemException is thrown.

```csharp
public void GetPostsByUserIdByForumId_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetPostsByUserIdByForumId_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests that GetPostsByUserIdByForumId throws PostGeneralException when GeneralDatabaseException is thrown.

```csharp
public void GetPostsByUserIdByForumId_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```

### **GetPostsByForumId_ShouldReturnPosts_WhenPostsAreFound()**

Tests that GetPostsByForumId returns posts when posts are found.

```csharp
public Task GetPostsByForumId_ShouldReturnPosts_WhenPostsAreFound()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetPostsByForumId_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()**

Tests that GetPostsByForumId throws PostNotFoundException when DatabaseMissingItemException is thrown.

```csharp
public void GetPostsByForumId_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetPostsByForumId_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests that GetPostsByForumId throws PostGeneralException when GeneralDatabaseException is thrown.

```csharp
public void GetPostsByForumId_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```
