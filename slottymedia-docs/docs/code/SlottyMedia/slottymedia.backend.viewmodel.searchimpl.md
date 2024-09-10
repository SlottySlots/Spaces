# SearchImpl

Namespace: SlottyMedia.Backend.ViewModel

The implementation of the search view model.

```csharp
public class SearchImpl : SlottyMedia.Backend.ViewModel.Interfaces.ISearchVm
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [SearchImpl](./slottymedia.backend.viewmodel.searchimpl.md)<br>
Implements [ISearchVm](./slottymedia.backend.viewmodel.interfaces.isearchvm.md)

## Properties

### **SearchPrompt**

```csharp
public string SearchPrompt { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **SearchResults**

```csharp
public SearchDto SearchResults { get; set; }
```

#### Property Value

[SearchDto](./slottymedia.backend.dtos.searchdto.md)<br>

## Constructors

### **SearchImpl(ISearchService)**

The constructor of the search view model.

```csharp
public SearchImpl(ISearchService searchService)
```

#### Parameters

`searchService` [ISearchService](./slottymedia.backend.services.interfaces.isearchservice.md)<br>

## Methods

### **GetSearchResults(ChangeEventArgs, EventCallback&lt;String&gt;)**

```csharp
public Task GetSearchResults(ChangeEventArgs e, EventCallback<string> promptValueChanged)
```

#### Parameters

`e` ChangeEventArgs<br>

`promptValueChanged` EventCallback&lt;String&gt;<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **ClearSearchResults()**

```csharp
public void ClearSearchResults()
```
