# ISpaceVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

This ViewModel represents the state of the Space Page.

```csharp
public interface ISpaceVm
```

## Methods

### **GetSpaceInformation(String)**

Gets ForumDTO based on provided name

```csharp
Task<ForumDto> GetSpaceInformation(string name)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Forumname to look up in db

#### Returns

[Task&lt;ForumDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
ForumDto?

### **LoadSpaceDetails(String)**

Fetches the details of a specific space based on its name
 and populates the [Space](./slottymedia.components.pages.space.md) property.

```csharp
Task LoadSpaceDetails(string name)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the space to load information for.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetPostsByForumId(Guid, Int32, Int32)**

Gets forums of a user by their id and enables slicing via offsets

```csharp
Task<List<PostDto>> GetPostsByForumId(Guid forumId, int startOfSet, int endOfSet)
```

#### Parameters

`forumId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
Forum that the posts belong to

`startOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Startindex of the posts sorted by date

`endOfSet` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Endindex of the posts sorted by data

#### Returns

[Task&lt;List&lt;PostDto&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
List of PostDtos
