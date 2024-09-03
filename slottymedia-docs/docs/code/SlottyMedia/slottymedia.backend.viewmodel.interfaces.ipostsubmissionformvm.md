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

### **SpacePrompt**

The prompt the user should input in order to select the space. This field is null if a space was selected.

```csharp
public abstract string SpacePrompt { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **SpaceName**

The name of the space the user has selected. Null corresponds to no selection.

```csharp
public abstract string SpaceName { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **SearchedSpaces**

A list containing all space names that contain the searched prompt

```csharp
public abstract List<string> SearchedSpaces { get; set; }
```

#### Property Value

[List&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **SpaceErrorMessage**

An optional error message related to the post's space

```csharp
public abstract string SpaceErrorMessage { get; set; }
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

### **HandleSpacePromptChange(ChangeEventArgs, EventCallback&lt;String&gt;)**

Handles an event that is triggered whenever the user changes the prompt to select a space.
 This updates the list of matching spaces in the tooltip above the prompt's input field.

```csharp
Task HandleSpacePromptChange(ChangeEventArgs e, EventCallback<string> promptValueChanged)
```

#### Parameters

`e` ChangeEventArgs<br>
The input field's change event

`promptValueChanged` EventCallback&lt;String&gt;<br>
A callback that is invoked asynchronously

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **HandleSpaceSelection(String)**

Handles an event that is triggered when the user selects a space from the list of available spaces
 based on the entered prompt. This sets "SpacePrompt" to null and "SpaceName" to the selected space name.
 This method assumes that the provided space name is valid and does not check whether the provided space
 actually exists!

```csharp
void HandleSpaceSelection(string spaceName)
```

#### Parameters

`spaceName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the selected space (without hashtag!)

### **HandleSpaceDeselection()**

Handles an event that is triggered when the currently selected space is deselected.
 This sets "SpaceName" to null.

```csharp
void HandleSpaceDeselection()
```

### **SubmitForm()**

Attempts to submit the form. If successful, the post was created.
 Otherwise, displays an appropriate error message regarding the submission's
 failure.

```csharp
Task SubmitForm()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
