# SearchServiceTests

Namespace: SlottyMedia.Tests.ServiceTests

Tests the SearchService used for searching for users and topics in the database.

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

The setup method that is called before each test.

```csharp
public void Setup()
```

### **TearDown()**

The teardown method that is called after each test.

```csharp
public void TearDown()
```

### **SearchByUsernameOrTopic_ShouldReturnUserIds_WhenUsersFound()**

Tests if SearchByUsernameOrTopic method returns user IDs when users are found.

```csharp
public Task SearchByUsernameOrTopic_ShouldReturnUserIds_WhenUsersFound()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **SearchByUsernameOrTopic_ShouldReturnTopicIds_WhenTopicsFound()**

Tests if SearchByUsernameOrTopic method returns topic IDs when topics are found.

```csharp
public Task SearchByUsernameOrTopic_ShouldReturnTopicIds_WhenTopicsFound()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **SearchByUsernameOrTopic_ShouldReturnEmptyList_WhenNoResultsFound()**

Tests if SearchByUsernameOrTopic method returns an empty list when no results are found.

```csharp
public Task SearchByUsernameOrTopic_ShouldReturnEmptyList_WhenNoResultsFound()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **SearchByUsernameOrTopic_ShouldThrowException_WhenDatabaseThrowsException()**

Tests if SearchByUsernameOrTopic method throws SearchGeneralExceptions when a general database exception is thrown.

```csharp
public void SearchByUsernameOrTopic_ShouldThrowException_WhenDatabaseThrowsException()
```

### **SearchByUsernameOrTopic_ShouldThrowSearchGeneralExceptions_WhenDatabaseMissingItemExceptionIsThrown()**

Tests if SearchByUsernameOrTopic method throws SearchGeneralExceptions when DatabaseMissingItemException is thrown.

```csharp
public void SearchByUsernameOrTopic_ShouldThrowSearchGeneralExceptions_WhenDatabaseMissingItemExceptionIsThrown()
```

### **SearchByUsernameOrTopic_ShouldThrowSearchGeneralExceptions_WhenDatabaseExceptionIsThrown()**

Tests if SearchByUsernameOrTopic method throws SearchGeneralExceptions when GeneralDatabaseException is thrown.

```csharp
public void SearchByUsernameOrTopic_ShouldThrowSearchGeneralExceptions_WhenDatabaseExceptionIsThrown()
```
