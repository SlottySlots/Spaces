# CommentRepository

Namespace: SlottyMedia.Database.Repository.CommentRepo

Repository class for managing comments in the database.

```csharp
public class CommentRepository : SlottyMedia.Database.Repository.DatabaseRepository`1[[SlottyMedia.Database.Daos.CommentDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], SlottyMedia.Database.IDatabaseRepository`1[[SlottyMedia.Database.Daos.CommentDao, SlottyMedia.Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], ICommentRepository
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DatabaseRepository&lt;CommentDao&gt;](./slottymedia.database.repository.databaserepository-1.md) → [CommentRepository](./slottymedia.database.repository.commentrepo.commentrepository.md)<br>
Implements [IDatabaseRepository&lt;CommentDao&gt;](./slottymedia.database.idatabaserepository-1.md), [ICommentRepository](./slottymedia.database.repository.commentrepo.icommentrepository.md)

## Constructors

### **CommentRepository(Client, DaoHelper, DatabaseRepositroyHelper)**

Base constructor for the [CommentRepository](./slottymedia.database.repository.commentrepo.commentrepository.md).

```csharp
public CommentRepository(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper)
```

#### Parameters

`client` Client<br>
The Supabase client instance.

`daoHelper` [DaoHelper](./slottymedia.database.helper.daohelper.md)<br>
The data access object helper instance.

`databaseRepositroyHelper` [DatabaseRepositroyHelper](./slottymedia.database.helper.databaserepositroyhelper.md)<br>
The database repository helper instance.
