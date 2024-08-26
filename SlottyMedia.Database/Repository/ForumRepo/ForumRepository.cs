using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Helper;
using Client = Supabase.Client;

namespace SlottyMedia.Database.Repository.ForumRepo;

/// <summary>
///     Repository class for managing forums in the database.
/// </summary>
public class ForumRepository : DatabaseRepository<ForumDao>, IForumRepository
{
    /// <summary>
    ///     Base constructor for the <see cref="ForumRepository" />.
    /// </summary>
    /// <param name="client">The Supabase client instance.</param>
    /// <param name="daoHelper">The data access object helper instance.</param>
    /// <param name="databaseRepositroyHelper">The database repository helper instance.</param>
    public ForumRepository(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper) :
        base(client, daoHelper, databaseRepositroyHelper)
    {
    }

    /// <summary>
    ///     Retrieves a forum element by its topic name.
    /// </summary>
    /// <param name="forumName">The name of the forum topic.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the forum data access object.</returns>
    public async Task<ForumDao> GetElementById(string forumName)
    {
        return await base.GetElementByField("forumTopic", forumName);
    }
}