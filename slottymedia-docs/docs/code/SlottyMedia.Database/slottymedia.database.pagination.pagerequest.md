# PageRequest

Namespace: SlottyMedia.Database.Pagination

This class represents a request for a [IPage&lt;T&gt;](./slottymedia.database.pagination.ipage-1.md). It specifies
 the page's size and the current page number. The page is then intended to be
 fetched server-side using this object.

```csharp
public class PageRequest
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PageRequest](./slottymedia.database.pagination.pagerequest.md)

## Fields

### **PageNumber**

The number of the page to request

```csharp
public int PageNumber;
```

### **PageSize**

Each page's size

```csharp
public int PageSize;
```

## Methods

### **Of(Int32, Int32)**

Builds a request consisting of the page's number and size.

```csharp
public static PageRequest Of(int pageNumber, int pageSize)
```

#### Parameters

`pageNumber` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The page's number

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The page's size

#### Returns

[PageRequest](./slottymedia.database.pagination.pagerequest.md)<br>
The corresponding request

### **OfSize(Int32)**

Builds a request consisting of the page's size.

```csharp
public static PageRequest OfSize(int pageSize)
```

#### Parameters

`pageSize` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The page's size

#### Returns

[PageRequest](./slottymedia.database.pagination.pagerequest.md)<br>
The corresponding request

### **First()**

Build a request equivalent to the first page.

```csharp
public PageRequest First()
```

#### Returns

[PageRequest](./slottymedia.database.pagination.pagerequest.md)<br>
The corresponding request

### **Next()**

Build a request equivalent to the next page.

```csharp
public PageRequest Next()
```

#### Returns

[PageRequest](./slottymedia.database.pagination.pagerequest.md)<br>
The corresponding request

### **Previous()**

Build a request equivalent to the previous page.
 Returns this object instead if there is no previous page.

```csharp
public PageRequest Previous()
```

#### Returns

[PageRequest](./slottymedia.database.pagination.pagerequest.md)<br>
The corresponding request
