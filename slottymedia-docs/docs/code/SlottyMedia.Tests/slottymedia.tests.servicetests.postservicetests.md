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
