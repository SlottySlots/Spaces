# ICommentSubmissionFormVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

This ViewModel represents the state of the [CommentSubmissionForm](./slottymedia.components.partial.postpage.commentsubmissionform.md) component.

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

### **UserInformation**

The user information data transfer object to be rendered.

```csharp
public abstract UserInformationDto UserInformation { get; set; }
```

#### Property Value

[UserInformationDto](./slottymedia.backend.dtos.userinformationdto.md)<br>

### **IsLoading**

Gets a value indicating whether the data is still loading.

```csharp
public abstract bool IsLoading { get; set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

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

### **Initialize(Nullable&lt;Guid&gt;)**

Initializes the ViewModel with the specified user ID.

```csharp
Task Initialize(Nullable<Guid> userId)
```

#### Parameters

`userId` [Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The ID of the user to load information for.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task representing the asynchronous operation.
