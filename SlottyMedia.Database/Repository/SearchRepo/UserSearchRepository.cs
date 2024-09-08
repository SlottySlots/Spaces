using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.Database.Helper;
using Supabase.Postgrest;
using Client = Supabase.Client;

namespace SlottyMedia.Database.Repository.SearchRepo;

/// <summary>
///     Repository class for managing user searches in the database.
/// </summary>
public class UserSearchRepository : DatabaseRepository<UserDao>, IUserSeachRepository
{
    /// <summary>
    ///     Base constructor for the <see cref="UserSearchRepository" />.
    /// </summary>
    /// <param name="client">The Supabase client instance.</param>
    /// <param name="daoHelper">The data access object helper instance.</param>
    /// <param name="databaseRepositroyHelper">The database repository helper instance.</param>
    public UserSearchRepository(Client client, DaoHelper daoHelper,
        DatabaseRepositroyHelper databaseRepositroyHelper) : base(client, daoHelper, databaseRepositroyHelper)
    {
    }

    /// <inheritdoc />
    public async Task<List<UserDao>> GetUsersByUserName(string userName)
    {
        var result =
            await ExecuteFunction("search_user", new Dictionary<string, object>() { { "search_term", userName } });

        if (result.ToString() is not null && !result.ToString().IsNullOrEmpty())
        {
            var user = JsonConvert.DeserializeObject<List<UserDao>>(result.ToString()!);
            if (user is null)
                throw new DatabaseJsonConvertFailed("Failed to convert the result to a list of top forums.");
            return user;
        }
        
        return new List<UserDao>();
    }
}