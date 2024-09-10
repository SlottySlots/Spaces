# PostVmImplTests

Namespace: SlottyMedia.Tests.Viewmodel

Unit tests for the PostVmImpl class.

```csharp
public class PostVmImplTests
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PostVmImplTests](./slottymedia.tests.viewmodel.postvmimpltests.md)

## Constructors

### **PostVmImplTests()**

```csharp
public PostVmImplTests()
```

## Methods

### **SetUp()**

Sets up the test environment before each test.

```csharp
public void SetUp()
```

### **Initialize_LoadsAllPostRelatedInformation()**

Tests that Initialize method loads all post-related information.

```csharp
public Task Initialize_LoadsAllPostRelatedInformation()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LikeThisPost_WhenPostNotLiked_ShouldLikePost()**

Tests that LikePost method adds a like when the post was not previously liked.

```csharp
public Task LikeThisPost_WhenPostNotLiked_ShouldLikePost()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LikeThisPost_WhenPostLiked_ShouldUnlikePost()**

Tests that LikePost method removes a like when the post was previously liked.

```csharp
public Task LikeThisPost_WhenPostLiked_ShouldUnlikePost()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
