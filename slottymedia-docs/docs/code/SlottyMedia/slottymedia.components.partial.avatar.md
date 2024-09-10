# Avatar

Namespace: SlottyMedia.Components.Partial

```csharp
public class Avatar : Microsoft.AspNetCore.Components.ComponentBase, Microsoft.AspNetCore.Components.IComponent, Microsoft.AspNetCore.Components.IHandleEvent, Microsoft.AspNetCore.Components.IHandleAfterRender
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ComponentBase → [Avatar](./slottymedia.components.partial.avatar.md)<br>
Implements IComponent, IHandleEvent, IHandleAfterRender

## Properties

### **ChildContent**

RenderFragment to render a pictogram into the avatar when a action should be done on clicking an avatar.

```csharp
public RenderFragment ChildContent { get; set; }
```

#### Property Value

RenderFragment<br>

### **OnClick**

```csharp
public EventCallback OnClick { get; set; }
```

#### Property Value

EventCallback<br>

### **Class**

Additional CSS classes to add to the avatar's container

```csharp
public string Class { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Base64**

Sets a Base64Png. Gets the currently set base64png variable if set. If not set it gets the path of the standard
 profile picture.

```csharp
public string Base64 { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **Avatar()**

```csharp
public Avatar()
```

## Methods

### **BuildRenderTree(RenderTreeBuilder)**

```csharp
protected void BuildRenderTree(RenderTreeBuilder __builder)
```

#### Parameters

`__builder` RenderTreeBuilder<br>
