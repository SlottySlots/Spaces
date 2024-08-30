# Profile

Namespace: SlottyMedia.Components.Pages

```csharp
public class Profile : Microsoft.AspNetCore.Components.ComponentBase, Microsoft.AspNetCore.Components.IComponent, Microsoft.AspNetCore.Components.IHandleEvent, Microsoft.AspNetCore.Components.IHandleAfterRender
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ComponentBase → [Profile](./slottymedia.components.pages.profile.md)<br>
Implements IComponent, IHandleEvent, IHandleAfterRender

## Properties

### **UserInformationDto**

```csharp
public UserInformationDto UserInformationDto { get; set; }
```

#### Property Value

[UserInformationDto](./slottymedia.backend.dtos.userinformationdto.md)<br>

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

### **OnAfterRender(Boolean)**

```csharp
protected void OnAfterRender(bool firstRender)
```

#### Parameters

`firstRender` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **FollowButtonClicked()**

```csharp
public void FollowButtonClicked()
```
