# SupabaseRepository&lt;TEntity&gt;

Namespace: SlottyMedia.Backend.Repositories.Impl

This class represents a repository where the managed entity is assignable from the type
 . This repository implements default CRUD methods specifically using
 the Supabase API. This takes away a lot of clutter from implementing repositories.
 The only method that still needs to be implemented is `IRepository::GetById`.
 [IRepository&lt;TEntity&gt;](./slottymedia.backend.repositories.irepository-1.md)

```csharp
public abstract class SupabaseRepository<TEntity> : 
```

#### Type Parameters

`TEntity`<br>
The Supabase entity that should be managed by this repository

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [SupabaseRepository&lt;TEntity&gt;](./slottymedia.backend.repositories.impl.supabaserepository-1.md)<br>
Implements IRepository&lt;TEntity&gt;

## Methods

### **GetById(Guid)**

```csharp
public abstract Task<TEntity> GetById(Guid entityId)
```

#### Parameters

`entityId` [Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

#### Returns

Task&lt;TEntity&gt;<br>

### **GetAll()**

```csharp
public Task<List<TEntity>> GetAll()
```

#### Returns

Task&lt;List&lt;TEntity&gt;&gt;<br>

### **Add(TEntity)**

```csharp
public Task Add(TEntity entity)
```

#### Parameters

`entity` TEntity<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **Update(TEntity)**

```csharp
public Task Update(TEntity entity)
```

#### Parameters

`entity` TEntity<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **Delete(TEntity)**

```csharp
public Task Delete(TEntity entity)
```

#### Parameters

`entity` TEntity<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
