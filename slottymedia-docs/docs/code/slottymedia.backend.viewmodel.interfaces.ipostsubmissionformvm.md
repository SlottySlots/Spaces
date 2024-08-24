# IPostSubmissionFormVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

This ViewModel represents a form that is used to create a post.
 It contains fields for the post's textual data and fields that
 represent corresponding errors.

```csharp
public interface IPostSubmissionFormVm
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
public abstract string TextErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ServerErrorMessage**

An optional error message that is caused by some internal server error

```csharp
public abstract string ServerErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Methods

### **SubmitForm()**

Attempts to submit the form. If successful, the post was created.
 Otherwise, displays an appropriate error message regarding the submission's
 failure.

```csharp
Task SubmitForm()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
