# CommentSubmissionFormVmImplTests

Namespace: SlottyMedia.Tests.Viewmodel

Unit tests for the CommentSubmissionFormVmImpl class.

```csharp
public class CommentSubmissionFormVmImplTests
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [CommentSubmissionFormVmImplTests](./slottymedia.tests.viewmodel.commentsubmissionformvmimpltests.md)

## Constructors

### **CommentSubmissionFormVmImplTests()**

```csharp
public CommentSubmissionFormVmImplTests()
```

## Methods

### **SetUp()**

Sets up the test environment by initializing mocks and the CommentSubmissionFormVmImpl instance.

```csharp
public void SetUp()
```

### **SubmitForm_SuccessfullySubmitsComment()**

Tests that SubmitForm method successfully submits a comment.

```csharp
public Task SubmitForm_SuccessfullySubmitsComment()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **SubmitForm_DisplaysErrorWhenNotAuthenticated()**

Tests that SubmitForm method displays an error when the user is not authenticated.

```csharp
public Task SubmitForm_DisplaysErrorWhenNotAuthenticated()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **SubmitForm_DisplaysErrorWhenTextIsEmpty()**

Tests that SubmitForm method displays an error when the comment text is empty.

```csharp
public Task SubmitForm_DisplaysErrorWhenTextIsEmpty()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **SubmitForm_DisplaysServerErrorOnException()**

Tests that SubmitForm method displays a server error when an exception is thrown.

```csharp
public Task SubmitForm_DisplaysServerErrorOnException()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
