# Pagination&lt;T&gt;

Namespace: SlottyMedia.Components.Partial

```csharp
public class Pagination<T> : Microsoft.AspNetCore.Components.ComponentBase, Microsoft.AspNetCore.Components.IComponent, Microsoft.AspNetCore.Components.IHandleEvent, Microsoft.AspNetCore.Components.IHandleAfterRender
```

#### Type Parameters

`T`<br>

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ComponentBase → [Pagination&lt;T&gt;](./slottymedia.components.partial.pagination-1.md)<br>
Implements IComponent, IHandleEvent, IHandleAfterRender

## Properties

### **Page**

The paginated list to display.

```csharp
public IPage<T> Page { get; set; }
```

#### Property Value

IPage&lt;T&gt;<br>

### **OnPageFetch**

The event that is triggered when a page is fetched.

```csharp
public EventCallback<int> OnPageFetch { get; set; }
```

#### Property Value

EventCallback&lt;Int32&gt;<br>

### **ChildContent**

The content to display in the paginated list.

```csharp
public RenderFragment ChildContent { get; set; }
```

#### Property Value

RenderFragment<br>

### **Class**

The additional CSS classes to apply to the outer div.

```csharp
public string Class { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **Pagination()**

```csharp
public Pagination()
```

## Methods

### **BuildRenderTree(RenderTreeBuilder)**

```csharp
protected void BuildRenderTree(RenderTreeBuilder __builder)
```

#### Parameters

`__builder` RenderTreeBuilder<br>
