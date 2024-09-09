# Search

Namespace: SlottyMedia.Components.Partial

```csharp
public class Search : Microsoft.AspNetCore.Components.ComponentBase, Microsoft.AspNetCore.Components.IComponent, Microsoft.AspNetCore.Components.IHandleEvent, Microsoft.AspNetCore.Components.IHandleAfterRender
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ComponentBase → [Search](./slottymedia.components.partial.search.md)<br>
Implements IComponent, IHandleEvent, IHandleAfterRender

## Properties

### **MainLayoutVm**

ViewModel to be used in this view

```csharp
public ISearchVm MainLayoutVm { get; set; }
```

#### Property Value

[ISearchVm](./slottymedia.backend.viewmodel.partial.search.isearchvm.md)<br>

### **ValueChanged**

```csharp
public EventCallback<string> ValueChanged { get; set; }
```

#### Property Value

EventCallback&lt;String&gt;<br>

## Constructors

### **Search()**

```csharp
public Search()
```

## Methods

### **BuildRenderTree(RenderTreeBuilder)**

```csharp
protected void BuildRenderTree(RenderTreeBuilder __builder)
```

#### Parameters

`__builder` RenderTreeBuilder<br>
