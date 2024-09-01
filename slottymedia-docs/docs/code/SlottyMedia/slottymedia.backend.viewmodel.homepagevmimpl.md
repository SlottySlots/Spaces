# HomePageVmImpl

Namespace: SlottyMedia.Backend.ViewModel

```csharp
public class HomePageVmImpl : SlottyMedia.Backend.ViewModel.Interfaces.IHomePageVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [HomePageVmImpl](./slottymedia.backend.viewmodel.homepagevmimpl.md)<br>
Implements [IHomePageVm](./slottymedia.backend.viewmodel.interfaces.ihomepagevm.md)

## Properties

### **Posts**

```csharp
public List<PostDto> Posts { get; set; }
```

#### Property Value

[List&lt;PostDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

## Constructors

### **HomePageVmImpl(IPostService)**

Ctor used for dep inject

```csharp
public HomePageVmImpl(IPostService postService)
```

#### Parameters

`postService` [IPostService](./slottymedia.backend.services.interfaces.ipostservice.md)<br>

## Methods

### **FetchPosts()**

```csharp
public Task FetchPosts()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
