using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.Database.Helper;
using Client = Supabase.Client;

namespace SlottyMedia.Database.Repository.ForumRepo;

/// <summary>
///     Repository class for managing top forums in the database.
/// </summary>
public class TopForumRepository : DatabaseRepository<TopForumDao>, ITopForumRepository
{
    /// <summary>
    ///     Base constructor for the <see cref="TopForumRepository" />.
    /// </summary>
    /// <param name="client">The Supabase client instance.</param>
    /// <param name="daoHelper">The data access object helper instance.</param>
    /// <param name="databaseRepositroyHelper">The database repository helper instance.</param>
    public TopForumRepository(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper) :
        base(client, daoHelper, databaseRepositroyHelper)
    {
    }

    /// <inheritdoc />
    public async Task<List<TopForumDao>> DetermineRecentSpaces()
    {
        var result = await base.ExecuteFunction("determine_recent_spaces");
        if (result.ToString() is not null && !result.ToString().IsNullOrEmpty())
        {
            var forums = JsonConvert.DeserializeObject<List<TopForumDao>>(result.ToString()!);
            if (forums is null)
                throw new DatabaseJsonConvertFailed("Failed to convert the result to a list of top forums.");
            return forums;
        }

        throw new DatabaseMissingItemException("No recent spaces found.");
    }

/// <inheritdoc />
    public async Task<List<TopForumDao>> GetTopForums()
    {
        var result = await base.ExecuteFunction("get_top_forums");
        if (result.ToString() is not null && !result.ToString().IsNullOrEmpty())
        {
            var forums = JsonConvert.DeserializeObject<List<TopForumDao>>(result.ToString()!);
            if (forums is null)
                throw new DatabaseJsonConvertFailed("Failed to convert the result to a list of top forums.");
            return forums;
        }

        throw new DatabaseMissingItemException("No top forums found.");
    }
}