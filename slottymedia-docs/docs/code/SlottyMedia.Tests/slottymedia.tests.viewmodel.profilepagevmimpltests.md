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

### **GetUserInfo_ValidUserId_ReturnsUserInformation()**

Verifies that GetUserInfo returns user information for a valid user ID.

```csharp
public Task GetUserInfo_ValidUserId_ReturnsUserInformation()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetUserInfo_InvalidUserId_ReturnsNull()**

Verifies that GetUserInfo returns null for an invalid user ID.

```csharp
public Task GetUserInfo_InvalidUserId_ReturnsNull()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UserFollowRelation_DifferentUserIds_ReturnsFollowRelation()**

Verifies that UserFollowRelation returns true for different user IDs.

```csharp
public Task UserFollowRelation_DifferentUserIds_ReturnsFollowRelation()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UserFollowRelation_SameUserIds_ReturnsNull()**

Verifies that UserFollowRelation returns null for the same user IDs.

```csharp
public Task UserFollowRelation_SameUserIds_ReturnsNull()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **FollowUserById_ValidUserIds_CallsFollowUserById()**

Verifies that FollowUserById calls the FollowUserById method of the user service with valid user IDs.

```csharp
public Task FollowUserById_ValidUserIds_CallsFollowUserById()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UnfollowUserById_ValidUserIds_CallsUnfollowUserById()**

Verifies that UnfollowUserById calls the UnfollowUserById method of the user service with valid user IDs.

```csharp
public Task UnfollowUserById_ValidUserIds_CallsUnfollowUserById()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetPostsByUserId_ValidUserId_ReturnsPosts()**

Verifies that GetPostsByUserId returns posts for a valid user ID.

```csharp
public Task GetPostsByUserId_ValidUserId_ReturnsPosts()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetPostsByUserId_InvalidUserId_ReturnsEmptyList()**

Verifies that GetPostsByUserId returns an empty list for an invalid user ID.

```csharp
public Task GetPostsByUserId_InvalidUserId_ReturnsEmptyList()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
