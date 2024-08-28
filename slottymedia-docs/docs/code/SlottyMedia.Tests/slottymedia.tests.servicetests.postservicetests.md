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

```csharp
public Task InsertPost_ShouldReturnTrue_WhenPostIsInsertedSuccessfully()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **InsertPost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()**

```csharp
public void InsertPost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **InsertPost_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

```csharp
public void InsertPost_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```

### **DeletePost_ShouldReturnTrue_WhenPostIsDeletedSuccessfully()**

```csharp
public Task DeletePost_ShouldReturnTrue_WhenPostIsDeletedSuccessfully()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **DeletePost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()**

```csharp
public void DeletePost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **DeletePost_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

```csharp
public void DeletePost_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```

### **GetPostsForUser_ShouldReturnPosts_WhenPostsAreFound()**

```csharp
public Task GetPostsForUser_ShouldReturnPosts_WhenPostsAreFound()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetPostsForUser_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()**

```csharp
public void GetPostsForUser_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetPostsForUser_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

```csharp
public void GetPostsForUser_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```
