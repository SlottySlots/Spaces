# IDatabaseRepository&lt;T&gt;

Namespace: SlottyMedia.Database.Repository

This interface defines the contract for a generic database repository.

```csharp
public interface IDatabaseRepository<T>
```

#### Type Parameters

`T`<br>
The type of the entity that the repository will manage.

## Methods

### **GetElementById(Guid)**

Retrieves an element by its unique identifier.

```csharp
Task<T> GetElementById(Guid entityId)
```

#### Parameters

`entityId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The unique identifier of the entity.

#### Returns

Task&lt;T&gt;<br>
A task that represents the asynchronous operation. The task result contains the entity.

#### Exceptions

[DatabaseMissingItemException](./slottymedia.database.exceptions.databasemissingitemexception.md)<br>
Thrown when the entity is not found in the database.

[TableHasNoPrimaryKeyException](./slottymedia.database.exceptions.tablehasnoprimarykeyexception.md)<br>
Thrown when the table has no primary key.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when an unexpected error occurs.

### **GetAllElements()**

Retrieves all elements from the table.

```csharp
Task<List<T>> GetAllElements()
```

#### Returns

Task&lt;List&lt;T&gt;&gt;<br>
A task that represents the asynchronous operation. The task result contains a collection of all entities.

#### Exceptions

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when an unexpected error occurs.

### **GetAllElements(PageRequest)**

Retrieves all elements from the table. Fetches only a specified number of elements
 at the specified page.

```csharp
Task<IPage<T>> GetAllElements(PageRequest pageRequest)
```

#### Parameters

`pageRequest` [PageRequest](./slottymedia.database.pagination.pagerequest.md)<br>
The page request

#### Returns

Task&lt;IPage&lt;T&gt;&gt;<br>
A task that represents the asynchronous operation. The task result contains a collection of all entities.

#### Exceptions

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when an unexpected error occurs.

### **AddElement(T)**

Creates a new element.

```csharp
Task<T> AddElement(T element)
```

#### Parameters

`element` T<br>
The entity to create.

#### Returns

Task&lt;T&gt;<br>
A task that represents the asynchronous operation. The task result contains the created entity.

#### Exceptions

[DatabaseIudActionException](./slottymedia.database.exceptions.databaseiudactionexception.md)<br>
Thrown when an error occurs while inserting the entity.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when an unexpected error occurs.

### **UpdateElement(T)**

Updates an existing element.

```csharp
Task UpdateElement(T element)
```

#### Parameters

`element` T<br>
The entity to update.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task that represents the asynchronous operation. The task result contains the updated entity.

#### Exceptions

[DatabaseIudActionException](./slottymedia.database.exceptions.databaseiudactionexception.md)<br>
Thrown when an error occurs while updating the entity.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when an unexpected error occurs.

### **DeleteElement(T)**

Deletes an element by its object.

```csharp
Task DeleteElement(T entity)
```

#### Parameters

`entity` T<br>
The entity to delete.

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task that represents the asynchronous operation.

#### Exceptions

[DatabaseIudActionException](./slottymedia.database.exceptions.databaseiudactionexception.md)<br>
Thrown when an error occurs while deleting the entity.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when an unexpected error occurs.

### **GetElementByField(String, String)**

Retrieves an element by a specific field.

```csharp
Task<T> GetElementByField(string fieldName, string fieldValue)
```

#### Parameters

`fieldName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the field.

`fieldValue` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The value of the field.

#### Returns

Task&lt;T&gt;<br>
A task that represents the asynchronous operation. The task result contains the entity.

#### Exceptions

[DatabaseMissingItemException](./slottymedia.database.exceptions.databasemissingitemexception.md)<br>
Thrown when the entity is not found in the database.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when an unexpected error occurs.

### **GetElementById(Guid, Expression&lt;Func&lt;T, Object[]&gt;&gt;)**

Retrieves an element by its unique identifier with a specific selector.

```csharp
Task<T> GetElementById(Guid entityId, Expression<Func<T, Object[]>> selector)
```

#### Parameters

`entityId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The unique identifier of the entity.

`selector` Expression&lt;Func&lt;T, Object[]&gt;&gt;<br>
The selector expression.

#### Returns

Task&lt;T&gt;<br>
A task that represents the asynchronous operation. The task result contains the entity.

#### Exceptions

[DatabaseMissingItemException](./slottymedia.database.exceptions.databasemissingitemexception.md)<br>
Thrown when the entity is not found in the database.

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>
Thrown when an unexpected error occurs.
