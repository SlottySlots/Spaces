# ProfilePageVmImplTests

Namespace:

Unit tests for the  class.

```csharp
public class ProfilePageVmImplTests
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ProfilePageVmImplTests](./profilepagevmimpltests.md)

## Constructors

### **ProfilePageVmImplTests()**

```csharp
public ProfilePageVmImplTests()
```

## Methods

### **SetUp()**

```csharp
public void SetUp()
```

### **GetUserInfo_ShouldReturnUserInformationDto_WhenUserExists()**

```csharp
public Task GetUserInfo_ShouldReturnUserInformationDto_WhenUserExists()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetUserInfo_ShouldReturnNull_WhenUserDoesNotExist()**

```csharp
public Task GetUserInfo_ShouldReturnNull_WhenUserDoesNotExist()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UserFollowRelation_ShouldReturnTrue_WhenUserFollowsAnother()**

```csharp
public Task UserFollowRelation_ShouldReturnTrue_WhenUserFollowsAnother()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UserFollowRelation_ShouldReturnFalse_WhenUserDoesNotFollowAnother()**

```csharp
public Task UserFollowRelation_ShouldReturnFalse_WhenUserDoesNotFollowAnother()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UserFollowRelation_ShouldReturnNull_WhenUserIdsAreSame()**

```csharp
public Task UserFollowRelation_ShouldReturnNull_WhenUserIdsAreSame()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **FollowUserById_ShouldCallFollowUserByIdOnUserService()**

```csharp
public Task FollowUserById_ShouldCallFollowUserByIdOnUserService()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UnfollowUserById_ShouldCallUnfollowUserByIdOnUserService()**

```csharp
public Task UnfollowUserById_ShouldCallUnfollowUserByIdOnUserService()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetPostsByUserId_ShouldReturnListOfPostDtos()**

```csharp
public Task GetPostsByUserId_ShouldReturnListOfPostDtos()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
