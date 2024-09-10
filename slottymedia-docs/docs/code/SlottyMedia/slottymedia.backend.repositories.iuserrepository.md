# IUserRepository

Namespace: SlottyMedia.Backend.Repositories

This repository manages all entities of type .

```csharp
public interface IUserRepository : IRepository`1
```

Implements [IRepository&lt;UserDao&gt;](./slottymedia.backend.repositories.irepository-1.md)

## Methods

### **GetUserByUsername(String)**

Fetches a user by their username. Returns `null` if such a user was not found
 in the database.

```csharp
Task<UserDao> GetUserByUsername(string username)
```

#### Parameters

`username` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The user's username

#### Returns

[Task&lt;UserDao&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
The user or `null` if not found

#### Exceptions

T:System.Net.Http.HttpRequestException<br>
If an HTTP error occurs while fetching the entity from the database
 (except for 404, in which case `null` is returned)
