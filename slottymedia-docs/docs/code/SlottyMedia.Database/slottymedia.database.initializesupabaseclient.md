# InitializeSupabaseClient

Namespace: SlottyMedia.Database

This Class is used to Initialize the Supabase Client

```csharp
public static class InitializeSupabaseClient
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [InitializeSupabaseClient](./slottymedia.database.initializesupabaseclient.md)

## Methods

### **GetSupabaseClient()**

This class uses the Environment Variables to Initialize the Supabase Client

```csharp
public static Client GetSupabaseClient()
```

#### Returns

Client<br>

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>
When the Supabase EnvironemtVaraibles are not set, an Exception will be thrown
