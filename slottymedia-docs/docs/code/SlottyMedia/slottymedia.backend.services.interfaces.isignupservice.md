# ISignupService

Namespace: SlottyMedia.Backend.Services.Interfaces

This service is used for signup operations for new users.

```csharp
public interface ISignupService
```

## Methods

### **SignUp(String, String, String)**

Attempts to perform a signup operation.

```csharp
Task<Session> SignUp(string username, string email, string password)
```

#### Parameters

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The user's username

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The user's email

`password` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The user's password

#### Returns

[Task&lt;Session&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>

#### Exceptions

[UsernameAlreadyExistsException](./slottymedia.backend.exceptions.signup.usernamealreadyexistsexception.md)<br>
If a user with the provided username already exists

[EmailAlreadyExistsException](./slottymedia.backend.exceptions.signup.emailalreadyexistsexception.md)<br>
If a user with the provided email already exists

[IllegalCharsInUsernameException](./slottymedia.backend.exceptions.signup.illegalcharsinusernameexception.md)<br>
If the provided username contains illegal characters

[IllegalUsernameLengthException](./slottymedia.backend.exceptions.signup.illegalusernamelengthexception.md)<br>
If the provided username is of illegal length

[PasswordTooShortException](./slottymedia.backend.exceptions.signup.passwordtooshortexception.md)<br>
If the provided password was too short
