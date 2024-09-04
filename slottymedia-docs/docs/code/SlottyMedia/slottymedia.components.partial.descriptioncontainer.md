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

### **UserService**

```csharp
public IUserVmImpl UserService { get; private set; }
```

#### Property Value

[IUserVmImpl](./slottymedia.backend.viewmodel.interfaces.iuservmimpl.md)<br>

### **AuthService**

```csharp
public IAuthVm AuthService { get; set; }
```

#### Property Value

[IAuthVm](./slottymedia.backend.viewmodel.interfaces.iauthvm.md)<br>

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
