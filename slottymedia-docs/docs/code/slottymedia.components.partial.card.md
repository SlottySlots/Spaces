# Card

Namespace: SlottyMedia.Components.Partial

```csharp
public class Card : Microsoft.AspNetCore.Components.ComponentBase, Microsoft.AspNetCore.Components.IComponent, Microsoft.AspNetCore.Components.IHandleEvent, Microsoft.AspNetCore.Components.IHandleAfterRender
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ComponentBase → [Card](./slottymedia.components.partial.card.md)<br>
Implements IComponent, IHandleEvent, IHandleAfterRender

## Properties

### **Class**

This component represents a card.

```csharp
public string Class { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ChildContent**

The card's content.

```csharp
public RenderFragment ChildContent { get; set; }
```

#### Property Value

RenderFragment<br>

## Constructors

### **Card()**

```csharp
public Card()
```

## Methods

### **BuildRenderTree(RenderTreeBuilder)**

```csharp
protected void BuildRenderTree(RenderTreeBuilder __builder)
```

#### Parameters

`__builder` RenderTreeBuilder<br>
