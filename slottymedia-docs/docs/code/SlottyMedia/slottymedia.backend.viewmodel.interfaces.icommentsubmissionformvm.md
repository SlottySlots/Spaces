# ICommentSubmissionFormVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

```csharp
public interface ICommentSubmissionFormVm
```

## Properties

### **Text**

The post's textual content

```csharp
public abstract string Text { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **TextErrorMessage**

An optional error message related to the post's textual content

```csharp
public abstract string TextErrorMessage { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ServerErrorMessage**

An optional error message that is caused by some internal server error

```csharp
public abstract string ServerErrorMessage { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Methods

### **SubmitForm(Guid)**

Attempts to submit the form. If successful, the post was created.
 Otherwise, displays an appropriate error message regarding the submission's
 failure.

```csharp
Task SubmitForm(Guid postId)
```

#### Parameters

`postId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The ID of the post to submit the comment for

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
