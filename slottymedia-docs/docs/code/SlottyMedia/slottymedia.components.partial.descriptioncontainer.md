# DescriptionContainer

Namespace: SlottyMedia.Components.Partial

```csharp
public class DescriptionContainer : Microsoft.AspNetCore.Components.ComponentBase, Microsoft.AspNetCore.Components.IComponent, Microsoft.AspNetCore.Components.IHandleEvent, Microsoft.AspNetCore.Components.IHandleAfterRender
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ComponentBase → [DescriptionContainer](./slottymedia.components.partial.descriptioncontainer.md)<br>
Implements IComponent, IHandleEvent, IHandleAfterRender

## Properties

### **DescriptionText**

```csharp
public string DescriptionText { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **DatabaseActions**

```csharp
public IDatabaseActions DatabaseActions { get; private set; }
```

#### Property Value

IDatabaseActions<br>

### **AuthService**

```csharp
public IAuthService AuthService { get; set; }
```

#### Property Value

[IAuthService](./slottymedia.backend.services.interfaces.iauthservice.md)<br>

## Constructors

### **DescriptionContainer()**

```csharp
public DescriptionContainer()
```

## Methods

### **BuildRenderTree(RenderTreeBuilder)**

```csharp
protected void BuildRenderTree(RenderTreeBuilder __builder)
```

#### Parameters

`__builder` RenderTreeBuilder<br>
