# PageTestImpl&lt;T&gt;

Namespace: SlottyMedia.Tests.TestImpl

This class is a test implementation of .
 It allows to set all fields of a page and does not provide
 any actual functionalities. Use for mocking purposes only!

```csharp
public class PageTestImpl<T> : , , System.Collections.IEnumerable
```

#### Type Parameters

`T`<br>
The type of the page's content

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PageTestImpl&lt;T&gt;](./slottymedia.tests.testimpl.pagetestimpl-1.md)<br>
Implements IPage&lt;T&gt;, IEnumerable&lt;T&gt;, [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerable)

## Properties

### **PageNumber**

```csharp
public int PageNumber { get; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **PageSize**

```csharp
public int PageSize { get; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **TotalPages**

```csharp
public int TotalPages { get; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **Content**

```csharp
public List<T> Content { get; }
```

#### Property Value

List&lt;T&gt;<br>

## Constructors

### **PageTestImpl(List&lt;T&gt;, Int32, Int32, Int32)**

Initializes a new page with the given members.

```csharp
public PageTestImpl(List<T> content, int pageNumber, int pageSize, int totalPages)
```

#### Parameters

`content` List&lt;T&gt;<br>

`pageNumber` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`totalPages` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

## Methods

### **GetEnumerator()**

```csharp
public IEnumerator<T> GetEnumerator()
```

#### Returns

IEnumerator&lt;T&gt;<br>

### **Map&lt;TMapped&gt;(Func&lt;T, TMapped&gt;)**

```csharp
public IPage<TMapped> Map<TMapped>(Func<T, TMapped> function)
```

#### Type Parameters

`TMapped`<br>

#### Parameters

`function` Func&lt;T, TMapped&gt;<br>

#### Returns

IPage&lt;TMapped&gt;<br>

### **Fetch(Int32)**

Simulates fetching some other page, but simply returns this object.

```csharp
public Task<IPage<T>> Fetch(int pageNumber)
```

#### Parameters

`pageNumber` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

Task&lt;IPage&lt;T&gt;&gt;<br>
