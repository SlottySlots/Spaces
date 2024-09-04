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

Sets up the test environment by initializing mocks and the PostVmImpl instance.

```csharp
public void SetUp()
```

### **GetOwner_ReturnsUserDto()**

Tests that GetOwner method returns the expected UserDto.

```csharp
public Task GetOwner_ReturnsUserDto()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetCommentsCount_ReturnsCount()**

Tests that GetCommentsCount method returns the expected count of comments.

```csharp
public Task GetCommentsCount_ReturnsCount()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetUserInformation_ReturnsUserInformationDto()**

Tests that GetUserInformation method returns the expected UserInformationDto.

```csharp
public Task GetUserInformation_ReturnsUserInformationDto()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetLikes_ReturnsListOfGuids()**

Tests that GetLikes method returns the expected list of Guids.

```csharp
public Task GetLikes_ReturnsListOfGuids()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **AddLike_CallsInsertLike()**

Tests that AddLike method calls InsertLike on the ILikeService mock.

```csharp
public Task AddLike_CallsInsertLike()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **RemoveLike_CallsDeleteLike()**

Tests that RemoveLike method calls DeleteLike on the ILikeService mock.

```csharp
public Task RemoveLike_CallsDeleteLike()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
