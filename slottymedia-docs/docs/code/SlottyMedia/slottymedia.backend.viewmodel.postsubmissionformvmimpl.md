# PostSubmissionFormVmImpl

Namespace: SlottyMedia.Backend.ViewModel

```csharp
public class PostSubmissionFormVmImpl : SlottyMedia.Backend.ViewModel.Interfaces.IPostSubmissionFormVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PostSubmissionFormVmImpl](./slottymedia.backend.viewmodel.postsubmissionformvmimpl.md)<br>
Implements [IPostSubmissionFormVm](./slottymedia.backend.viewmodel.interfaces.ipostsubmissionformvm.md)

## Properties

### **Text**

```csharp
public string Text { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **TextErrorMessage**

```csharp
public string TextErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **SpacePrompt**

```csharp
public string SpacePrompt { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **SpaceName**

```csharp
public string SpaceName { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **SpaceErrorMessage**

```csharp
public string SpaceErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ServerErrorMessage**

```csharp
public string ServerErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **PostSubmissionFormVmImpl(IAuthService, IPostService, IForumService, NavigationManager)**

```csharp
public PostSubmissionFormVmImpl(IAuthService authService, IPostService postService, IForumService forumService, NavigationManager navigationManager)
```

#### Parameters

`authService` [IAuthService](./slottymedia.backend.services.interfaces.iauthservice.md)<br>

`postService` [IPostService](./slottymedia.backend.services.interfaces.ipostservice.md)<br>

`forumService` [IForumService](./slottymedia.backend.services.interfaces.iforumservice.md)<br>

`navigationManager` NavigationManager<br>

## Methods

### **HandleSpacePromptChange(ChangeEventArgs, EventCallback&lt;String&gt;)**

```csharp
public Task HandleSpacePromptChange(ChangeEventArgs e, EventCallback<string> promptValueChanged)
```

#### Parameters

`e` ChangeEventArgs<br>

`promptValueChanged` EventCallback&lt;String&gt;<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **HandleSpaceSelection(String)**

```csharp
public Task HandleSpaceSelection(string spaceName)
```

#### Parameters

`spaceName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **HandleSpaceDeselection()**

```csharp
public void HandleSpaceDeselection()
```

### **SubmitForm()**

```csharp
public Task SubmitForm()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
