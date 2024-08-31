# PostPage

Namespace: SlottyMedia.Components.Pages

```csharp
public class PostPage : Microsoft.AspNetCore.Components.ComponentBase, Microsoft.AspNetCore.Components.IComponent, Microsoft.AspNetCore.Components.IHandleEvent, Microsoft.AspNetCore.Components.IHandleAfterRender
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ComponentBase → [PostPage](./slottymedia.components.pages.postpage.md)<br>
Implements IComponent, IHandleEvent, IHandleAfterRender

## Properties

### **PostId**

The ID of the post to showcase

```csharp
public Nullable<Guid> PostId { get; set; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **ViewModel**

The ViewModel for this component

```csharp
public IPostPageVm ViewModel { get; set; }
```

#### Property Value

[IPostPageVm](./slottymedia.backend.viewmodel.interfaces.ipostpagevm.md)<br>

## Constructors

### **PostPage()**

```csharp
public PostPage()
```

## Methods

### **BuildRenderTree(RenderTreeBuilder)**

```csharp
protected void BuildRenderTree(RenderTreeBuilder __builder)
```

#### Parameters

`__builder` RenderTreeBuilder<br>

### **OnInitializedAsync()**

```csharp
protected Task OnInitializedAsync()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **OnParametersSetAsync()**

```csharp
protected Task OnParametersSetAsync()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
