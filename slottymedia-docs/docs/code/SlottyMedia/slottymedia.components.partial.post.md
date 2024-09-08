# Post

Namespace: SlottyMedia.Components.Partial

```csharp
public class Post : Microsoft.AspNetCore.Components.ComponentBase, Microsoft.AspNetCore.Components.IComponent, Microsoft.AspNetCore.Components.IHandleEvent, Microsoft.AspNetCore.Components.IHandleAfterRender
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ComponentBase → [Post](./slottymedia.components.partial.post.md)<br>
Implements IComponent, IHandleEvent, IHandleAfterRender

## Properties

### **Dto**

The post to be rendered.

```csharp
public PostDto Dto { get; set; }
```

#### Property Value

[PostDto](./slottymedia.backend.dtos.postdto.md)<br>

### **CurrentUserId**

The current logged in user id to propagate towards like component.

```csharp
public Guid CurrentUserId { get; set; }
```

#### Property Value

[Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

### **OnPostClick**

This event is triggered when the post's comment button is clicked.
 This event will be used to navigate to the post's dedicated page from the home page (i.e. `/post/{ID}`).
 On the post's dedicated page this event should be left unset.

```csharp
public EventCallback OnPostClick { get; set; }
```

#### Property Value

EventCallback<br>

### **PostVm**

Injected instance of the IPostVm interface.

```csharp
public IPostVm PostVm { get; set; }
```

#### Property Value

[IPostVm](./slottymedia.backend.viewmodel.interfaces.ipostvm.md)<br>

## Constructors

### **Post()**

```csharp
public Post()
```

## Methods

### **BuildRenderTree(RenderTreeBuilder)**

```csharp
protected void BuildRenderTree(RenderTreeBuilder __builder)
```

#### Parameters

`__builder` RenderTreeBuilder<br>

### **OnParametersSetAsync()**

```csharp
protected Task OnParametersSetAsync()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **OnAfterRender(Boolean)**

```csharp
protected void OnAfterRender(bool firstRender)
```

#### Parameters

`firstRender` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **LikeClick()**

Handles the click event on the like button, adding or removing a like based on the current state.

```csharp
public void LikeClick()
```
