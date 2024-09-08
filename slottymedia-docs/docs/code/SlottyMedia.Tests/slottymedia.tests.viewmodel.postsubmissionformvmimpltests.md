# PostSubmissionFormVmImplTests

Namespace: SlottyMedia.Tests.Viewmodel

Unit tests for the PostSubmissionFormVmImpl class.

```csharp
public class PostSubmissionFormVmImplTests
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PostSubmissionFormVmImplTests](./slottymedia.tests.viewmodel.postsubmissionformvmimpltests.md)

## Constructors

### **PostSubmissionFormVmImplTests()**

```csharp
public PostSubmissionFormVmImplTests()
```

## Methods

### **SetUp()**

Sets up the test environment by initializing mocks and the PostSubmissionFormVmImpl instance.

```csharp
public void SetUp()
```

### **HandleSpacePromptChange_ValidPrompt_UpdatesSearchedSpaces()**

Tests that HandleSpacePromptChange updates the searched spaces when a valid prompt is provided.

```csharp
public Task HandleSpacePromptChange_ValidPrompt_UpdatesSearchedSpaces()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **HandleSpaceSelection_ValidSpaceName_UpdatesSpaceName()**

Tests that HandleSpaceSelection updates the space name when a valid space name is provided.

```csharp
public void HandleSpaceSelection_ValidSpaceName_UpdatesSpaceName()
```

### **HandleSpaceDeselection_ClearsSpaceName()**

Tests that HandleSpaceDeselection clears the space name.

```csharp
public void HandleSpaceDeselection_ClearsSpaceName()
```

### **SubmitForm_UnauthenticatedUser_SetsServerErrorMessage()**

Tests that SubmitForm sets the server error message when the user is unauthenticated.

```csharp
public Task SubmitForm_UnauthenticatedUser_SetsServerErrorMessage()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **SubmitForm_EmptyText_SetsTextErrorMessage()**

Tests that SubmitForm sets the text error message when the text is empty.

```csharp
public Task SubmitForm_EmptyText_SetsTextErrorMessage()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **SubmitForm_EmptySpaceName_SetsSpaceErrorMessage()**

Tests that SubmitForm sets the space error message when the space name is empty.

```csharp
public Task SubmitForm_EmptySpaceName_SetsSpaceErrorMessage()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **SubmitForm_DisplaysServerErrorWhenExceptionOccurs()**

Tests that SubmitForm displays a server error message when an exception occurs.

```csharp
public Task SubmitForm_DisplaysServerErrorWhenExceptionOccurs()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
