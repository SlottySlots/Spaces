# CommentServiceTests

Namespace: SlottyMedia.Tests.ServiceTests

Unit tests for the CommentService class.

```csharp
public class CommentServiceTests
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [CommentServiceTests](./slottymedia.tests.servicetests.commentservicetests.md)

## Constructors

### **CommentServiceTests()**

```csharp
public CommentServiceTests()
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

### **InsertComment_ShouldReturnComment_WhenCommentIsInserted()**

Tests that InsertComment returns the correct comment when the comment is successfully inserted.

```csharp
public Task InsertComment_ShouldReturnComment_WhenCommentIsInserted()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **InsertComment_ShouldThrowCommentIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests that InsertComment throws CommentIudException when a DatabaseIudActionException is thrown.

```csharp
public void InsertComment_ShouldThrowCommentIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **InsertComment_ShouldThrowCommentGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests that InsertComment throws CommentGeneralException when a GeneralDatabaseException is thrown.

```csharp
public void InsertComment_ShouldThrowCommentGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```

### **UpdateComment_ShouldReturnComment_WhenCommentIsUpdated()**

Tests that UpdateComment returns the correct comment when the comment is successfully updated.

```csharp
public Task UpdateComment_ShouldReturnComment_WhenCommentIsUpdated()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UpdateComment_ShouldThrowCommentIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests that UpdateComment throws CommentIudException when a DatabaseIudActionException is thrown.

```csharp
public void UpdateComment_ShouldThrowCommentIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **UpdateComment_ShouldThrowCommentGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests that UpdateComment throws CommentGeneralException when a GeneralDatabaseException is thrown.

```csharp
public void UpdateComment_ShouldThrowCommentGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```

### **DeleteComment_ShouldReturnTrue_WhenCommentIsDeleted()**

Tests that DeleteComment returns true when the comment is successfully deleted.

```csharp
public Task DeleteComment_ShouldReturnTrue_WhenCommentIsDeleted()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **DeleteComment_ShouldThrowCommentIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests that DeleteComment throws CommentIudException when a DatabaseIudActionException is thrown.

```csharp
public void DeleteComment_ShouldThrowCommentIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **DeleteComment_ShouldThrowCommentGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests that DeleteComment throws CommentGeneralException when a GeneralDatabaseException is thrown.

```csharp
public void DeleteComment_ShouldThrowCommentGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```
