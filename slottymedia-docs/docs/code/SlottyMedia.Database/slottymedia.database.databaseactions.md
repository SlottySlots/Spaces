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

```csharp
public Task<T> Insert<T>(T item)
```

#### Type Parameters

`T`<br>

#### Parameters

`item` T<br>

#### Returns

Task&lt;T&gt;<br>

### **Update&lt;T&gt;(T)**

```csharp
public Task<T> Update<T>(T item)
```

#### Type Parameters

`T`<br>

#### Parameters

`item` T<br>

#### Returns

Task&lt;T&gt;<br>

### **Delete&lt;T&gt;(T)**

```csharp
public Task<bool> Delete<T>(T item)
```

#### Type Parameters

`T`<br>

#### Parameters

`item` T<br>

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetEntityByField&lt;T&gt;(String, String)**

```csharp
public Task<T> GetEntityByField<T>(string field, string value)
```

#### Type Parameters

`T`<br>

#### Parameters

`field` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

Task&lt;T&gt;<br>

### **GetEntitieWithSelectorById&lt;T&gt;(Expression&lt;Func&lt;T, Object[]&gt;&gt;, String, String)**

```csharp
public Task<T> GetEntitieWithSelectorById<T>(Expression<Func<T, Object[]>> selector, string field, string value)
```

#### Type Parameters

`T`<br>

#### Parameters

`selector` Expression&lt;Func&lt;T, Object[]&gt;&gt;<br>

`field` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

Task&lt;T&gt;<br>

### **GetEntitiesWithSelectorById&lt;T&gt;(Expression&lt;Func&lt;T, Object[]&gt;&gt;, String, String, Int32, Int32, ValueTuple`3[])**

```csharp
public Task<List<T>> GetEntitiesWithSelectorById<T>(Expression<Func<T, Object[]>> selector, string field, string value, int max, int min, ValueTuple`3[] orderByFields)
```

#### Type Parameters

`T`<br>

#### Parameters

`selector` Expression&lt;Func&lt;T, Object[]&gt;&gt;<br>

`field` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`max` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`min` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`orderByFields` [ValueTuple`3[]](https://docs.microsoft.com/en-us/dotnet/api/system.valuetuple-3)<br>

#### Returns

Task&lt;List&lt;T&gt;&gt;<br>

### **GetEntitiesWithSelectorById&lt;T&gt;(Expression&lt;Func&lt;T, Object[]&gt;&gt;, List&lt;ValueTuple&lt;String, Operator, String&gt;&gt;, Int32, Int32, ValueTuple`3[])**

```csharp
public Task<List<T>> GetEntitiesWithSelectorById<T>(Expression<Func<T, Object[]>> selector, List<ValueTuple<string, Operator, string>> search, int max, int min, ValueTuple`3[] orderByFields)
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
public Task<List<T>> GetEntities<T>()
```

#### Type Parameters

`T`<br>

#### Returns

Task&lt;List&lt;T&gt;&gt;<br>

### **CheckIfEntityExists&lt;T&gt;(String, String)**

```csharp
public Task<bool> CheckIfEntityExists<T>(string field, string value)
```

#### Type Parameters

`T`<br>

#### Parameters

`field` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetCountByField&lt;T&gt;(String, String)**

```csharp
public Task<int> GetCountByField<T>(string field, string value)
```

#### Type Parameters

`T`<br>

#### Parameters

`field` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetCountForUserForums(String)**

```csharp
public Task<int> GetCountForUserForums(string userId)
```

#### Parameters

`userId` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

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
