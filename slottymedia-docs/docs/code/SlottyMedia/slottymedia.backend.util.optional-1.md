# Optional&lt;T&gt;

Namespace: SlottyMedia.Backend.Util

```csharp
public class Optional<T>
```

#### Type Parameters

`T`<br>

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Optional&lt;T&gt;](./slottymedia.backend.util.optional-1.md)

## Methods

### **Of(Func&lt;T&gt;)**

```csharp
public static Optional<T> Of(Func<T> function)
```

#### Parameters

`function` Func&lt;T&gt;<br>

#### Returns

[Optional&lt;T&gt;](./slottymedia.backend.util.optional-1.md)<br>

### **OfAsync(Func&lt;Task&lt;T&gt;&gt;)**

```csharp
public static Task<Optional<T>> OfAsync(Func<Task<T>> function)
```

#### Parameters

`function` Func&lt;Task&lt;T&gt;&gt;<br>

#### Returns

Task&lt;Optional&lt;T&gt;&gt;<br>

### **Get()**

```csharp
public T Get()
```

#### Returns

T<br>

### **OrElse(Func&lt;T&gt;)**

```csharp
public T OrElse(Func<T> function)
```

#### Parameters

`function` Func&lt;T&gt;<br>

#### Returns

T<br>

### **OrElse(Func&lt;T, T&gt;)**

```csharp
public T OrElse(Func<T, T> function)
```

#### Parameters

`function` Func&lt;T, T&gt;<br>

#### Returns

T<br>

### **OrElse(Func&lt;T, Exception, T&gt;)**

```csharp
public T OrElse(Func<T, Exception, T> function)
```

#### Parameters

`function` Func&lt;T, Exception, T&gt;<br>

#### Returns

T<br>

### **OrElseAsync(Func&lt;Task&lt;T&gt;&gt;)**

```csharp
public Task<T> OrElseAsync(Func<Task<T>> function)
```

#### Parameters

`function` Func&lt;Task&lt;T&gt;&gt;<br>

#### Returns

Task&lt;T&gt;<br>

### **OrElseAsync(Func&lt;T, Task&lt;T&gt;&gt;)**

```csharp
public Task<T> OrElseAsync(Func<T, Task<T>> function)
```

#### Parameters

`function` Func&lt;T, Task&lt;T&gt;&gt;<br>

#### Returns

Task&lt;T&gt;<br>

### **OrElseAsync(Func&lt;T, Exception, Task&lt;T&gt;&gt;)**

```csharp
public Task<T> OrElseAsync(Func<T, Exception, Task<T>> function)
```

#### Parameters

`function` Func&lt;T, Exception, Task&lt;T&gt;&gt;<br>

#### Returns

Task&lt;T&gt;<br>

### **OrElseNull()**

```csharp
public T OrElseNull()
```

#### Returns

T<br>

### **OrElseThrow()**

```csharp
public T OrElseThrow()
```

#### Returns

T<br>

### **OrElseThrow(Func&lt;Exception, Exception&gt;)**

```csharp
public T OrElseThrow(Func<Exception, Exception> callback)
```

#### Parameters

`callback` [Func&lt;Exception, Exception&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>

#### Returns

T<br>
