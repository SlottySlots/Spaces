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

### **LikePost_AddsLikeWhenNotPreviouslyLiked()**

Tests that LikePost method adds a like when the post was not previously liked.

```csharp
public Task LikePost_AddsLikeWhenNotPreviouslyLiked()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LikePost_RemovesLikeWhenPreviouslyLiked()**

Tests that LikePost method removes a like when the post was previously liked.

```csharp
public Task LikePost_RemovesLikeWhenPreviouslyLiked()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetUserInformation_SetsUserInformation()**

Tests that GetUserInformation method sets the user information.

```csharp
public Task GetUserInformation_SetsUserInformation()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetCommentsCount_SetsCommentCount()**

Tests that GetCommentsCount method sets the comment count.

```csharp
public Task GetCommentsCount_SetsCommentCount()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetLikes_SetsLikeCountAndInitLiked()**

Tests that GetLikes method sets the like count and initializes the liked state.

```csharp
public Task GetLikes_SetsLikeCountAndInitLiked()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
