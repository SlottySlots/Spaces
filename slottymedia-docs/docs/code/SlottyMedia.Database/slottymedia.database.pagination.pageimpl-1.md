# PageImpl&lt;T&gt;

Namespace: SlottyMedia.Database.Pagination

```csharp
public class PageImpl<T> : IPage`1, , System.Collections.IEnumerable
```

#### Type Parameters

`T`<br>

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PageImpl&lt;T&gt;](./slottymedia.database.pagination.pageimpl-1.md)<br>
Implements IPage&lt;T&gt;, IEnumerable&lt;T&gt;, [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerable)

## Properties

### **Content**

```csharp
public List<T> Content { get; }
```

#### Property Value

List&lt;T&gt;<br>

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

## Constructors

### **PageImpl(List&lt;T&gt;, Int32, Int32, Int32, Func&lt;Int32, Task&lt;IPage&lt;T&gt;&gt;&gt;)**

Creates a page.

```csharp
public PageImpl(List<T> content, int pageNumber, int pageSize, int totalPages, Func<int, Task<IPage<T>>> callback)
```

#### Parameters

`content` List&lt;T&gt;<br>
The page's content

`pageNumber` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The number of this page

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The size of each page

`totalPages` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The number of total pages

`callback` Func&lt;Int32, Task&lt;IPage&lt;T&gt;&gt;&gt;<br>
A calback that is used to fetch a page with a specific number

## Methods

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

```csharp
public Task<IPage<T>> Fetch(int pageNumber)
```

#### Parameters

`pageNumber` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

Task&lt;IPage&lt;T&gt;&gt;<br>

### **GetEnumerator()**

```csharp
public IEnumerator<T> GetEnumerator()
```

#### Returns

IEnumerator&lt;T&gt;<br>

### **Empty()**

Builds an empty page with no content. Throws an [InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) when
 attempting to fetch another page.

```csharp
public static IPage<T> Empty()
```

#### Returns

IPage&lt;T&gt;<br>
The empty page
