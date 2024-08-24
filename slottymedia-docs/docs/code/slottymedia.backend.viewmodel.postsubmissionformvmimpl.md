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

### **ServerErrorMessage**

```csharp
public string ServerErrorMessage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **PostSubmissionFormVmImpl(IAuthService, IPostService, NavigationManager)**

```csharp
public PostSubmissionFormVmImpl(IAuthService authService, IPostService postService, NavigationManager navigationManager)
```

#### Parameters

`authService` [IAuthService](./slottymedia.backend.services.interfaces.iauthservice.md)<br>

`postService` [IPostService](./slottymedia.backend.services.interfaces.ipostservice.md)<br>

`navigationManager` NavigationManager<br>

## Methods

### **SubmitForm()**

```csharp
public Task SubmitForm()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
