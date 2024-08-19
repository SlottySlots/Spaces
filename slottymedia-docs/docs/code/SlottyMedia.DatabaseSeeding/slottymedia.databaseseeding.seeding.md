# Seeding

Namespace: SlottyMedia.DatabaseSeeding

This class represents the Seeding.

```csharp
public class Seeding
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Seeding](./slottymedia.databaseseeding.seeding.md)

## Constructors

### **Seeding(IDatabaseActions)**

The constructor with parameters.

```csharp
public Seeding(IDatabaseActions databaseActions)
```

#### Parameters

`databaseActions` IDatabaseActions<br>

## Methods

### **Seed()**

This method seeds the database with random data.

```csharp
public Task Seed()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
