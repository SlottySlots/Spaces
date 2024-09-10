# Profile

Namespace: SlottyMedia.Components.Pages

```csharp
public class Profile : Microsoft.AspNetCore.Components.ComponentBase, Microsoft.AspNetCore.Components.IComponent, Microsoft.AspNetCore.Components.IHandleEvent, Microsoft.AspNetCore.Components.IHandleAfterRender
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ComponentBase → [Profile](./slottymedia.components.pages.profile.md)<br>
Implements IComponent, IHandleEvent, IHandleAfterRender

## Properties

### **UserId**

The user id of the profile page

```csharp
public Guid UserId { get; set; }
```

#### Property Value

[Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

## Constructors

### **Profile()**

```csharp
public Profile()
```

## Methods

### **BuildRenderTree(RenderTreeBuilder)**

```csharp
protected void BuildRenderTree(RenderTreeBuilder __builder)
```

#### Parameters

`__builder` RenderTreeBuilder<br>

### **OnParametersSetAsync()**

Called when the component's parameters are set. Initializes the profile page view model with the user ID.

```csharp
protected Task OnParametersSetAsync()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
