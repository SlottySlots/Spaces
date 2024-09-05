using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Helper;
using Supabase.Postgrest;
using Client = Supabase.Client;

namespace SlottyMedia.Database.Repository.SearchRepo;

/// <summary>
///     Repository class for managing forum searches in the database.
/// </summary>
public class ForumSearchRepository : DatabaseRepository<ForumDao>, IForumSearchRepository
{
    /// <summary>
    ///     Base constructor for the <see cref="ForumSearchRepository" />.
    /// </summary>
    /// <param name="client">The Supabase client instance.</param>
    /// <param name="daoHelper">The data access object helper instance.</param>
    /// <param name="databaseRepositroyHelper">The database repository helper instance.</param>
    public ForumSearchRepository(Client client, DaoHelper daoHelper,
        DatabaseRepositroyHelper databaseRepositroyHelper) : base(client, daoHelper, databaseRepositroyHelper)
    {
    }

    /// <inheritdoc />
    public async Task<List<ForumDao>> GetForumsByTopic(string topic, int page, int pageSize)
    {
        var query = BaseQuerry
            .Select(x => new object[] { x.ForumTopic! })
            .Filter(forum => forum.ForumTopic!, Constants.Operator.ILike, $"%{topic}%");

        return await ExecuteQuery(ApplyPagination(query, page, pageSize));
    }
}