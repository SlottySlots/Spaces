# ForumServiceTests

Namespace: SlottyMedia.Tests.ServiceTests

Tests for the ForumService class.

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

Setup method to initialize mocks and the service before each test.

```csharp
public void Setup()
```

### **TearDown()**

Teardown method to reset mocks after each test.

```csharp
public void TearDown()
```

### **InsertForum_ShouldReturnInsertedForum_WhenInsertIsSuccessful()**

Tests that InsertForum returns the inserted forum when the insert is successful.

```csharp
public Task InsertForum_ShouldReturnInsertedForum_WhenInsertIsSuccessful()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **InsertForum_ShouldThrowForumIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests that InsertForum throws ForumIudException when a DatabaseIudActionException is thrown.

```csharp
public void InsertForum_ShouldThrowForumIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **InsertForum_ShouldThrowForumGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests that InsertForum throws ForumGeneralException when a GeneralDatabaseException is thrown.

```csharp
public void InsertForum_ShouldThrowForumGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```

### **DeleteForum_ShouldCompleteSuccessfully_WhenDeleteIsSuccessful()**

Tests that DeleteForum completes successfully when the delete is successful.

```csharp
public Task DeleteForum_ShouldCompleteSuccessfully_WhenDeleteIsSuccessful()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **DeleteForum_ShouldThrowForumIudException_WhenDatabaseIudActionExceptionIsThrown()**

Tests that DeleteForum throws ForumIudException when a DatabaseIudActionException is thrown.

```csharp
public void DeleteForum_ShouldThrowForumIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **DeleteForum_ShouldThrowForumGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

Tests that DeleteForum throws ForumGeneralException when a GeneralDatabaseException is thrown.

```csharp
public void DeleteForum_ShouldThrowForumGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```
