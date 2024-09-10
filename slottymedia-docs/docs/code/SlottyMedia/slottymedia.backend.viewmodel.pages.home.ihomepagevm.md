# IHomePageVm

Namespace: SlottyMedia.Backend.ViewModel.Pages.Home

This ViewModel represents the state of the  page.

```csharp
public interface IHomePageVm
```

## Properties

### **AuthPrincipalId**

The ID of the currently logged in user.

```csharp
public abstract Nullable<Guid> AuthPrincipalId { get; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **IsLoadingPage**

Indicates whether the page is loading (for the first time)

```csharp
public abstract bool IsLoadingPage { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Page**

The posts that will be showcased

```csharp
public abstract IPage<PostDto> Page { get; }
```

#### Property Value

IPage&lt;PostDto&gt;<br>

## Methods

### **Initialize()**

Initializes this ViewModel, which counts the total number of existing posts and loads the first few
 posts into the view.

```csharp
Task Initialize()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LoadPage(Int32)**

Loads more posts to the view. Does nothing if all posts have already been fetched.

```csharp
Task LoadPage(int pageNumber)
```

#### Parameters

`pageNumber` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
