# ForumServiceTests

Namespace: SlottyMedia.Tests.ServiceTests

Unit tests for the ForumService class.

```csharp
public class ForumServiceTests
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ForumServiceTests](./slottymedia.tests.servicetests.forumservicetests.md)

## Constructors

### **ForumServiceTests()**

```csharp
public ForumServiceTests()
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

### **InsertForum_ShouldInsertForum_WhenForumIsValid()**

Tests that a forum is inserted when the forum is valid.

```csharp
public Task InsertForum_ShouldInsertForum_WhenForumIsValid()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **InsertForum_ShouldThrowForumIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests that a ForumIudException is thrown when a DatabaseIudActionException is thrown.

```csharp
public void InsertForum_ShouldThrowForumIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **InsertForum_ShouldThrowForumGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests that a ForumGeneralException is thrown when a GeneralDatabaseException is thrown.

```csharp
public void InsertForum_ShouldThrowForumGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```

### **DeleteForum_ShouldDeleteForum_WhenForumIsValid()**

Tests that a forum is deleted when the forum is valid.

```csharp
public Task DeleteForum_ShouldDeleteForum_WhenForumIsValid()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **DeleteForum_ShouldThrowForumIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests that a ForumIudException is thrown when a DatabaseIudActionException is thrown.

```csharp
public void DeleteForum_ShouldThrowForumIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **DeleteForum_ShouldThrowForumGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests that a ForumGeneralException is thrown when a GeneralDatabaseException is thrown.

```csharp
public void DeleteForum_ShouldThrowForumGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```

### **GetForumByName_ShouldReturnForum_WhenForumExists()**

Tests that a forum is returned when the forum exists.

```csharp
public Task GetForumByName_ShouldReturnForum_WhenForumExists()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetForumByName_ShouldThrowForumGeneralException_WhenDatabaseMissingItemExceptionIsThrown()**

Tests that a ForumNotFoundException is thrown when a DatabaseMissingItemException is thrown.

```csharp
public void GetForumByName_ShouldThrowForumGeneralException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetForumsByNameContaining_ShouldReturnForums_WhenForumsExist()**

Tests that forums are returned when forums exist.

```csharp
public Task GetForumsByNameContaining_ShouldReturnForums_WhenForumsExist()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetForumsByNameContaining_ShouldThrowForumGeneralException_WhenDatabaseMissingItemExceptionIsThrown()**

Tests that a ForumNotFoundException is thrown when a DatabaseMissingItemException is thrown.

```csharp
public void GetForumsByNameContaining_ShouldThrowForumGeneralException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetForums_ShouldReturnAllForums_WhenForumsExist()**

Tests that all forums are returned when forums exist.

```csharp
public Task GetForums_ShouldReturnAllForums_WhenForumsExist()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetForums_ShouldThrowForumGeneralException_WhenDatabaseMissingItemExceptionIsThrown()**

Tests that a ForumNotFoundException is thrown when a DatabaseMissingItemException is thrown.

```csharp
public void GetForums_ShouldThrowForumGeneralException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **DetermineRecentSpaces_ShouldReturnRecentForums_WhenForumsExist()**

Tests that recent forums are returned when forums exist.

```csharp
public Task DetermineRecentSpaces_ShouldReturnRecentForums_WhenForumsExist()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **DetermineRecentSpaces_ShouldThrowForumGeneralException_WhenDatabaseMissingItemExceptionIsThrown()**

Tests that a ForumNotFoundException is thrown when a DatabaseMissingItemException is thrown.

```csharp
public void DetermineRecentSpaces_ShouldThrowForumGeneralException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetTopForums_ShouldReturnTopForums_WhenForumsExist()**

Tests that top forums are returned when forums exist.

```csharp
public Task GetTopForums_ShouldReturnTopForums_WhenForumsExist()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetTopForums_ShouldThrowForumGeneralException_WhenDatabaseMissingItemExceptionIsThrown()**

Tests that a ForumNotFoundException is thrown when a DatabaseMissingItemException is thrown.

```csharp
public void GetTopForums_ShouldThrowForumGeneralException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **InsertForum_ShouldThrowForumGeneralException_WhenGeneralExceptionIsThrown()**

Tests that a ForumGeneralException is thrown when a general exception is thrown during forum insertion.

```csharp
public void InsertForum_ShouldThrowForumGeneralException_WhenGeneralExceptionIsThrown()
```

### **DeleteForum_ShouldThrowForumGeneralException_WhenGeneralExceptionIsThrown()**

Tests that a ForumGeneralException is thrown when a general exception is thrown during forum deletion.

```csharp
public void DeleteForum_ShouldThrowForumGeneralException_WhenGeneralExceptionIsThrown()
```

### **GetForumByName_ShouldThrowForumGeneralException_WhenGeneralExceptionIsThrown()**

Tests that a ForumGeneralException is thrown when a general exception is thrown during forum retrieval by name.

```csharp
public void GetForumByName_ShouldThrowForumGeneralException_WhenGeneralExceptionIsThrown()
```

### **GetForumsByNameContaining_ShouldThrowForumGeneralException_WhenGeneralExceptionIsThrown()**

Tests that a ForumGeneralException is thrown when a general exception is thrown during forum search by name.

```csharp
public void GetForumsByNameContaining_ShouldThrowForumGeneralException_WhenGeneralExceptionIsThrown()
```

### **GetForums_ShouldThrowForumGeneralException_WhenGeneralExceptionIsThrown()**

Tests that a ForumGeneralException is thrown when a general exception is thrown during retrieval of all forums.

```csharp
public void GetForums_ShouldThrowForumGeneralException_WhenGeneralExceptionIsThrown()
```

### **DetermineRecentSpaces_ShouldThrowForumGeneralException_WhenGeneralExceptionIsThrown()**

Tests that a ForumGeneralException is thrown when a general exception is thrown during retrieval of recent forums.

```csharp
public void DetermineRecentSpaces_ShouldThrowForumGeneralException_WhenGeneralExceptionIsThrown()
```

### **GetTopForums_ShouldThrowForumGeneralException_WhenGeneralExceptionIsThrown()**

Tests that a ForumGeneralException is thrown when a general exception is thrown during retrieval of top forums.

```csharp
public void GetTopForums_ShouldThrowForumGeneralException_WhenGeneralExceptionIsThrown()
```
