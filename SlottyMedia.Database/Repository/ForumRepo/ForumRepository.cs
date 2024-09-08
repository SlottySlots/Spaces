using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Helper;
using Supabase.Postgrest;
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

    /// <inheritdoc />
    public Task<ForumDao> GetForumByName(string name)
    {
        return base.GetElementByField("forumTopic", name);
    }

    /// <inheritdoc />
    public async Task<bool> ExistsByName(string forumName)
    {
        return 0 != await Supabase
            .From<ForumDao>()
            .Filter(forum => forum.ForumTopic!, Constants.Operator.Equals, forumName)
            .Count(Constants.CountType.Exact);
    }
}