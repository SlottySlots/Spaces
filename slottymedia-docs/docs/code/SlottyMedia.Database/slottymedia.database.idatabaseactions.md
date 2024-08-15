# IDatabaseActions

Namespace: SlottyMedia.Database

Interface for database actions. Provides methods to interact with the database.

```csharp
public interface IDatabaseActions
```

## Methods

### **Insert&lt;T&gt;(T)**

Inserts an item into the database.

```csharp
Task<T> Insert<T>(T item)
```

#### Type Parameters

`T`<br>
The model class of the item.

#### Parameters

`item` T<br>
The item to insert into the database.

#### Returns

Task&lt;T&gt;<br>
Returns the inserted item.

### **Update&lt;T&gt;(T)**

Updates an item in the database.

```csharp
Task<T> Update<T>(T item)
```

#### Type Parameters

`T`<br>
The model class of the item.

#### Parameters

`item` T<br>
The item to update in the database.

#### Returns

Task&lt;T&gt;<br>
Returns the updated item.

### **Delete&lt;T&gt;(T)**

Deletes an item from the database.

```csharp
Task<bool> Delete<T>(T item)
```

#### Type Parameters

`T`<br>
The type of the item object.

#### Parameters

`item` T<br>
The item to delete.

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
Returns true if the operation was successful.

### **GetEntityByField&lt;T&gt;(String, String)**

Returns an entity from the database based on the given field and value.

```csharp
Task<T> GetEntityByField<T>(string field, string value)
```

#### Type Parameters

`T`<br>
The type of the item object.

#### Parameters

`field` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The field to search.

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The value to search for.

#### Returns

Task&lt;T&gt;<br>
Returns the entity from the database.

### **GetEntitieWithSelectorById&lt;T&gt;(Expression&lt;Func&lt;T, Object[]&gt;&gt;, String, String)**

Returns an entity with a selector from the database based on the given field and value.

```csharp
Task<T> GetEntitieWithSelectorById<T>(Expression<Func<T, Object[]>> selector, string field, string value)
```

#### Type Parameters

`T`<br>
The type of the item object.

#### Parameters

`selector` Expression&lt;Func&lt;T, Object[]&gt;&gt;<br>
The selector expression to use.

`field` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The field to search.

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The value to search for.

#### Returns

Task&lt;T&gt;<br>
Returns the entity from the database.

### **GetEntitiesWithSelectorById&lt;T&gt;(Expression&lt;Func&lt;T, Object[]&gt;&gt;, String, String, Int32, Int32, ValueTuple`3[])**

Returns a list of entities with a selector from the database based on the given field and value.

```csharp
Task<List<T>> GetEntitiesWithSelectorById<T>(Expression<Func<T, Object[]>> selector, string field, string value, int max, int min, ValueTuple`3[] orderByFields)
```

#### Type Parameters

`T`<br>
The type of the item object.

#### Parameters

`selector` Expression&lt;Func&lt;T, Object[]&gt;&gt;<br>
The selector expression to use.

`field` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The field to search.

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The value to search for.

`max` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The maximum number of items to retrieve.

`min` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`orderByFields` [ValueTuple`3[]](https://docs.microsoft.com/en-us/dotnet/api/system.valuetuple-3)<br>
The fields to order by.

#### Returns

Task&lt;List&lt;T&gt;&gt;<br>
Returns a list of entities from the database.

### **GetEntitiesWithSelectorById&lt;T&gt;(Expression&lt;Func&lt;T, Object[]&gt;&gt;, List&lt;ValueTuple&lt;String, Operator, String&gt;&gt;, Int32, Int32, ValueTuple`3[])**

```csharp
Task<List<T>> GetEntitiesWithSelectorById<T>(Expression<Func<T, Object[]>> selector, List<ValueTuple<string, Operator, string>> search, int max, int min, ValueTuple`3[] orderByFields)
```

#### Type Parameters

`T`<br>

#### Parameters

`selector` Expression&lt;Func&lt;T, Object[]&gt;&gt;<br>

`search` [List&lt;ValueTuple&lt;String, Operator, String&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

`max` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`min` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`orderByFields` [ValueTuple`3[]](https://docs.microsoft.com/en-us/dotnet/api/system.valuetuple-3)<br>

#### Returns

Task&lt;List&lt;T&gt;&gt;<br>

### **GetEntities&lt;T&gt;()**

```csharp
Task<List<T>> GetEntities<T>()
```

#### Type Parameters

`T`<br>

#### Returns

Task&lt;List&lt;T&gt;&gt;<br>

### **CheckIfEntityExists&lt;T&gt;(String, String)**

```csharp
Task<bool> CheckIfEntityExists<T>(string field, string value)
```

#### Type Parameters

`T`<br>

#### Parameters

`field` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
