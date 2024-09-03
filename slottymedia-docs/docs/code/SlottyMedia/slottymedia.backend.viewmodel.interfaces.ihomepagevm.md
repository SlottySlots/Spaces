# IHomePageVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

Interface for homepage viewmodel

```csharp
public interface IHomePageVm
```

## Properties

### **Posts**

Represents all posts shown on a homepage

```csharp
public abstract List<PostDto> Posts { get; set; }
```

#### Property Value

[List&lt;PostDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

## Methods

### **FetchPosts()**

Fetches all posts shown on the homepage of a user

```csharp
Task FetchPosts()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
Task
