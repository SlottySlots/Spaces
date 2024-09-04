# PostPageVmImplTests

Namespace: SlottyMedia.Tests.Viewmodel

Unit tests for the PostPageVmImpl class.

```csharp
public class PostPageVmImplTests
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PostPageVmImplTests](./slottymedia.tests.viewmodel.postpagevmimpltests.md)

## Constructors

### **PostPageVmImplTests()**

```csharp
public PostPageVmImplTests()
```

## Methods

### **SetUp()**

Sets up the test environment by initializing mocks and the PostPageVmImpl instance.

```csharp
public void SetUp()
```

### **Initialize_SetsPostAndLoadsFirstCommentsPage()**

Tests that Initialize method sets the Post and loads the first page of comments.

```csharp
public Task Initialize_SetsPostAndLoadsFirstCommentsPage()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **Initialize_SetsPostToNullWhenPostNotFound()**

Tests that Initialize method sets the Post property to null when the post is not found.

```csharp
public Task Initialize_SetsPostToNullWhenPostNotFound()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LoadCommentsPage_AddsCommentsToList()**

Tests that LoadCommentsPage method adds comments to the Comments list.

```csharp
public Task LoadCommentsPage_AddsCommentsToList()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LoadCommentsPage_DoesNotLoadWhenPostIsNull()**

Tests that LoadCommentsPage method does not load comments when the Post property is null.

```csharp
public Task LoadCommentsPage_DoesNotLoadWhenPostIsNull()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
