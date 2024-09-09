# HomePageVmImpl

Namespace: SlottyMedia.Backend.ViewModel.Pages.Home

```csharp
public class HomePageVmImpl : IHomePageVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [HomePageVmImpl](./slottymedia.backend.viewmodel.pages.home.homepagevmimpl.md)<br>
Implements [IHomePageVm](./slottymedia.backend.viewmodel.pages.home.ihomepagevm.md)

## Properties

### **AuthPrincipalId**

```csharp
public Nullable<Guid> AuthPrincipalId { get; private set; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

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
