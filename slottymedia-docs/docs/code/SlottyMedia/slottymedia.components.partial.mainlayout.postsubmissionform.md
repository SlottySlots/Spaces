# PostSubmissionForm

Namespace: SlottyMedia.Components.Partial.MainLayout

```csharp
public class PostSubmissionForm : Microsoft.AspNetCore.Components.ComponentBase, Microsoft.AspNetCore.Components.IComponent, Microsoft.AspNetCore.Components.IHandleEvent, Microsoft.AspNetCore.Components.IHandleAfterRender
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ComponentBase → [PostSubmissionForm](./slottymedia.components.partial.mainlayout.postsubmissionform.md)<br>
Implements IComponent, IHandleEvent, IHandleAfterRender

## Properties

### **ViewModel**

The ViewModel for this component

```csharp
public IPostSubmissionFormVm ViewModel { get; set; }
```

#### Property Value

[IPostSubmissionFormVm](./slottymedia.backend.viewmodel.interfaces.ipostsubmissionformvm.md)<br>

### **ValueChanged**

```csharp
public EventCallback<string> ValueChanged { get; set; }
```

#### Property Value

EventCallback&lt;String&gt;<br>

### **UserInformationDto**

```csharp
public UserInformationDto UserInformationDto { get; set; }
```

#### Property Value

[UserInformationDto](./slottymedia.backend.dtos.userinformationdto.md)<br>

## Constructors

### **PostSubmissionForm()**

```csharp
public PostSubmissionForm()
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
