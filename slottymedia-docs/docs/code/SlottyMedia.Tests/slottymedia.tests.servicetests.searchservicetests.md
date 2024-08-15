# SearchServiceTests

Namespace: SlottyMedia.Tests.ServiceTests

```csharp
public class SearchServiceTests
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [SearchServiceTests](./slottymedia.tests.servicetests.searchservicetests.md)

## Constructors

### **SearchServiceTests()**

```csharp
public SearchServiceTests()
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

### **SearchByUsernameOrTopic_ShouldReturnUserIds_WhenUsersFound()**

```csharp
public Task SearchByUsernameOrTopic_ShouldReturnUserIds_WhenUsersFound()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **SearchByUsernameOrTopic_ShouldReturnTopicIds_WhenTopicsFound()**

```csharp
public Task SearchByUsernameOrTopic_ShouldReturnTopicIds_WhenTopicsFound()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **SearchByUsernameOrTopic_ShouldReturnEmptyList_WhenNoResultsFound()**

```csharp
public Task SearchByUsernameOrTopic_ShouldReturnEmptyList_WhenNoResultsFound()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **SearchByUsernameOrTopic_ShouldThrowException_WhenDatabaseThrowsException()**

```csharp
public void SearchByUsernameOrTopic_ShouldThrowException_WhenDatabaseThrowsException()
```

### **SearchByUsernameOrTopic_ShouldThrowSearchGeneralExceptions_WhenDatabaseMissingItemExceptionIsThrown()**

```csharp
public void SearchByUsernameOrTopic_ShouldThrowSearchGeneralExceptions_WhenDatabaseMissingItemExceptionIsThrown()
```

### **SearchByUsernameOrTopic_ShouldThrowSearchGeneralExceptions_WhenDatabaseExceptionIsThrown()**

```csharp
public void SearchByUsernameOrTopic_ShouldThrowSearchGeneralExceptions_WhenDatabaseExceptionIsThrown()
```
