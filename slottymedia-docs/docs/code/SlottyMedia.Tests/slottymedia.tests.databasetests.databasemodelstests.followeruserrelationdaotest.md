# FollowerUserRelationDaoTest

Namespace: SlottyMedia.Tests.DatabaseTests.DatabaseModelsTests

Test class for the FollowerUserRelationDao model.

```csharp
public class FollowerUserRelationDaoTest
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [FollowerUserRelationDaoTest](./slottymedia.tests.databasetests.databasemodelstests.followeruserrelationdaotest.md)

## Constructors

### **FollowerUserRelationDaoTest()**

```csharp
public FollowerUserRelationDaoTest()
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

Setup method to initialize a new FollowerUserRelationDao instance before each test.

```csharp
public void Setup()
```

### **TearDown()**

Tear down method to delete the test relation after each test.

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

Test method to insert a new follower-user relation into the database.

```csharp
public Task Insert()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **Delete()**

Test method to delete an existing follower-user relation from the database.

```csharp
public Task Delete()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetEntityByField()**

Test method to retrieve a follower-user relation by a specific field from the database.

```csharp
public Task GetEntityByField()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
