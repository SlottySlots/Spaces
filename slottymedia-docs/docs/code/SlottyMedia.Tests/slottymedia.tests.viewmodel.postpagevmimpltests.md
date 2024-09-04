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

### **LoadPage_SetsPostAndComments()**

Tests that LoadPage method sets the Post and Comments properties.

```csharp
public Task LoadPage_SetsPostAndComments()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LoadPage_SetsPostToNullWhenPostNotFound()**

Tests that LoadPage method sets the Post property to null when the post is not found.

```csharp
public Task LoadPage_SetsPostToNullWhenPostNotFound()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LoadMoreComments_AddsCommentsToList()**

Tests that LoadMoreComments method adds comments to the Comments list.

```csharp
public Task LoadMoreComments_AddsCommentsToList()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LoadMoreComments_DoesNotLoadWhenPostIsNull()**

Tests that LoadMoreComments method does not load comments when the Post property is null.

```csharp
public Task LoadMoreComments_DoesNotLoadWhenPostIsNull()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
