# SpacesLayout

Namespace: SlottyMedia.Components.Layout

```csharp
public class SpacesLayout : Microsoft.AspNetCore.Components.LayoutComponentBase, Microsoft.AspNetCore.Components.IComponent, Microsoft.AspNetCore.Components.IHandleEvent, Microsoft.AspNetCore.Components.IHandleAfterRender
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ComponentBase → LayoutComponentBase → [SpacesLayout](./slottymedia.components.layout.spaceslayout.md)<br>
Implements IComponent, IHandleEvent, IHandleAfterRender

## Properties

### **ViewModelSignUp**

ViewModelSignUp to be used on auth

```csharp
public ISignInFormVm ViewModelSignUp { get; set; }
```

#### Property Value

[ISignInFormVm](./slottymedia.backend.viewmodel.interfaces.isigninformvm.md)<br>

### **MainLayoutVm**

ViewModel to be used in this view

```csharp
public IMainLayoutVm MainLayoutVm { get; set; }
```

#### Property Value

[IMainLayoutVm](./slottymedia.backend.viewmodel.interfaces.imainlayoutvm.md)<br>

### **UserInformationDto**

```csharp
public UserInformationDto UserInformationDto { get; set; }
```

#### Property Value

[UserInformationDto](./slottymedia.backend.dtos.userinformationdto.md)<br>

### **Body**

```csharp
public RenderFragment Body { get; set; }
```

#### Property Value

RenderFragment<br>

## Constructors

### **SpacesLayout()**

```csharp
public SpacesLayout()
```

## Methods

### **BuildRenderTree(RenderTreeBuilder)**

```csharp
protected void BuildRenderTree(RenderTreeBuilder __builder)
```

#### Parameters

`__builder` RenderTreeBuilder<br>

### **OnInitializedAsync()**

Refreshes a session

```csharp
protected Task OnInitializedAsync()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **OnAfterRender(Boolean)**

```csharp
protected void OnAfterRender(bool firstRender)
```

#### Parameters

`firstRender` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
