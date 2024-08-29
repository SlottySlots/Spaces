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

### **IsLoadingPosts**

Indicates whether more posts are currently being loaded

```csharp
public abstract bool IsLoadingPosts { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Posts**

The posts that will be showcased

```csharp
public abstract List<PostDto> Posts { get; }
```

#### Property Value

[List&lt;PostDto&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **TotalNumberOfPosts**

The total number of existing posts. Used to enable the user to load more posts on demand.

```csharp
public abstract int TotalNumberOfPosts { get; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

## Methods

### **Initialize()**

Initializes this ViewModel, which counts the total number of existing posts and loads the first few
 posts into the view.

```csharp
Task Initialize()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LoadMorePosts()**

Loads more posts to the view. Does nothing if all posts have already been fetched.

```csharp
Task LoadMorePosts()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
