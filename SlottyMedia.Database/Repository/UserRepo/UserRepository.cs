using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Helper;
using Supabase;

namespace SlottyMedia.Database.Repository.UserRepo;

/// <summary>
///     This class provides methods to interact with the user table.
/// </summary>
public class UserRepository : DatabaseRepository<UserDao>, IUserRepository
{
    /// <summary>
    ///     Base constructor for the <see cref="UserRepository" />.
    /// </summary>
    /// <param name="client"></param>
    /// <param name="daoHelper"></param>
    /// <param name="databaseRepositroyHelper"></param>
    public UserRepository(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper) : base(
        client, daoHelper, databaseRepositroyHelper)
    {
    }

    /// <inheritdoc />
    public async Task<UserDao> GetUserByUsername(string username)
    {
        var query = await base.GetElementByField("userName", username);
        return query;
    }

    /// <inheritdoc />
    public async Task<UserDao> GetUserByEmail(string email)
    {
        var query = await base.GetElementByField("email", email);
        return query;
    }
}