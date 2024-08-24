# PostDtoTest

Namespace: SlottyMedia.Tests.DatabaseTests.DatabaseModelsTests

Test class for the PostsDao model.

```csharp
public class PostDtoTest : SlottyMedia.Tests.DatabaseTests.BaseDatabaseTestClass
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [BaseDatabaseTestClass](./slottymedia.tests.databasetests.basedatabasetestclass.md) → [PostDtoTest](./slottymedia.tests.databasetests.databasemodelstests.postdtotest.md)

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

The User to work with

```csharp
public UserDao UserToWorkWith { get; set; }
```

#### Property Value

UserDao<br>

## Constructors

### **PostDtoTest()**

```csharp
public PostDtoTest()
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

Setup method to initialize a new PostsDao instance before each test.

```csharp
public void Setup()
```

### **TearDown()**

Tear down method to delete the test post after each test.

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

Test method to insert a new post into the database.

```csharp
public Task Insert()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **Update()**

Test method to update an existing post in the database.

```csharp
public Task Update()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **Delete()**

Test method to delete an existing post from the database.

```csharp
public Task Delete()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **GetEntityByField()**

Test method to retrieve a post by a specific field from the database.

```csharp
public Task GetEntityByField()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
