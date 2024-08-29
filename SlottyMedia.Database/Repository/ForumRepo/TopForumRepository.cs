﻿using Newtonsoft.Json;
using SlottyMedia.Database.Daos;
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

    /// <summary>
    ///     Determines the most recent spaces.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of recent top forums.</returns>
    public async Task<List<TopForumDao>> DetermineRecentSpaces()
    {
        var result = await base.ExecuteFunction("determine_recent_spaces");
        var forums = JsonConvert.DeserializeObject<List<TopForumDao>>(result.ToString());
        return forums;
    }

    /// <summary>
    ///     Retrieves the top forums.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of top forums.</returns>
    public async Task<List<TopForumDao>> GetTopForums()
    {
        var result = await base.ExecuteFunction("get_top_forums");
        var forums = JsonConvert.DeserializeObject<List<TopForumDao>>(result.ToString());
        return forums;
    }
}