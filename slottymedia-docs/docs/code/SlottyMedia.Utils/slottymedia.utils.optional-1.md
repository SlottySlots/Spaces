# Optional&lt;T&gt;

Namespace: SlottyMedia.Utils

A container object which may or may not contain a certain value. If a value is present, IsPresent() will
 return true and Get() will return the value.
 <br><br>
 There are additional utility methods to manipulate the value with respects to its presence. For example,
 OrElseNull() will return null if no value is present and OrElseThrow() throws an exception instead.
 <br><br>
 This class can be instantiated with the static Of() and OfAsync() methods.
 <br><br>NOTE:  This class is intended for reference types only! If used with value types, this class may
 give unexpected results.

```csharp
public class Optional<T>
```

#### Type Parameters

`T`<br>
The type of the optional value. Should be a reference type!

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Optional&lt;T&gt;](./slottymedia.utils.optional-1.md)

## Methods

### **Empty()**

Creates an empty optional value.

```csharp
public static Optional<T> Empty()
```

#### Returns

[Optional&lt;T&gt;](./slottymedia.utils.optional-1.md)<br>
The optional value

### **Of(T)**

Creates an optional value form the given instance.

```csharp
public static Optional<T> Of(T instance)
```

#### Parameters

`instance` T<br>
The value to encapsulate

#### Returns

[Optional&lt;T&gt;](./slottymedia.utils.optional-1.md)<br>
The optional value

### **Of(Func&lt;T&gt;)**

Creates an optional value from the given function.

```csharp
public static Optional<T> Of(Func<T> function)
```

#### Parameters

`function` Func&lt;T&gt;<br>
The function that evaluates the optional value

#### Returns

[Optional&lt;T&gt;](./slottymedia.utils.optional-1.md)<br>
The optional value

### **OfAsync(Func&lt;Task&lt;T&gt;&gt;)**

Creates an optional value from the given asynchronous function.

```csharp
public static Task<Optional<T>> OfAsync(Func<Task<T>> function)
```

#### Parameters

`function` Func&lt;Task&lt;T&gt;&gt;<br>
The function that evaluates the optional value

#### Returns

Task&lt;Optional&lt;T&gt;&gt;<br>
A Task that contains the optional value

### **IsPresent()**

Evaluates whether a value is present.

```csharp
public bool IsPresent()
```

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Whether a value is present

### **Get()**

Retrieves the value contained in this object.

```csharp
public T Get()
```

#### Returns

T<br>
The value

#### Exceptions

[InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception)<br>
If an exception was thrown while evaluating the value

[NullReferenceException](https://docs.microsoft.com/en-us/dotnet/api/system.nullreferenceexception)<br>
If no exception was thrown but no value was present nonetheless

### **OrElse(T)**

Attempts to retrieve the value contained by this object. If no value was present, returns the supplied
 instance instead.

```csharp
public T OrElse(T instance)
```

#### Parameters

`instance` T<br>
The instance to return if this object was empty

#### Returns

T<br>
The value

### **OrElse(Func&lt;T&gt;)**

Attempts to retrieve the value contained by this object. If no value was present, invokes the given
 callback instead and returns its result.

```csharp
public T OrElse(Func<T> function)
```

#### Parameters

`function` Func&lt;T&gt;<br>
A callback that is invoked when no value is present

#### Returns

T<br>
The value

### **OrElse(Func&lt;Exception, T&gt;)**

Attempts to retrieve the value contained by this object. If no value was present, invokes the given
 callback instead and returns its result.

```csharp
public T OrElse(Func<Exception, T> function)
```

#### Parameters

`function` Func&lt;Exception, T&gt;<br>
A callback that is invoked when no value is present.
 Its parameter is an exception that was thrown during the evaluation
 or null if no exception was thrown.

#### Returns

T<br>
The value

### **OrElseAsync(Func&lt;Task&lt;T&gt;&gt;)**

Attempts to retrieve the value contained by this object. If no value was present, asynchronously invokes
 the given callback instead and returns a Task that contains its result.

```csharp
public Task<T> OrElseAsync(Func<Task<T>> function)
```

#### Parameters

`function` Func&lt;Task&lt;T&gt;&gt;<br>
A callback that is invoked when no value is present

#### Returns

Task&lt;T&gt;<br>
The value

### **OrElseAsync(Func&lt;Exception, Task&lt;T&gt;&gt;)**

Attempts to retrieve the value contained by this object. If no value was present, asynchronously invokes the given
 callback instead and returns a Task that contains its result.

```csharp
public Task<T> OrElseAsync(Func<Exception, Task<T>> function)
```

#### Parameters

`function` Func&lt;Exception, Task&lt;T&gt;&gt;<br>
A callback that is invoked when no value is present.
 Its parameter is an exception that was thrown during the evaluation
 or null if no exception was thrown.

#### Returns

Task&lt;T&gt;<br>
The value

### **OrElseNull()**

Attempts to retrieve the value contained by this object. Returns null of no value was present.

```csharp
public T OrElseNull()
```

#### Returns

T<br>
The value or null if not present

### **OrElseThrow()**

Attempts to retrieve the value contained by this object. Throws an exception if no value was present.

```csharp
public T OrElseThrow()
```

#### Returns

T<br>
The value

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>
An inner exception that was raised while evaluating the value

[NullReferenceException](https://docs.microsoft.com/en-us/dotnet/api/system.nullreferenceexception)<br>
If no exception was raised but the value was null nonetheless

### **OrElseThrow(Func&lt;Exception, Exception&gt;)**

Attempts to retrieve the value contained by this object. Throws an exception if no value was present.

```csharp
public T OrElseThrow(Func<Exception, Exception> callback)
```

#### Parameters

`callback` [Func&lt;Exception, Exception&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>
A callback function that is invoked when an exception was raised while evaluating the value.
 The supplied parameter is the exception.

#### Returns

T<br>
The value

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>
An inner exception that was raised while evaluating the value

[NullReferenceException](https://docs.microsoft.com/en-us/dotnet/api/system.nullreferenceexception)<br>
If no exception was raised but the value was null nonetheless
