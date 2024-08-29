# Seeding

Namespace: SlottyMedia.DatabaseSeeding

This class represents the Seeding.

```csharp
public class Seeding
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Seeding](./slottymedia.databaseseeding.seeding.md)

## Constructors

### **Seeding(Client, DaoHelper, DatabaseRepositroyHelper)**

This is the constructor for the Seeding class.

```csharp
public Seeding(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper)
```

#### Parameters

`client` Client<br>

`daoHelper` DaoHelper<br>

`databaseRepositroyHelper` DatabaseRepositroyHelper<br>

## Methods

### **Seed()**

This method seeds the database with random data.

```csharp
public Task Seed()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
