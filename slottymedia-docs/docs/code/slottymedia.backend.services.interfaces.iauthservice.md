# IAuthService

Namespace: SlottyMedia.Backend.Services.Interfaces

```csharp
public interface IAuthService
```

## Methods

### **SignUp(String, String)**

This method is used to sign up the user.

```csharp
Task<Session> SignUp(string email, string password)
```

#### Parameters

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **SignIn(String, String)**

This method is used to sign in the user.

```csharp
Task<Session> SignIn(string email, string password)
```

#### Parameters

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **SignOut()**

This method is used to sign out the user.

```csharp
Task SignOut()
```

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **RestoreSessionAsync()**

```csharp
Task<Session> RestoreSessionAsync()
```

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **SaveSessionAsync(Session)**

```csharp
Task SaveSessionAsync(Session session)
```

#### Parameters

`session` Session<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **IsAuthenticated()**

This method is used to check if the user is authenticated.

```csharp
bool IsAuthenticated()
```

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **SetSession(String, String)**

```csharp
Task<Session> SetSession(string accessToken, string refreshToken)
```

#### Parameters

`accessToken` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`refreshToken` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **RefreshSession(String, String)**

```csharp
Task<Session> RefreshSession(string accessToken, string refreshToken)
```

#### Parameters

`accessToken` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`refreshToken` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

### **GetCurrentSession()**

```csharp
Session GetCurrentSession()
```

#### Returns

Session<br>
