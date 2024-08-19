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

Tests that InsertLike returns true when the like is inserted successfully.

```csharp
public Task InsertLike_ShouldReturnTrue_WhenLikeIsInsertedSuccessfully()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **InsertLike_ShouldThrowLikeIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests that InsertLike throws LikeIudException when a DatabaseIudActionException is thrown.

```csharp
public void InsertLike_ShouldThrowLikeIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **InsertLike_ShouldThrowLikeGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests that InsertLike throws LikeGeneralException when a GeneralDatabaseException is thrown.

```csharp
public void InsertLike_ShouldThrowLikeGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```

### **DeleteLike_ShouldReturnTrue_WhenLikeIsDeletedSuccessfully()**

Tests that DeleteLike returns true when the like is deleted successfully.

```csharp
public Task DeleteLike_ShouldReturnTrue_WhenLikeIsDeletedSuccessfully()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **DeleteLike_ShouldThrowLikeIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests that DeleteLike throws LikeIudException when a DatabaseIudActionException is thrown.

```csharp
public void DeleteLike_ShouldThrowLikeIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **DeleteLike_ShouldThrowLikeGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests that DeleteLike throws LikeGeneralException when a GeneralDatabaseException is thrown.

```csharp
public void DeleteLike_ShouldThrowLikeGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```

### **GetLikesForPost_ShouldReturnUserIds_WhenLikesAreFound()**

Tests that GetLikesForPost returns a list of user IDs when likes are found.

```csharp
public Task GetLikesForPost_ShouldReturnUserIds_WhenLikesAreFound()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetLikesForPost_ShouldThrowLikeNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()**

Tests that GetLikesForPost throws LikeNotFoundException when a DatabaseMissingItemException is thrown.

```csharp
public void GetLikesForPost_ShouldThrowLikeNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetLikesForPost_ShouldThrowLikeGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests that GetLikesForPost throws LikeGeneralException when a GeneralDatabaseException is thrown.

```csharp
public void GetLikesForPost_ShouldThrowLikeGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```
