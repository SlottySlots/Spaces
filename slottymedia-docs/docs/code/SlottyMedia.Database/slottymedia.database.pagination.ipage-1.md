# IPage&lt;T&gt;

Namespace: SlottyMedia.Database.Pagination

This class represents a paginated list.

```csharp
public interface IPage<T> : , System.Collections.IEnumerable
```

#### Type Parameters

`T`<br>
The type of the page's elements

Implements IEnumerable&lt;T&gt;, [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerable)

## Properties

### **PageNumber**

The number of this page. This number is always between
 `0` (inclusive) and [IPage&lt;T&gt;.TotalPages](./slottymedia.database.pagination.ipage-1.md#totalpages) (exclusive).
 This number is always `0` when no pages are available.

```csharp
public abstract int PageNumber { get; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **PageSize**

The size of each page.

```csharp
public abstract int PageSize { get; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **TotalPages**

The total number of pages. This number is at least `0`.

```csharp
public abstract int TotalPages { get; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **HasNext**

Whether there is a page that comes after this page.

```csharp
public bool HasNext { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **HasPrevious**

Whether there is a page that comes before this page.

```csharp
public bool HasPrevious { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Content**

This page's elements as a list.

```csharp
public abstract List<T> Content { get; }
```

#### Property Value

List&lt;T&gt;<br>

## Methods

### **Map&lt;TMapped&gt;(Func&lt;T, TMapped&gt;)**

Maps the content of this page using the supplied function.

```csharp
IPage<TMapped> Map<TMapped>(Func<T, TMapped> function)
```

#### Type Parameters

`TMapped`<br>
The type of the resulting page's contents

#### Parameters

`function` Func&lt;T, TMapped&gt;<br>
The function that maps all contents of this page

#### Returns

IPage&lt;TMapped&gt;<br>
The mapped page

### **Fetch(Int32)**

Fetches a matching page with the specified page number.

```csharp
Task<IPage<T>> Fetch(int pageNumber)
```

#### Parameters

`pageNumber` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The number of the page to fetch

#### Returns

Task&lt;IPage&lt;T&gt;&gt;<br>
The requested page

### **FetchNext()**

Fetches the next page. Returns this page instead if no such page exists.
 Consider checking [IPage&lt;T&gt;.HasNext](./slottymedia.database.pagination.ipage-1.md#hasnext) before invoking this method.

```csharp
Task<IPage<T>> FetchNext()
```

#### Returns

Task&lt;IPage&lt;T&gt;&gt;<br>
The next page

### **FetchPrevious()**

Fetches the previous page. Returns this page instead if no such page exists.
 Consider checking [IPage&lt;T&gt;.HasPrevious](./slottymedia.database.pagination.ipage-1.md#hasprevious) before invoking this method.

```csharp
Task<IPage<T>> FetchPrevious()
```

#### Returns

Task&lt;IPage&lt;T&gt;&gt;<br>
The previous page
