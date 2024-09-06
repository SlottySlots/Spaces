# LikeServiceTests

Namespace: SlottyMedia.Tests.ServiceTests

Unit tests for the LikeService class.

```csharp
public class LikeServiceTests
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [LikeServiceTests](./slottymedia.tests.servicetests.likeservicetests.md)

## Constructors

### **LikeServiceTests()**

```csharp
public LikeServiceTests()
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

### **InsertLike_ShouldReturnTrue_WhenLikeIsInsertedSuccessfully()**

Tests that a like is inserted successfully.

```csharp
public Task InsertLike_ShouldReturnTrue_WhenLikeIsInsertedSuccessfully()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **InsertLike_ShouldThrowLikeIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests that a LikeIudException is thrown when a DatabaseIudActionException is thrown.

```csharp
public void InsertLike_ShouldThrowLikeIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **InsertLike_ShouldThrowLikeGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests that a LikeGeneralException is thrown when a GeneralDatabaseException is thrown.

```csharp
public void InsertLike_ShouldThrowLikeGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```

### **DeleteLike_ShouldReturnTrue_WhenLikeIsDeletedSuccessfully()**

Tests that a like is deleted successfully.

```csharp
public Task DeleteLike_ShouldReturnTrue_WhenLikeIsDeletedSuccessfully()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **DeleteLike_ShouldThrowLikeIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests that a LikeIudException is thrown when a DatabaseIudActionException is thrown.

```csharp
public void DeleteLike_ShouldThrowLikeIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **DeleteLike_ShouldThrowLikeGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests that a LikeGeneralException is thrown when a GeneralDatabaseException is thrown.

```csharp
public void DeleteLike_ShouldThrowLikeGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```

### **GetLikesForPost_ShouldReturnUserIds_WhenLikesAreFound()**

Tests that user IDs are returned when likes are found for a post.

```csharp
public Task GetLikesForPost_ShouldReturnUserIds_WhenLikesAreFound()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetLikesForPost_ShouldThrowLikeNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()**

Tests that a LikeNotFoundException is thrown when a DatabaseMissingItemException is thrown.

```csharp
public void GetLikesForPost_ShouldThrowLikeNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetLikesForPost_ShouldThrowLikeGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests that a LikeGeneralException is thrown when a GeneralDatabaseException is thrown.

```csharp
public void GetLikesForPost_ShouldThrowLikeGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```

### **InsertLike_ShouldThrowLikeGeneralException_WhenGeneralExceptionIsThrown()**

Tests that a LikeGeneralException is thrown when a general exception is thrown in InsertLike.

```csharp
public void InsertLike_ShouldThrowLikeGeneralException_WhenGeneralExceptionIsThrown()
```

### **DeleteLike_ShouldThrowLikeNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()**

Tests that a LikeNotFoundException is thrown when a DatabaseMissingItemException is thrown in DeleteLike.

```csharp
public void DeleteLike_ShouldThrowLikeNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **DeleteLike_ShouldThrowLikeGeneralException_WhenGeneralExceptionIsThrown()**

Tests that a LikeGeneralException is thrown when a general exception is thrown in DeleteLike.

```csharp
public void DeleteLike_ShouldThrowLikeGeneralException_WhenGeneralExceptionIsThrown()
```

### **GetLikesForPost_ShouldThrowLikeGeneralException_WhenGeneralExceptionIsThrown()**

Tests that a LikeGeneralException is thrown when a general exception is thrown in GetLikesForPost.

```csharp
public void GetLikesForPost_ShouldThrowLikeGeneralException_WhenGeneralExceptionIsThrown()
```
