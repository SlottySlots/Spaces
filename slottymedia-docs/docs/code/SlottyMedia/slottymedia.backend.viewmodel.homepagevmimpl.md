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

### **Page**

```csharp
public IPage<PostDto> Page { get; private set; }
```

#### Property Value

IPage&lt;PostDto&gt;<br>

### **CurrentUserId**

```csharp
public Guid CurrentUserId { get; private set; }
```

#### Property Value

[Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

### **IsAuthenticated**

```csharp
public bool IsAuthenticated { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

## Constructors

### **HomePageVmImpl(IPostService, IAuthService)**

Instantiates this class

```csharp
public HomePageVmImpl(IPostService postService, IAuthService authService)
```

#### Parameters

`postService` [IPostService](./slottymedia.backend.services.interfaces.ipostservice.md)<br>

`authService` [IAuthService](./slottymedia.backend.services.interfaces.iauthservice.md)<br>

## Methods

### **Initialize()**

```csharp
public Task Initialize()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LoadPage(Int32)**

```csharp
public Task LoadPage(int pageNumber)
```

#### Parameters

`pageNumber` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
