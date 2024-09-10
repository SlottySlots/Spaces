# AuthService

Namespace: SlottyMedia.Backend.Services

```csharp
public class AuthService : SlottyMedia.Backend.Services.Interfaces.IAuthService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [AuthService](./slottymedia.backend.services.authservice.md)<br>
Implements [IAuthService](./slottymedia.backend.services.interfaces.iauthservice.md)

## Constructors

### **AuthService(Client, ICookieService)**

Initialize scoped service by ctor injection

```csharp
public AuthService(Client supabaseClient, ICookieService cookieService)
```

#### Parameters

`supabaseClient` Client<br>
Injected supabaseClient

`cookieService` [ICookieService](./slottymedia.backend.services.interfaces.icookieservice.md)<br>
Injected cookieService

## Methods

### **SignIn(String, String)**

```csharp
public Task<Session> SignIn(string email, string password)
```

#### Parameters

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **SaveSessionAsync(Session)**

```csharp
public Task SaveSessionAsync(Session session)
```

#### Parameters

`session` Session<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **RestoreSessionAsync()**

```csharp
public Task<Session> RestoreSessionAsync()
```

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **SetSession(String, String)**

```csharp
public Task<Session> SetSession(string accessToken, string refreshToken)
```

#### Parameters

`accessToken` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`refreshToken` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **SignOut()**

```csharp
public Task SignOut()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **RefreshSession(String, String)**

```csharp
public Task<Session> RefreshSession(string accessToken, string refreshToken)
```

#### Parameters

`accessToken` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`refreshToken` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **IsAuthenticated()**

```csharp
public bool IsAuthenticated()
```

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **GetCurrentSession()**

```csharp
public Session GetCurrentSession()
```

#### Returns

Session<br>

### **GetAuthPrincipalId()**

```csharp
public Nullable<Guid> GetAuthPrincipalId()
```

#### Returns

[Nullable&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **RestoreSessionOnInit()**

This restores the session on initialization of the page.

```csharp
public Task<Session> RestoreSessionOnInit()
```

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
