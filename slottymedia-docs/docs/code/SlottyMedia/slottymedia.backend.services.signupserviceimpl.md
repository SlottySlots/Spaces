# SignupServiceImpl

Namespace: SlottyMedia.Backend.Services

Service

```csharp
public class SignupServiceImpl : SlottyMedia.Backend.Services.Interfaces.ISignupService
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [SignupServiceImpl](./slottymedia.backend.services.signupserviceimpl.md)<br>
Implements [ISignupService](./slottymedia.backend.services.interfaces.isignupservice.md)

## Constructors

### **SignupServiceImpl(Client, IUserService, ICookieService, IDatabaseActions)**

Standard Constructor for dependency injection

```csharp
public SignupServiceImpl(Client supabaseClient, IUserService userService, ICookieService cookieService, IDatabaseActions databaseActions)
```

#### Parameters

`supabaseClient` Client<br>
Supabase Client used for supabase interactions

`userService` [IUserService](./slottymedia.backend.services.interfaces.iuserservice.md)<br>
User Service used to retrieve dtos

`cookieService` [ICookieService](./slottymedia.backend.services.interfaces.icookieservice.md)<br>
Cookie Service used to set cookies on client side

`databaseActions` IDatabaseActions<br>

## Methods

### **SignUp(String, String, String)**

Function used to sign up a user. This must function be virtual in order to being mocked in unit tests!

```csharp
public Task<Session> SignUp(string username, string email, string password)
```

#### Parameters

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Username for the new user

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Email for the new user

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Password for the new user

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

#### Exceptions

[UsernameAlreadyExistsException](./slottymedia.backend.exceptions.signup.usernamealreadyexistsexception.md)<br>

[InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception)<br>
