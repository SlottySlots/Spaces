# InputArea

Namespace: SlottyMedia.Components.Partial

```csharp
public class InputArea : Microsoft.AspNetCore.Components.ComponentBase, Microsoft.AspNetCore.Components.IComponent, Microsoft.AspNetCore.Components.IHandleEvent, Microsoft.AspNetCore.Components.IHandleAfterRender
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ComponentBase → [InputArea](./slottymedia.components.partial.inputarea.md)<br>
Implements IComponent, IHandleEvent, IHandleAfterRender

## Properties

### **Class**

Additional CSS classes to apply to the textarea component

```csharp
public string Class { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Id**

The input field's ID

```csharp
public string Id { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Name**

The input field's name

```csharp
public string Name { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Placeholder**

```csharp
public string Placeholder { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Type**

```csharp
public string Type { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Value**

```csharp
public string Value { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ValueChanged**

```csharp
public EventCallback<string> ValueChanged { get; set; }
```

#### Property Value

EventCallback&lt;String&gt;<br>

## Constructors

### **InputArea()**

```csharp
public InputArea()
```

## Methods

### **BuildRenderTree(RenderTreeBuilder)**

```csharp
protected void BuildRenderTree(RenderTreeBuilder __builder)
```

#### Parameters

`__builder` RenderTreeBuilder<br>
