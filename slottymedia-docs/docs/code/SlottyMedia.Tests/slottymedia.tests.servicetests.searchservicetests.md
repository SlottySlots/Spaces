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

### **SearchByUsername_ShouldReturnUserIds_WhenUsersFound()**

Tests if SearchByUsername method returns user IDs when users are found.

```csharp
public Task SearchByUsername_ShouldReturnUserIds_WhenUsersFound()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **SearchByTopic_ShouldReturnTopicIds_WhenTopicsFound()**

Tests if SearchByTopic method returns topic IDs when topics are found.

```csharp
public Task SearchByTopic_ShouldReturnTopicIds_WhenTopicsFound()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **SearchByUsernameOrTopic_ShouldReturnEmptyList_WhenNoResultsFound()**

Tests if SearchByUsername and SearchByTopic methods return an empty list when no results are found.

```csharp
public Task SearchByUsernameOrTopic_ShouldReturnEmptyList_WhenNoResultsFound()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **SearchByUsernameOrTopic_ShouldThrowException_WhenDatabaseThrowsException()**

Tests if SearchByUsername and SearchByTopic methods throw SearchGeneralExceptions when a general database exception
 is thrown.

```csharp
public void SearchByUsernameOrTopic_ShouldThrowException_WhenDatabaseThrowsException()
```

### **SearchByUsernameOrTopic_ShouldThrowSearchGeneralExceptions_WhenDatabaseMissingItemExceptionIsThrown()**

Tests if SearchByUsername and SearchByTopic methods throw SearchGeneralExceptions when DatabaseMissingItemException
 is thrown.

```csharp
public void SearchByUsernameOrTopic_ShouldThrowSearchGeneralExceptions_WhenDatabaseMissingItemExceptionIsThrown()
```

### **SearchByUsernameOrTopic_ShouldThrowSearchGeneralExceptions_WhenDatabaseExceptionIsThrown()**

Tests if SearchByUsername and SearchByTopic methods throw SearchGeneralExceptions when GeneralDatabaseException is
 thrown.

```csharp
public void SearchByUsernameOrTopic_ShouldThrowSearchGeneralExceptions_WhenDatabaseExceptionIsThrown()
```
