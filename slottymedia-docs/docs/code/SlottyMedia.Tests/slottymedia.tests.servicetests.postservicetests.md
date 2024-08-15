# PostServiceTests

Namespace: SlottyMedia.Tests.ServiceTests

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

```csharp
public void Setup()
```

### **TearDown()**

```csharp
public void TearDown()
```

### **InsertPost_ShouldReturnInsertedPost()**

```csharp
public Task InsertPost_ShouldReturnInsertedPost()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **InsertPost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()**

```csharp
public void InsertPost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **InsertPost_ShouldThrowPostGeneralException_WhenDatabaseExceptionIsThrown()**

```csharp
public void InsertPost_ShouldThrowPostGeneralException_WhenDatabaseExceptionIsThrown()
```

### **UpdatePost_ShouldReturnUpdatedPost()**

```csharp
public Task UpdatePost_ShouldReturnUpdatedPost()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UpdatePost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()**

```csharp
public void UpdatePost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **UpdatePost_ShouldThrowPostGeneralException_WhenDatabaseExceptionIsThrown()**

```csharp
public void UpdatePost_ShouldThrowPostGeneralException_WhenDatabaseExceptionIsThrown()
```

### **DeletePost_ShouldReturnTrue()**

```csharp
public Task DeletePost_ShouldReturnTrue()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **DeletePost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()**

```csharp
public void DeletePost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()
```

### **DeletePost_ShouldThrowPostGeneralException_WhenDatabaseExceptionIsThrown()**

```csharp
public void DeletePost_ShouldThrowPostGeneralException_WhenDatabaseExceptionIsThrown()
```

### **GetPostsFromForum_ShouldReturnListOfPostTitles()**

```csharp
public Task GetPostsFromForum_ShouldReturnListOfPostTitles()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetPostsFromForum_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()**

```csharp
public void GetPostsFromForum_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetPostsFromForum_ShouldThrowPostGeneralException_WhenDatabaseExceptionIsThrown()**

```csharp
public void GetPostsFromForum_ShouldThrowPostGeneralException_WhenDatabaseExceptionIsThrown()
```

### **GetPostsByUserId_ShouldReturnListOfPostDtos()**

```csharp
public Task GetPostsByUserId_ShouldReturnListOfPostDtos()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetPostsByUserId_ShouldThrowPostGeneralException_WhenDatabaseExceptionIsThrown()**

```csharp
public void GetPostsByUserId_ShouldThrowPostGeneralException_WhenDatabaseExceptionIsThrown()
```

### **GetPostsByUserIdByForumId_ShouldReturnListOfPostDtos()**

```csharp
public Task GetPostsByUserIdByForumId_ShouldReturnListOfPostDtos()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetPostsByUserIdByForumId_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()**

```csharp
public void GetPostsByUserIdByForumId_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
```

### **GetPostsByForumId_ShouldReturnListOfPostDtos()**

```csharp
public Task GetPostsByForumId_ShouldReturnListOfPostDtos()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetPostsByForumId_ShouldThrowPostGeneralException_WhenDatabaseExceptionIsThrown()**

```csharp
public void GetPostsByForumId_ShouldThrowPostGeneralException_WhenDatabaseExceptionIsThrown()
```
