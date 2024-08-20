# BaseDatabaseTestClass

Namespace: SlottyMedia.Tests.DatabaseTests

This class is the Base Class for all Database Tests

```csharp
public class BaseDatabaseTestClass
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [BaseDatabaseTestClass](./slottymedia.tests.databasetests.basedatabasetestclass.md)

## Properties

### **UserId**

The UserId of the User

```csharp
public Guid UserId { get; set; }
```

#### Property Value

[Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

### **DatabaseActions**

The DatabaseActions Object

```csharp
public DatabaseActions DatabaseActions { get; set; }
```

#### Property Value

DatabaseActions<br>

### **UserToWorkWith**

```csharp
public UserDao UserToWorkWith { get; set; }
```

#### Property Value

UserDao<br>

## Constructors

### **BaseDatabaseTestClass()**

```csharp
public BaseDatabaseTestClass()
```

## Methods

### **Setup()**

This Method is used to setup the Tests. It logs in the User and sets the UserId Property
 if the Login was successful if not it will signup the User and set the UserId Property

```csharp
public Task Setup()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **TearDown()**

This Method is used to TearDown the Tests. It logs out the User

```csharp
public Task TearDown()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
