# HomePageVmImpl

Namespace: SlottyMedia.Backend.ViewModel

```csharp
public class HomePageVmImpl : SlottyMedia.Backend.ViewModel.Interfaces.IHomePageVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [HomePageVmImpl](./slottymedia.backend.viewmodel.homepagevmimpl.md)<br>
Implements [IHomePageVm](./slottymedia.backend.viewmodel.interfaces.ihomepagevm.md)

## Properties

### **IsLoadingPage**

```csharp
public bool IsLoadingPage { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **IsLoadingPosts**

```csharp
public bool IsLoadingPosts { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Posts**

```csharp
public List<PostDto> Posts { get; private set; }
```

#### Property Value

[List&lt;PostDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **TotalNumberOfPosts**

```csharp
public int TotalNumberOfPosts { get; private set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

## Constructors

### **HomePageVmImpl(IPostService)**

Instantiates this class

```csharp
public HomePageVmImpl(IPostService postService)
```

#### Parameters

`postService` [IPostService](./slottymedia.backend.services.interfaces.ipostservice.md)<br>

## Methods

### **Initialize()**

```csharp
public Task Initialize()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LoadMorePosts()**

```csharp
public Task LoadMorePosts()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
