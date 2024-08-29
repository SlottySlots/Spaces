using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Helper;
using Supabase;

namespace SlottyMedia.Database.Repository.CommentRepo;

/// <summary>
///     Repository class for managing comments in the database.
/// </summary>
public class CommentRepository : DatabaseRepository<CommentDao>, ICommentRepository
{
    /// <summary>
    ///     Base constructor for the <see cref="CommentRepository" />.
    /// </summary>
    /// <param name="client">The Supabase client instance.</param>
    /// <param name="daoHelper">The data access object helper instance.</param>
    /// <param name="databaseRepositroyHelper">The database repository helper instance.</param>
    public CommentRepository(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper) :
        base(client, daoHelper, databaseRepositroyHelper)
    {
    }
}