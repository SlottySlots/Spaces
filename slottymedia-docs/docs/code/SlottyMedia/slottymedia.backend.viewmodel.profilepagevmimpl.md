# ProfilePageVmImpl

Namespace: SlottyMedia.Backend.ViewModel

Viewmodel used for the profile page /profile?id=..

```csharp
public class ProfilePageVmImpl : SlottyMedia.Backend.ViewModel.Interfaces.IProfilePageVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ProfilePageVmImpl](./slottymedia.backend.viewmodel.profilepagevmimpl.md)<br>
Implements [IProfilePageVm](./slottymedia.backend.viewmodel.interfaces.iprofilepagevm.md)

## Constructors

### **ProfilePageVmImpl(IUserService, IPostService)**

Ctor for dep inject

```csharp
public ProfilePageVmImpl(IUserService userService, IPostService postService)
```

#### Parameters

`userService` [IUserService](./slottymedia.backend.services.interfaces.iuserservice.md)<br>

`postService` [IPostService](./slottymedia.backend.services.interfaces.ipostservice.md)<br>

## Methods

### **GetUserInfo(Guid)**

Gets common user information by id such as name, description, picture, ..

```csharp
public Task<UserInformationDto> GetUserInfo(Guid userId)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
User Id to retrieve information from

#### Returns

[Task&lt;UserInformationDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
UserInformationDto. Can be null when no information could be retrieved e.g. when user doesn't exist

### **UserFollowRelation(Guid, Guid)**

Checks the follow relation of two users

```csharp
public Task<Nullable<bool>> UserFollowRelation(Guid userIdToCheck, Guid userIdLoggedIn)
```

#### Parameters

`userIdToCheck` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
User that may be followed by the userIdLoggedIn

`userIdLoggedIn` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
User that may have followed the another

#### Returns

[Task&lt;Nullable&lt;Boolean&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Bool. Can be null whenever the ids are the same. Hence indicating a wrong usage.

### **FollowUserById(Guid, Guid)**

Follows a user by its ids

```csharp
public Task FollowUserById(Guid userIdFollows, Guid userIdToFollow)
```

#### Parameters

`userIdFollows` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
User that tries to follow

`userIdToFollow` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
User that will be followed by another

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UnfollowUserById(Guid, Guid)**

Unfollows a user

```csharp
public Task UnfollowUserById(Guid userIdFollows, Guid userIdToUnfollow)
```

#### Parameters

`userIdFollows` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
User that follows another

`userIdToUnfollow` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
User that will be unfollowed

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetPostsByUserId(Guid, Int32, Int32)**

Gets post by another user by id

```csharp
public Task<List<PostDto>> GetPostsByUserId(Guid userId, int startOfSet, int endOfSet)
```

#### Parameters

`userId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
User the posts belongs to

`startOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Starting index on which the follows are retrieved (they are sorted by date)

`endOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Ending index used to slice the posts in a specific intervall

#### Returns

[Task&lt;List&lt;PostDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
List of PostDtos
