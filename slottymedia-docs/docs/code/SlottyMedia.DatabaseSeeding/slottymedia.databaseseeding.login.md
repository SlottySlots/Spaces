# Login

Namespace: SlottyMedia.DatabaseSeeding

Login class to handle user login and logout operations for the seeding process.

```csharp
public class Login
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Login](./slottymedia.databaseseeding.login.md)

## Constructors

### **Login()**

```csharp
public Login()
```

## Methods

### **LoginUser(Client)**

Login the user with the given client.

```csharp
public Task LoginUser(Client client)
```

#### Parameters

`client` Client<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>

### **LogoutUser(Client)**

This method logs out the user.

```csharp
public Task LogoutUser(Client client)
```

#### Parameters

`client` Client<br>

#### Returns

[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)<br>
