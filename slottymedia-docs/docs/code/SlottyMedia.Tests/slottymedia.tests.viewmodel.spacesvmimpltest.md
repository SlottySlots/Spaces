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

### **LoadForums_LoadsForumsSuccessfully()**

Tests that the LoadForums method loads forums successfully.

```csharp
public Task LoadForums_LoadsForumsSuccessfully()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LoadForums_HandlesException()**

Tests that the LoadForums method handles exceptions correctly.

```csharp
public Task LoadForums_HandlesException()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **Constructor_ThrowsArgumentNullException_WhenForumServiceIsNull()**

Tests that the constructor throws an ArgumentNullException when the forum service is null.

```csharp
public void Constructor_ThrowsArgumentNullException_WhenForumServiceIsNull()
```
