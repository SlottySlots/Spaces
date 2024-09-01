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

### **Base64Png**

Sets a Base64Png. Gets the currently set base64png variable if set. If not set it gets the path of the standard profile picture.

```csharp
public string Base64Png { private get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **OpensFileDialog**

Flag to mark the avatar as changeable. Hence the onclick event will open a file dialog.

```csharp
public bool OpensFileDialog { get; set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Base64Callback**

Callback triggered whenever a User selects a new file. It invokes the image as base64 encoded string

```csharp
public EventCallback<string> Base64Callback { get; set; }
```

#### Property Value

EventCallback&lt;String&gt;<br>

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
