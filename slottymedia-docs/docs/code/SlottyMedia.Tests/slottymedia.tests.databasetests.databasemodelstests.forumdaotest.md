# ForumDaoTest

Namespace: SlottyMedia.Tests.DatabaseTests.DatabaseModelsTests

Test class for the ForumDao model.

```csharp
public class ForumDaoTest
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ForumDaoTest](./slottymedia.tests.databasetests.databasemodelstests.forumdaotest.md)

## Constructors

### **ForumDaoTest()**

```csharp
public ForumDaoTest()
```

## Methods

### **OneTimeSetup()**

One-time setup method to initialize Supabase client and insert test data.

```csharp
public Task OneTimeSetup()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **Setup()**

Setup method to initialize a new ForumDao instance before each test.

```csharp
public void Setup()
```

### **TearDown()**

Tear down method to delete the test forum after each test.

```csharp
public Task TearDown()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **OneTimeTearDown()**

One-time tear down method to delete the test data after all tests are run.

```csharp
public Task OneTimeTearDown()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **Insert()**

Test method to insert a new forum into the database.

```csharp
public Task Insert()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **Update()**

Test method to update an existing forum in the database.

```csharp
public Task Update()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **Delete()**

Test method to delete an existing forum from the database.

```csharp
public Task Delete()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetEntityByField()**

Test method to retrieve a forum by a specific field from the database.

```csharp
public Task GetEntityByField()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
