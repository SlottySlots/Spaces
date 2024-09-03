# DatabaseRepository&lt;T&gt;

Namespace: SlottyMedia.Database.Repository

This interface provides the basic CRUD operations for a database repository.

```csharp
public abstract class DatabaseRepository<T> : IDatabaseRepository`1
```

#### Type Parameters

`T`<br>

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DatabaseRepository&lt;T&gt;](./slottymedia.database.repository.databaserepository-1.md)<br>
Implements IDatabaseRepository&lt;T&gt;

## Methods

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
public Task<T> AddElement(T entity)
```

#### Parameters

`entity` T<br>

#### Returns

Task&lt;T&gt;<br>

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

### **ExecuteQuery(IPostgrestTable&lt;T&gt;)**

Executes a query on the specified table.

```csharp
protected Task<List<T>> ExecuteQuery(IPostgrestTable<T> query)
```

#### Parameters

`query` IPostgrestTable&lt;T&gt;<br>
The query to execute.

#### Returns

Task&lt;List&lt;T&gt;&gt;<br>
A task that represents the asynchronous operation. The task result contains a list of entities.

#### Exceptions

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when an unexpected error occurs.

### **ExecuteSingleQuery(IPostgrestTable&lt;T&gt;)**

Executes a single query on the specified table.

```csharp
public Task<T> ExecuteSingleQuery(IPostgrestTable<T> query)
```

#### Parameters

`query` IPostgrestTable&lt;T&gt;<br>
The query to execute.

#### Returns

Task&lt;T&gt;<br>
A task that represents the asynchronous operation. The task result contains a single entity.

#### Exceptions

[DatabaseMissingItemException](./slottymedia.database.exceptions.databasemissingitemexception.md)<br>
Thrown when the entity is not found in the database.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when an unexpected error occurs.

### **ExecuteFunction(String)**

Executes a function on the database.

```csharp
protected Task<object> ExecuteFunction(string nameOfFunction)
```

#### Parameters

`nameOfFunction` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the function to execute.

#### Returns

[Task&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains the result of the function.

#### Exceptions

[DatabaseMissingItemException](./slottymedia.database.exceptions.databasemissingitemexception.md)<br>
Thrown when the items could not be retrieved from the database.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when an unexpected error occurs.

### **ExecuteFunction(String, Dictionary&lt;String, Object&gt;)**

Executes a function on the database with parameters.

```csharp
protected Task<object> ExecuteFunction(string nameOfFunction, Dictionary<string, object> parameters)
```

#### Parameters

`nameOfFunction` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the function to execute.

`parameters` [Dictionary&lt;String, Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2)<br>
The parameters to pass to the function.

#### Returns

[Task&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
A task that represents the asynchronous operation. The task result contains the result of the function.

#### Exceptions

[DatabaseMissingItemException](./slottymedia.database.exceptions.databasemissingitemexception.md)<br>
Thrown when the items could not be retrieved from the database.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when an unexpected error occurs.

### **ApplyPagination(IPostgrestTable&lt;T&gt;, Int32, Int32)**

This method applies pagination to a query.

```csharp
protected IPostgrestTable<T> ApplyPagination(IPostgrestTable<T> query, int page, int pageSize)
```

#### Parameters

`query` IPostgrestTable&lt;T&gt;<br>

`page` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

IPostgrestTable&lt;T&gt;<br>
