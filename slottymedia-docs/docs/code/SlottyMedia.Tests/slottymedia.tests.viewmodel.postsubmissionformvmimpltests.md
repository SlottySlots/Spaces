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

### **HandleSpacePromptChange_UpdatesSpacePromptAndSearchedSpaces()**

Tests that HandleSpacePromptChange method updates SpacePrompt and SearchedSpaces properties.

```csharp
public Task HandleSpacePromptChange_UpdatesSpacePromptAndSearchedSpaces()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **HandleSpaceSelection_UpdatesSpaceNameAndClearsSpacePrompt()**

Tests that HandleSpaceSelection method updates SpaceName and clears SpacePrompt.

```csharp
public void HandleSpaceSelection_UpdatesSpaceNameAndClearsSpacePrompt()
```

### **HandleSpaceDeselection_ClearsSpaceName()**

Tests that HandleSpaceDeselection method clears SpaceName.

```csharp
public void HandleSpaceDeselection_ClearsSpaceName()
```

### **SubmitForm_DisplaysErrorWhenUserNotAuthenticated()**

Tests that SubmitForm method displays an error when the user is not authenticated.

```csharp
public Task SubmitForm_DisplaysErrorWhenUserNotAuthenticated()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **SubmitForm_DisplaysErrorWhenTextIsEmpty()**

Tests that SubmitForm method displays an error when the text is empty.

```csharp
public Task SubmitForm_DisplaysErrorWhenTextIsEmpty()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **SubmitForm_DisplaysErrorWhenSpaceNameIsEmpty()**

Tests that SubmitForm method displays an error when the space name is empty.

```csharp
public Task SubmitForm_DisplaysErrorWhenSpaceNameIsEmpty()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **SubmitForm_RedirectsToIndexPageOnSuccess()**

Tests that SubmitForm method redirects to the index page on success.

```csharp
public Task SubmitForm_RedirectsToIndexPageOnSuccess()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **SubmitForm_DisplaysServerErrorMessageOnException()**

Tests that SubmitForm method displays a server error message on exception.

```csharp
public Task SubmitForm_DisplaysServerErrorMessageOnException()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
