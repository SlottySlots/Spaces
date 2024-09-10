# ISearchVm

Namespace: SlottyMedia.Backend.ViewModel.Interfaces

This Interface represents the viewmodel of the Search

```csharp
public interface ISearchVm
```

## Properties

### **SearchPrompt**

The prompt the user should input in order to search for a space or user

```csharp
public abstract string SearchPrompt { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **SearchResults**

The search results

```csharp
public abstract SearchDto SearchResults { get; set; }
```

#### Property Value

[SearchDto](./slottymedia.backend.dtos.searchdto.md)<br>

## Methods

### **GetSearchResults(ChangeEventArgs, EventCallback&lt;String&gt;)**

This function searches for spaces or users based on the input of the user

```csharp
Task GetSearchResults(ChangeEventArgs e, EventCallback<string> promptValueChanged)
```

#### Parameters

`e` ChangeEventArgs<br>

`promptValueChanged` EventCallback&lt;String&gt;<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **ClearSearchResults()**

This function clears the search results

```csharp
void ClearSearchResults()
```
