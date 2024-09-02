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
The Supabase client.

`daoHelper` DaoHelper<br>
The DAO helper instance.

`databaseRepositroyHelper` DatabaseRepositroyHelper<br>
The database repository helper instance.

## Methods

### **Seed()**

This method seeds the database with random data.

```csharp
public Task Seed()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

#### Exceptions

T:SlottyMedia.Database.Exceptions.GeneralDatabaseException<br>
Thrown when an unexpected error occurs.

[DatabaseSeedingRepositoryCreationFailed](./slottymedia.database.exceptions.databaseseedingrepositorycreationfailed.md)<br>
Thrown when repository creation fails.

[DatabaseSeedingUserDosentContainProfilePic](./slottymedia.database.exceptions.databaseseedinguserdosentcontainprofilepic.md)<br>
Thrown when a user does not contain a profile pic.

T:SlottyMedia.Database.Exceptions.DatabaseIudActionException<br>
Thrown when an error occurs while deleting the entity.

T:SlottyMedia.Database.Exceptions.DatabaseMissingItemException<br>
Thrown when the entity is not found in the database.
