# ForumServiceTests

Namespace: SlottyMedia.Tests.ServiceTests

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

```csharp
public void Setup()
```

### **TearDown()**

```csharp
public void TearDown()
```

### **InsertForum_ShouldInsertForum_WhenForumIsValid()**

```csharp
public Task InsertForum_ShouldInsertForum_WhenForumIsValid()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **InsertForum_ShouldThrowForumIudException_WhenDatabaseIudActionExceptionIsThrown()**

```csharp
public void InsertForum_ShouldThrowForumIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **InsertForum_ShouldThrowForumGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

```csharp
public void InsertForum_ShouldThrowForumGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```

### **DeleteForum_ShouldDeleteForum_WhenForumIsValid()**

```csharp
public Task DeleteForum_ShouldDeleteForum_WhenForumIsValid()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **DeleteForum_ShouldThrowForumIudException_WhenDatabaseIudActionExceptionIsThrown()**

```csharp
public void DeleteForum_ShouldThrowForumIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **DeleteForum_ShouldThrowForumGeneralException_WhenGeneralDatabaseExceptionIsThrown()**

```csharp
public void DeleteForum_ShouldThrowForumGeneralException_WhenGeneralDatabaseExceptionIsThrown()
```

### **GetForumByName_ShouldReturnForum_WhenForumExists()**

```csharp
public Task GetForumByName_ShouldReturnForum_WhenForumExists()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetForumByName_ShouldThrowForumGeneralException_WhenDatabaseMissingItemExceptionIsThrown()**

```csharp
public void GetForumByName_ShouldThrowForumGeneralException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetForumsByNameContaining_ShouldReturnForums_WhenForumsExist()**

```csharp
public Task GetForumsByNameContaining_ShouldReturnForums_WhenForumsExist()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetForumsByNameContaining_ShouldThrowForumGeneralException_WhenDatabaseMissingItemExceptionIsThrown()**

```csharp
public void GetForumsByNameContaining_ShouldThrowForumGeneralException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetForums_ShouldReturnAllForums_WhenForumsExist()**

```csharp
public Task GetForums_ShouldReturnAllForums_WhenForumsExist()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetForums_ShouldThrowForumGeneralException_WhenDatabaseMissingItemExceptionIsThrown()**

```csharp
public void GetForums_ShouldThrowForumGeneralException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **DetermineRecentSpaces_ShouldReturnRecentForums_WhenForumsExist()**

```csharp
public Task DetermineRecentSpaces_ShouldReturnRecentForums_WhenForumsExist()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **DetermineRecentSpaces_ShouldThrowForumGeneralException_WhenDatabaseMissingItemExceptionIsThrown()**

```csharp
public void DetermineRecentSpaces_ShouldThrowForumGeneralException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetTopForums_ShouldReturnTopForums_WhenForumsExist()**

```csharp
public Task GetTopForums_ShouldReturnTopForums_WhenForumsExist()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetTopForums_ShouldThrowForumGeneralException_WhenDatabaseMissingItemExceptionIsThrown()**

```csharp
public void GetTopForums_ShouldThrowForumGeneralException_WhenDatabaseMissingItemExceptionIsThrown()
```
