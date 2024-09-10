# SpacesVmImplTest

Namespace: SlottyMedia.Tests.Viewmodel

Unit tests for the  class.

```csharp
public class SpacesVmImplTest
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [SpacesVmImplTest](./slottymedia.tests.viewmodel.spacesvmimpltest.md)

## Constructors

### **SpacesVmImplTest()**

```csharp
public SpacesVmImplTest()
```

## Methods

### **Setup()**

Sets up the test environment before each test.

```csharp
public void Setup()
```

### **LoadForums_ValidResponse_UpdatesForumsList()**

Verifies that LoadForums updates the forums list with a valid response.

```csharp
public Task LoadForums_ValidResponse_UpdatesForumsList()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LoadForums_ExceptionThrown_LogsError()**

Verifies that LoadForums logs an error and returns an empty list when an exception is thrown.

```csharp
public Task LoadForums_ExceptionThrown_LogsError()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **Constructor_NullForumService_ThrowsArgumentNullException()**

Verifies that the constructor throws an ArgumentNullException when the forum service is null.

```csharp
public void Constructor_NullForumService_ThrowsArgumentNullException()
```
