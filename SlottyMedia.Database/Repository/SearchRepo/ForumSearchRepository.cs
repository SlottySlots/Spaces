using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
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
    public async Task<List<ForumDao>> GetForumsByTopic(string topic)
    {
        var result =
            await ExecuteFunction("search_forum", new Dictionary<string, object>() { { "search_term", topic } });

        if (result.ToString() is not null && !result.ToString().IsNullOrEmpty())
        {
            var forums = JsonConvert.DeserializeObject<List<ForumDao>>(result.ToString()!);
            if (forums is null)
                throw new DatabaseJsonConvertFailed("Failed to convert the result to a list of top forums.");
            return forums;
        }
        
        return new List<ForumDao>();
    }
}