# Post

Namespace: SlottyMedia.Components.Partial

```csharp
public class Post : Microsoft.AspNetCore.Components.ComponentBase, Microsoft.AspNetCore.Components.IComponent, Microsoft.AspNetCore.Components.IHandleEvent, Microsoft.AspNetCore.Components.IHandleAfterRender
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ComponentBase → [Post](./slottymedia.components.partial.post.md)<br>
Implements IComponent, IHandleEvent, IHandleAfterRender

## Properties

### **Dto**

```csharp
public PostDto Dto { get; set; }
```

#### Property Value

[PostDto](./slottymedia.backend.dtos.postdto.md)<br>

### **CurrentUserId**

The current logged in user id to propagate towards like component

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

### **UserInformationDto**

```csharp
public UserInformationDto UserInformationDto { get; set; }
```

#### Property Value

[UserInformationDto](./slottymedia.backend.dtos.userinformationdto.md)<br>

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

### **SetLikeCountState()**

```csharp
public Task SetLikeCountState()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LikeClick(Boolean)**

```csharp
public void LikeClick(bool wasUnliked)
```

#### Parameters

`wasUnliked` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
