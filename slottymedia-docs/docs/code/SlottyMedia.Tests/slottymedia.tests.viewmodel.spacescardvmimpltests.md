# SpacesCardVmImplTests

Namespace: SlottyMedia.Tests.Viewmodel

Tests for the  class.

```csharp
public class SpacesCardVmImplTests
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [SpacesCardVmImplTests](./slottymedia.tests.viewmodel.spacescardvmimpltests.md)

## Constructors

### **SpacesCardVmImplTests()**

```csharp
public SpacesCardVmImplTests()
```

## Methods

### **SetUp()**

Sets up the test environment before each test.
 Initializes the mocks and the view model instance.

```csharp
public void SetUp()
```

### **Fetch_ShouldPopulateTrendingAndRecentSpaces()**

Tests that the Fetch method populates the TrendingSpaces and RecentSpaces properties.

```csharp
public Task Fetch_ShouldPopulateTrendingAndRecentSpaces()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task representing the asynchronous operation.

### **Fetch_ShouldHandleExceptionGracefully()**

Tests that the Fetch method handles exceptions gracefully by ensuring
 the TrendingSpaces and RecentSpaces properties are empty when an exception occurs.

```csharp
public Task Fetch_ShouldHandleExceptionGracefully()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task representing the asynchronous operation.

### **DetermineTrendingSpaces_ShouldPopulateTrendingSpaces()**

Tests that the Fetch method populates the TrendingSpaces property.

```csharp
public Task DetermineTrendingSpaces_ShouldPopulateTrendingSpaces()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task representing the asynchronous operation.

### **DetermineRecentSpaces_ShouldPopulateRecentSpaces()**

Tests that the Fetch method populates the RecentSpaces property.

```csharp
public Task DetermineRecentSpaces_ShouldPopulateRecentSpaces()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
A task representing the asynchronous operation.
