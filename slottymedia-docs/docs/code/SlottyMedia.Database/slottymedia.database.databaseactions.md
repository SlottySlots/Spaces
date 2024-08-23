# DatabaseActions

Namespace: SlottyMedia.Database

The DatabaseActions class is responsible for all database actions.

```csharp
public class DatabaseActions : IDatabaseActions
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DatabaseActions](./slottymedia.database.databaseactions.md)<br>
Implements [IDatabaseActions](./slottymedia.database.idatabaseactions.md)

## Constructors

### **DatabaseActions(Client)**

The default constructor.

```csharp
public DatabaseActions(Client supabaseClient)
```

#### Parameters

`supabaseClient` Client<br>

## Methods

### **Insert&lt;T&gt;(T)**

Inserts an item into the database.

```csharp
public Task<T> Insert<T>(T item)
```

#### Type Parameters

`T`<br>
The type of the item to insert.

#### Parameters

`item` T<br>
The item to insert.

#### Returns

Task&lt;T&gt;<br>
The inserted item.

#### Exceptions

[DatabaseIudActionException](./slottymedia.database.exceptions.databaseiudactionexception.md)<br>
Thrown when the item could not be inserted into the database.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when a network error, argument null, invalid operation, timeout, task
 cancellation, or unexpected error occurs.

### **Update&lt;T&gt;(T)**

Updates an item in the database.

```csharp
public Task<T> Update<T>(T item)
```

#### Type Parameters

`T`<br>
The type of the item to update.

#### Parameters

`item` T<br>
The item to update.

#### Returns

Task&lt;T&gt;<br>
The updated item.

#### Exceptions

[DatabaseIudActionException](./slottymedia.database.exceptions.databaseiudactionexception.md)<br>
Thrown when the item could not be updated in the database.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when a network error, argument null, invalid operation, timeout, task
 cancellation, or unexpected error occurs.

### **Delete&lt;T&gt;(T)**

Deletes an item from the database.

```csharp
public Task<bool> Delete<T>(T item)
```

#### Type Parameters

`T`<br>
The type of the item to delete.

#### Parameters

`item` T<br>
The item to delete.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
True if the item was deleted successfully, otherwise false.

#### Exceptions

[DatabaseIudActionException](./slottymedia.database.exceptions.databaseiudactionexception.md)<br>
Thrown when the item could not be deleted from the database.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when a network error, argument null, invalid operation, timeout, task
 cancellation, or unexpected error occurs.

### **GetEntityByField&lt;T&gt;(String, String)**

Retrieves an entity from the database by a specific field and value.

```csharp
public Task<T> GetEntityByField<T>(string field, string value)
```

#### Type Parameters

`T`<br>
The type of the entity to retrieve.

#### Parameters

`field` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The field to filter by.

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The value to filter by.

#### Returns

Task&lt;T&gt;<br>
The retrieved entity.

#### Exceptions

[DatabaseMissingItemException](./slottymedia.database.exceptions.databasemissingitemexception.md)<br>
Thrown when the entity could not be found in the database.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when a network error, argument null, invalid operation, timeout, task
 cancellation, or unexpected error occurs.

### **GetEntitieWithSelectorById&lt;T&gt;(Expression&lt;Func&lt;T, Object[]&gt;&gt;, String, String)**

Retrieves an entity from the database by a specific field and value with a selector.

```csharp
public Task<T> GetEntitieWithSelectorById<T>(Expression<Func<T, Object[]>> selector, string field, string value)
```

#### Type Parameters

`T`<br>
The type of the entity to retrieve.

#### Parameters

`selector` Expression&lt;Func&lt;T, Object[]&gt;&gt;<br>
The selector expression.

`field` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The field to filter by.

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The value to filter by.

#### Returns

Task&lt;T&gt;<br>
The retrieved entity.

#### Exceptions

[DatabaseMissingItemException](./slottymedia.database.exceptions.databasemissingitemexception.md)<br>
Thrown when the entity could not be found in the database.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when a network error, argument null, invalid operation, timeout, task
 cancellation, or unexpected error occurs.

### **GetEntitiesWithSelectorById&lt;T&gt;(Expression&lt;Func&lt;T, Object[]&gt;&gt;, String, String, Int32, Int32, ValueTuple`3[])**

Retrieves a list of entities from the database by a specific field and value with a selector.

```csharp
public Task<List<T>> GetEntitiesWithSelectorById<T>(Expression<Func<T, Object[]>> selector, string field, string value, int max, int min, ValueTuple`3[] orderByFields)
```

#### Type Parameters

`T`<br>
The type of the entities to retrieve.

#### Parameters

`selector` Expression&lt;Func&lt;T, Object[]&gt;&gt;<br>
The selector expression.

`field` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The field to filter by.

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The value to filter by.

`max` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The maximum number of entities to retrieve.

`min` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The minimum number of entities to retrieve.

`orderByFields` [ValueTuple`3[]](https://docs.microsoft.com/en-us/dotnet/api/system.valuetuple-3)<br>
The fields to order by.

#### Returns

Task&lt;List&lt;T&gt;&gt;<br>
The list of retrieved entities.

#### Exceptions

[DatabaseMissingItemException](./slottymedia.database.exceptions.databasemissingitemexception.md)<br>
Thrown when the entities could not be found in the database.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when a network error, argument null, invalid operation, timeout, task
 cancellation, or unexpected error occurs.

### **GetEntitiesWithSelectorById&lt;T&gt;(Expression&lt;Func&lt;T, Object[]&gt;&gt;, List&lt;ValueTuple&lt;String, Operator, String&gt;&gt;, Int32, Int32, ValueTuple`3[])**

Retrieves a list of entities from the database by a specific field and value with a selector and search criteria.

```csharp
public Task<List<T>> GetEntitiesWithSelectorById<T>(Expression<Func<T, Object[]>> selector, List<ValueTuple<string, Operator, string>> search, int max, int min, ValueTuple`3[] orderByFields)
```

#### Type Parameters

`T`<br>
The type of the entities to retrieve.

#### Parameters

`selector` Expression&lt;Func&lt;T, Object[]&gt;&gt;<br>
The selector expression.

`search` [List&lt;ValueTuple&lt;String, Operator, String&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
The search criteria.

`max` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The maximum number of entities to retrieve.

`min` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The minimum number of entities to retrieve.

`orderByFields` [ValueTuple`3[]](https://docs.microsoft.com/en-us/dotnet/api/system.valuetuple-3)<br>
The fields to order by.

#### Returns

Task&lt;List&lt;T&gt;&gt;<br>
The list of retrieved entities.

#### Exceptions

[DatabaseMissingItemException](./slottymedia.database.exceptions.databasemissingitemexception.md)<br>
Thrown when the entities could not be found in the database.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when a network error, argument null, invalid operation, timeout, task
 cancellation, or unexpected error occurs.

### **GetEntities&lt;T&gt;()**

Retrieves a list of entities from the database.

```csharp
public Task<List<T>> GetEntities<T>()
```

#### Type Parameters

`T`<br>
The type of the entities to retrieve.

#### Returns

Task&lt;List&lt;T&gt;&gt;<br>
The list of retrieved entities.

#### Exceptions

[DatabaseMissingItemException](./slottymedia.database.exceptions.databasemissingitemexception.md)<br>
Thrown when the entities could not be found in the database.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when a network error, argument null, invalid operation, timeout, task
 cancellation, or unexpected error occurs.

### **CheckIfEntityExists&lt;T&gt;(String, String)**

The method checks if an entity exists in the database. It returns true if the entity exists, otherwise false.

```csharp
public Task<bool> CheckIfEntityExists<T>(string field, string value)
```

#### Type Parameters

`T`<br>
A Dao

#### Parameters

`field` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The filed to check

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The value to Check

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

#### Exceptions

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>

### **GetCountByField&lt;T&gt;(String, String)**

Retrieves the count of entities from the database by a specific field and value.

```csharp
public Task<int> GetCountByField<T>(string field, string value)
```

#### Type Parameters

`T`<br>
The type of the entities to count.

#### Parameters

`field` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The field to filter by.

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The value to filter by.

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
The count of entities.

#### Exceptions

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when a network error, argument null, invalid operation, timeout, task
 cancellation, or unexpected error occurs.

### **GetCountForUserForums(String)**

```csharp
public Task<int> GetCountForUserForums(string userID)
```

#### Parameters

`userID` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetTotalForumCount(String)**

```csharp
public Task<int> GetTotalForumCount(string forumID)
```

#### Parameters

`forumID` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
