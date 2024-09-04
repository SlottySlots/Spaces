# DescriptionContainer

Namespace: SlottyMedia.Components.Partial

```csharp
public class DescriptionContainer : Microsoft.AspNetCore.Components.ComponentBase, Microsoft.AspNetCore.Components.IComponent, Microsoft.AspNetCore.Components.IHandleEvent, Microsoft.AspNetCore.Components.IHandleAfterRender
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ComponentBase → [DescriptionContainer](./slottymedia.components.partial.descriptioncontainer.md)<br>
Implements IComponent, IHandleEvent, IHandleAfterRender

## Properties

### **DescriptionText**

The description text to be displayed or edited.

```csharp
public string DescriptionText { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **UserVm**

Service for user-related operations.

```csharp
public IUserVm UserVm { get; private set; }
```

#### Property Value

[IUserVm](./slottymedia.backend.viewmodel.interfaces.iuservm.md)<br>

### **AuthVm**

Service for authentication-related operations.

```csharp
public IAuthVm AuthVm { get; set; }
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
