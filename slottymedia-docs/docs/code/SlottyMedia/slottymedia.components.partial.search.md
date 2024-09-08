# Search

Namespace: SlottyMedia.Components.Partial

```csharp
public class Search : Microsoft.AspNetCore.Components.LayoutComponentBase, Microsoft.AspNetCore.Components.IComponent, Microsoft.AspNetCore.Components.IHandleEvent, Microsoft.AspNetCore.Components.IHandleAfterRender
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ComponentBase → LayoutComponentBase → [Search](./slottymedia.components.partial.search.md)<br>
Implements IComponent, IHandleEvent, IHandleAfterRender

## Properties

### **MainLayoutVm**

ViewModel to be used in this view

```csharp
public ISearchVm MainLayoutVm { get; set; }
```

#### Property Value

[ISearchVm](./slottymedia.backend.viewmodel.interfaces.isearchvm.md)<br>

### **ValueChanged**

```csharp
public EventCallback<string> ValueChanged { get; set; }
```

#### Property Value

EventCallback&lt;String&gt;<br>

### **Body**

```csharp
public RenderFragment Body { get; set; }
```

#### Property Value

RenderFragment<br>

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
