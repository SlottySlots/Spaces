using Microsoft.IdentityModel.Tokens;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Helper;
using SlottyMedia.Database.Pagination;
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
    public async Task<IPage<ForumDao>> GetForumsByTopic(string topic, PageRequest pageRequest)
    {
        if (topic.IsNullOrEmpty())
            return PageImpl<ForumDao>.Empty();
        
        return await ApplyPagination(
            () => Supabase
                .From<ForumDao>()
                .Select(x => new object[] { x.ForumTopic! })
                .Filter(forum => forum.ForumTopic!, Constants.Operator.ILike, $"%{topic}%"),
            pageRequest);
    }
}