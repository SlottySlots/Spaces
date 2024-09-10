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

[IPostSubmissionFormVm](./slottymedia.backend.viewmodel.partial.mainlayout.ipostsubmissionformvm.md)<br>

### **ValueChanged**

An event that is invoked whenever this input field's value changes

```csharp
public EventCallback<string> ValueChanged { get; set; }
```

#### Property Value

EventCallback&lt;String&gt;<br>

### **UserId**

The Id of the User

```csharp
public Nullable<Guid> UserId { get; set; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

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

Called after the component has been rendered. Fetches user information if it is the first render.

```csharp
protected void OnAfterRender(bool firstRender)
```

#### Parameters

`firstRender` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Indicates whether this is the first render
