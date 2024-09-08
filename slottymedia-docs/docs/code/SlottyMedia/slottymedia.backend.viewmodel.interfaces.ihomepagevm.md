# IHomePageVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

This ViewModel represents the state of the [Home](./slottymedia.components.pages.home.md) page.

```csharp
public interface IHomePageVm
```

## Properties

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

### **CurrentUserId**

The ID of the currently logged in user.

```csharp
public abstract Guid CurrentUserId { get; }
```

#### Property Value

[Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

### **IsAuthenticated**

True if the user is authenticated, false otherwise.

```csharp
public abstract bool IsAuthenticated { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

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
