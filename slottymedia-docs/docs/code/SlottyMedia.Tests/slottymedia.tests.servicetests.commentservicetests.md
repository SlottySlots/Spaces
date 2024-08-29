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

Initializes the mock objects and the CommentService instance before each test.

```csharp
public void Setup()
```

### **TearDown()**

Resets the mock objects after each test.

```csharp
public void TearDown()
```

### **InsertComment_ShouldInsertComment_WhenCommentIsValid()**

Tests that InsertComment method inserts a comment when the comment is valid.

```csharp
public Task InsertComment_ShouldInsertComment_WhenCommentIsValid()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **InsertComment_ShouldThrowCommentIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests that InsertComment method throws CommentIudException when DatabaseIudActionException is thrown.

```csharp
public void InsertComment_ShouldThrowCommentIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **InsertComment_ShouldThrowCommentGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests that InsertComment method throws CommentGeneralException when GeneralDatabaseException is thrown.

```csharp
public void InsertComment_ShouldThrowCommentGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```

### **UpdateComment_ShouldUpdateComment_WhenCommentIsValid()**

Tests that UpdateComment method updates a comment when the comment is valid.

```csharp
public Task UpdateComment_ShouldUpdateComment_WhenCommentIsValid()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UpdateComment_ShouldThrowCommentIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests that UpdateComment method throws CommentIudException when DatabaseIudActionException is thrown.

```csharp
public void UpdateComment_ShouldThrowCommentIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **UpdateComment_ShouldThrowCommentGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests that UpdateComment method throws CommentGeneralException when GeneralDatabaseException is thrown.

```csharp
public void UpdateComment_ShouldThrowCommentGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```

### **DeleteComment_ShouldDeleteComment_WhenCommentIsValid()**

Tests that DeleteComment method deletes a comment when the comment is valid.

```csharp
public Task DeleteComment_ShouldDeleteComment_WhenCommentIsValid()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **DeleteComment_ShouldThrowCommentIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests that DeleteComment method throws CommentIudException when DatabaseIudActionException is thrown.

```csharp
public void DeleteComment_ShouldThrowCommentIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **DeleteComment_ShouldThrowCommentGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests that DeleteComment method throws CommentGeneralException when GeneralDatabaseException is thrown.

```csharp
public void DeleteComment_ShouldThrowCommentGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```
