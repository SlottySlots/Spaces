# MainLayout

Namespace: SlottyMedia.Components.Layout

```csharp
public class MainLayout : Microsoft.AspNetCore.Components.LayoutComponentBase, Microsoft.AspNetCore.Components.IComponent, Microsoft.AspNetCore.Components.IHandleEvent, Microsoft.AspNetCore.Components.IHandleAfterRender
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ComponentBase → LayoutComponentBase → [MainLayout](./slottymedia.components.layout.mainlayout.md)<br>
Implements IComponent, IHandleEvent, IHandleAfterRender

## Properties

### **Body**

```csharp
public RenderFragment Body { get; set; }
```

#### Property Value

RenderFragment<br>

## Constructors

### **MainLayout()**

```csharp
public MainLayout()
```

## Methods

### **BuildRenderTree(RenderTreeBuilder)**

```csharp
protected void BuildRenderTree(RenderTreeBuilder __builder)
```

#### Parameters

`__builder` RenderTreeBuilder<br>

### **OnAfterRenderAsync(Boolean)**

```csharp
protected Task OnAfterRenderAsync(bool firstRender)
```

#### Parameters

`firstRender` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
