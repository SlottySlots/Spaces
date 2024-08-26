using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Helper;
using Supabase.Postgrest;
using Client = Supabase.Client;

namespace SlottyMedia.Database.Repository;

public class ForumSearchRepository : DatabaseRepository<ForumDao>, IForumSearchRepository
{
    /// <summary>
    ///     Base constructor for the <see cref="ForumSearchRepository" />.
    /// </summary>
    /// <param name="client"></param>
    /// <param name="daoHelper"></param>
    /// <param name="databaseRepositroyHelper"></param>
    public ForumSearchRepository(Client client, DaoHelper daoHelper,
        DatabaseRepositroyHelper databaseRepositroyHelper) : base(client, daoHelper, databaseRepositroyHelper)
    {
    }
    
    /// <inheritdoc />
    public async Task<List<ForumDao>> GetForumsByTopic(string topic, int page, int pageSize)
    {
        var query = Supabase
            .From<ForumDao>()
            .Select(x => new object[] { x.ForumTopic! })
            .Filter("forumTopic", Constants.Operator.ILike,  $"%{topic}%")
            .Range((page - 1) * pageSize, (page - 1) * pageSize + pageSize);
        return await ExecuteQuery(query);
    }
}