# UserLikePostRelationDaoTest

Namespace: SlottyMedia.Tests.DatabaseTests.DatabaseModelsTests

Test class for the UserLikePostRelationDao model.

```csharp
public class UserLikePostRelationDaoTest
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [UserLikePostRelationDaoTest](./slottymedia.tests.databasetests.databasemodelstests.userlikepostrelationdaotest.md)

## Constructors

### **UserLikePostRelationDaoTest()**

```csharp
public UserLikePostRelationDaoTest()
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

Setup method to initialize a new UserLikePostRelationDao instance before each test.

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

Test method to insert a new user-like-post relation into the database.

```csharp
public Task Insert()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **Delete()**

Test method to delete an existing user-like-post relation from the database.

```csharp
public Task Delete()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetEntityByField()**

Test method to retrieve a user-like-post relation by a specific field from the database.

```csharp
public Task GetEntityByField()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
