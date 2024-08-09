# Link

Namespace: SlottyMedia.Components.Partial

```csharp
public class Link : Microsoft.AspNetCore.Components.ComponentBase, Microsoft.AspNetCore.Components.IComponent, Microsoft.AspNetCore.Components.IHandleEvent, Microsoft.AspNetCore.Components.IHandleAfterRender
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ComponentBase → [Link](./slottymedia.components.partial.link.md)<br>
Implements IComponent, IHandleEvent, IHandleAfterRender

## Properties

### **To**

Where this link should navigate to. Corresponds to "href".

```csharp
public string To { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Class**

Additional CSS classes to apply to this link.

```csharp
public string Class { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ChildContent**

The link's content, ideally just a string.

```csharp
public RenderFragment ChildContent { get; set; }
```

#### Property Value

RenderFragment<br>

## Constructors

### **Link()**

```csharp
public Link()
```

## Methods

### **BuildRenderTree(RenderTreeBuilder)**

```csharp
protected void BuildRenderTree(RenderTreeBuilder __builder)
```

#### Parameters

`__builder` RenderTreeBuilder<br>
