using Newtonsoft.Json;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Helper;
using Supabase.Postgrest;
using Client = Supabase.Client;

namespace SlottyMedia.Database.Repository.ForumRepo;

public class TopForumRepository : DatabaseRepository<TopForumDao>, ITopForumRepository
{
    /// <summary>
    ///     Base constructor for the <see cref="TopForumRepository" />.
    /// </summary>
    /// <param name="client"></param>
    /// <param name="daoHelper"></param>
    /// <param name="databaseRepositroyHelper"></param>
    public TopForumRepository(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper) :
        base(client, daoHelper, databaseRepositroyHelper)
    {
    }

    /// <inheritdoc />
    public async Task<List<TopForumDao>> DetermineRecentSpaces()
    {
        var result = await base.ExecuteFunction("determine_recent_spaces");
        var forums = JsonConvert.DeserializeObject<List<TopForumDao>>(result.ToString());
        return forums;
    }

    /// <inheritdoc />
    public async Task<List<TopForumDao>> GetTopForums()
    {
        var result = await base.ExecuteFunction("get_top_forums");
        var forums = JsonConvert.DeserializeObject<List<TopForumDao>>(result.ToString());
        return forums;
    }
}