# DatabaseRepositroyHelper

Namespace: SlottyMedia.Database.Repository

This class provides helper methods for database repositories.

```csharp
public class DatabaseRepositroyHelper
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DatabaseRepositroyHelper](./slottymedia.database.repository.databaserepositroyhelper.md)

## Constructors

### **DatabaseRepositroyHelper()**

```csharp
public DatabaseRepositroyHelper()
```

## Methods

### **HandleException(Exception, String)**

This method handles exceptions that occur during database operations.

```csharp
internal void HandleException(Exception ex, string operation)
```

#### Parameters

`ex` [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>

`operation` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Exceptions

[GeneralDatabaseException](./slottymedia.database.exceptions.generaldatabaseexception.md)<br>

[DatabaseMissingItemException](./slottymedia.database.exceptions.databasemissingitemexception.md)<br>
