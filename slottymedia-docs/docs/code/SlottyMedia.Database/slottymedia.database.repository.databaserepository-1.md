# DatabaseRepository&lt;T&gt;

Namespace: SlottyMedia.Database.Repository

This interface provides the basic CRUD operations for a database repository.

```csharp
public abstract class DatabaseRepository<T> : 
```

#### Type Parameters

`T`<br>

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DatabaseRepository&lt;T&gt;](./slottymedia.database.repository.databaserepository-1.md)<br>
Implements IDatabaseRepository&lt;T&gt;

## Methods

### **ExecuteQuery(IPostgrestTable&lt;T&gt;)**

This method executes a query and returns the result.

```csharp
public Task<List<T>> ExecuteQuery(IPostgrestTable<T> query)
```

#### Parameters

`query` IPostgrestTable&lt;T&gt;<br>

#### Returns

Task&lt;List&lt;T&gt;&gt;<br>

### **GetElementById(Guid)**

```csharp
public Task<T> GetElementById(Guid entityId)
```

#### Parameters

`entityId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

Task&lt;T&gt;<br>

### **GetElementById(Guid, Expression&lt;Func&lt;T, Object[]&gt;&gt;)**

```csharp
public Task<T> GetElementById(Guid entityId, Expression<Func<T, Object[]>> selector)
```

#### Parameters

`entityId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

`selector` Expression&lt;Func&lt;T, Object[]&gt;&gt;<br>

#### Returns

Task&lt;T&gt;<br>

### **GetElementByField(String, String)**

```csharp
public Task<T> GetElementByField(string fieldName, string fieldValue)
```

#### Parameters

`fieldName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`fieldValue` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

Task&lt;T&gt;<br>

### **GetAllElements()**

```csharp
public Task<List<T>> GetAllElements()
```

#### Returns

Task&lt;List&lt;T&gt;&gt;<br>

### **AddElement(T)**

```csharp
public Task AddElement(T entity)
```

#### Parameters

`entity` T<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **UpdateElement(T)**

```csharp
public Task UpdateElement(T entity)
```

#### Parameters

`entity` T<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **DeleteElement(T)**

```csharp
public Task DeleteElement(T entity)
```

#### Parameters

`entity` T<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **ExecuteSingleQuery(IPostgrestTable&lt;T&gt;)**

This method executes a single query and returns the result.

```csharp
public Task<T> ExecuteSingleQuery(IPostgrestTable<T> query)
```

#### Parameters

`query` IPostgrestTable&lt;T&gt;<br>

#### Returns

Task&lt;T&gt;<br>

#### Exceptions

[DatabaseMissingItemException](./slottymedia.database.exceptions.databasemissingitemexception.md)<br>

### **ExecuteFunction(String)**

```csharp
public Task<object> ExecuteFunction(string nameOfFunction)
```

#### Parameters

`nameOfFunction` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **ExecuteFunction(String, Dictionary&lt;String, Object&gt;)**

```csharp
public Task<object> ExecuteFunction(string nameOfFunction, Dictionary<string, object> parameters)
```

#### Parameters

`nameOfFunction` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`parameters` [Dictionary&lt;String, Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2)<br>

#### Returns

[Task&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
