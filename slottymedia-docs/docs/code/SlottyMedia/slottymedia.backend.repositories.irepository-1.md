# IRepository&lt;TEntity&gt;

Namespace: SlottyMedia.Backend.Repositories

This interface represents a repository, which is an intermediary between the application's
 business logic and data storage. It provides consistent functionalities to perform CRUD
 actions on a database while encapsulating the complexities of data access.

```csharp
public interface IRepository<TEntity>
```

#### Type Parameters

`TEntity`<br>
The entity that should be managed by this repository

## Methods

### **GetById(Guid)**

Fetches an entity by their designated primary key. Returns `null` if
 no matching entity was found in the database.

```csharp
Task<TEntity> GetById(Guid entityId)
```

#### Parameters

`entityId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>
The entity's primary key

#### Returns

Task&lt;TEntity&gt;<br>
The corresponding entity or `null` if not found

#### Exceptions

T:System.Net.Http.HttpRequestException<br>
If an HTTP error occurs while fetching the entity from the database
 (except for 404, in which case `null` is returned)

### **GetAll()**

Fetches all entities in the database and collects them in a list.

```csharp
Task<List<TEntity>> GetAll()
```

#### Returns

Task&lt;List&lt;TEntity&gt;&gt;<br>
The entities

#### Exceptions

T:System.Net.Http.HttpRequestException<br>
If an HTTP error occurs while fetching the entities from the database

### **Add(TEntity)**

Inserts an entity into the database.

```csharp
Task Add(TEntity entity)
```

#### Parameters

`entity` TEntity<br>
The entity to insert

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

#### Exceptions

T:System.Net.Http.HttpRequestException<br>
If an HTTP error occurs while inserting the entity into the database

### **Update(TEntity)**

Updates an already existing entity in the database.

```csharp
Task Update(TEntity entity)
```

#### Parameters

`entity` TEntity<br>
The entity to update

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

#### Exceptions

T:System.Net.Http.HttpRequestException<br>
If an HTTP error occurs while updating the entity in the database

### **Delete(TEntity)**

Deletes an entity from the database.

```csharp
Task Delete(TEntity entity)
```

#### Parameters

`entity` TEntity<br>
The entity to delete

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

#### Exceptions

T:System.Net.Http.HttpRequestException<br>
If an HTTP error occurs while deleting the entity from the database
