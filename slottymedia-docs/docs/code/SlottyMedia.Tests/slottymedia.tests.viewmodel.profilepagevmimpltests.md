# ProfilePageVmImplTests

Namespace: SlottyMedia.Tests.Viewmodel

Unit tests for the  class.

```csharp
public class ProfilePageVmImplTests
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ProfilePageVmImplTests](./slottymedia.tests.viewmodel.profilepagevmimpltests.md)

## Constructors

### **ProfilePageVmImplTests()**

```csharp
public ProfilePageVmImplTests()
```

## Methods

### **SetUp()**

Sets up the test environment before each test.
 Initializes the mocks and the view model instance.

```csharp
public void SetUp()
```

### **Initialize_LoadsUserInfoAndPosts()**

Tests that the Initialize method loads user information and posts correctly.

```csharp
public Task Initialize_LoadsUserInfoAndPosts()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LoadPosts_LoadsPostsForUser()**

Tests that the LoadPosts method loads posts for the user correctly.

```csharp
public Task LoadPosts_LoadsPostsForUser()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **FollowThisUser_FollowsUser()**

Tests that the FollowThisUser method follows the user correctly.

```csharp
public Task FollowThisUser_FollowsUser()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UnfollowThisUser_UnfollowsUser()**

Tests that the UnfollowThisUser method unfollows the user correctly.

```csharp
public Task UnfollowThisUser_UnfollowsUser()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
