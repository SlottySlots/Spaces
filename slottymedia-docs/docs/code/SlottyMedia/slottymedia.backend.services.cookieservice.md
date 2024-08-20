# CookieService

Namespace: SlottyMedia.Backend.Services

This class is used to perform JSInterops to perform Read, Write, Exec operations on cookies. It uses the stored
 cookie.js file on client side (found in wwwroot/js)

```csharp
public class CookieService : SlottyMedia.Backend.Services.Interfaces.ICookieService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [CookieService](./slottymedia.backend.services.cookieservice.md)<br>
Implements [ICookieService](./slottymedia.backend.services.interfaces.icookieservice.md)

## Constructors

### **CookieService(IJSRuntime)**

Sets a singleton by using ctor injection

```csharp
public CookieService(IJSRuntime jsRuntime)
```

#### Parameters

`jsRuntime` IJSRuntime<br>

## Methods

### **SetCookie(String, String, Int32)**

Sets a cookie by taking a name, value and a expiration offset

```csharp
public ValueTask SetCookie(string name, string value, int days)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the cookie (key)

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Value of the cookie as string.

`days` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Expiration offset in days.
 Standard value: 7 Days

#### Returns

[ValueTask](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask)<br>
Returns a value task

### **GetCookie(String)**

Gets a cookie by name

```csharp
public ValueTask<string> GetCookie(string name)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the cookie f.e. "supabase.auth.token"

#### Returns

[ValueTask&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1)<br>
Returns a value task of type string =&gt; output is the cookie value

### **RemoveCookie(String)**

Removes a cookie by name

```csharp
public ValueTask<string> RemoveCookie(string name)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Name of the cookie to identify it

#### Returns

[ValueTask&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1)<br>
ValueTask of type string =&gt; output is the cookie value
