# Comment

Namespace: SlottyMedia.Components.Partial.PostPage

```csharp
public class Comment : Microsoft.AspNetCore.Components.ComponentBase, Microsoft.AspNetCore.Components.IComponent, Microsoft.AspNetCore.Components.IHandleEvent, Microsoft.AspNetCore.Components.IHandleAfterRender
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ComponentBase → [Comment](./slottymedia.components.partial.postpage.comment.md)<br>
Implements IComponent, IHandleEvent, IHandleAfterRender

## Properties

### **Id**

The ID of the comment to render

```csharp
public Guid Id { get; set; }
```

#### Property Value

[Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

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
