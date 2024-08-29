# Comment

Namespace: SlottyMedia.Components.Partial

```csharp
public class Comment : Microsoft.AspNetCore.Components.ComponentBase, Microsoft.AspNetCore.Components.IComponent, Microsoft.AspNetCore.Components.IHandleEvent, Microsoft.AspNetCore.Components.IHandleAfterRender
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ComponentBase → [Comment](./slottymedia.components.partial.comment.md)<br>
Implements IComponent, IHandleEvent, IHandleAfterRender

## Properties

### **Dto**

```csharp
public CommentDto Dto { get; set; }
```

#### Property Value

[CommentDto](./slottymedia.backend.dtos.commentdto.md)<br>

## Constructors

### **Comment()**

```csharp
public Comment()
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
