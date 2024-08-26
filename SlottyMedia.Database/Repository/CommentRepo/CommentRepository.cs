using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Helper;
using Supabase;

namespace SlottyMedia.Database.Repository.CommentRepo;

public class CommentRepository : DatabaseRepository<CommentDao>, ICommentRepository
{
    /// <summary>
    ///     Base constructor for the <see cref="CommentRepository" />.
    /// </summary>
    /// <param name="client"></param>
    /// <param name="daoHelper"></param>
    /// <param name="databaseRepositroyHelper"></param>
    public CommentRepository(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper) :
        base(client, daoHelper, databaseRepositroyHelper)
    {
    }
}