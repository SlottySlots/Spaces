# CommentSubmissionForm

Namespace: SlottyMedia.Components.Partial.PostPage

```csharp
public class CommentSubmissionForm : Microsoft.AspNetCore.Components.ComponentBase, Microsoft.AspNetCore.Components.IComponent, Microsoft.AspNetCore.Components.IHandleEvent, Microsoft.AspNetCore.Components.IHandleAfterRender
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ComponentBase → [CommentSubmissionForm](./slottymedia.components.partial.postpage.commentsubmissionform.md)<br>
Implements IComponent, IHandleEvent, IHandleAfterRender

## Properties

### **PostId**

The ID of the post to submit a comment for.

```csharp
public Nullable<Guid> PostId { get; set; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **UserId**

The UserId of the user to submit the comment for.

```csharp
public Nullable<Guid> UserId { get; set; }
```

#### Property Value

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **ViewModel**

The ViewModel for this component.

```csharp
public ICommentSubmissionFormVm ViewModel { get; set; }
```

#### Property Value

[ICommentSubmissionFormVm](./slottymedia.backend.viewmodel.interfaces.icommentsubmissionformvm.md)<br>

## Constructors

### **CommentSubmissionForm()**

```csharp
public CommentSubmissionForm()
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
Indicates whether this is the first render.
