using SlottyMedia.Database.Daos;
using Supabase;

namespace SlottyMedia.Database.Repository;

/// <summary>
/// This class provides methods to interact with the user table.
/// </summary>
public class UserRepository : DatabaseRepository<UserDao>, IUserRepository
{
    /// <summary>
    /// Base constructor for the <see cref="UserRepository"/>.
    /// </summary>
    /// <param name="client"></param>
    /// <param name="daoHelper"></param>
    /// <param name="databaseRepositroyHelper"></param>
    public UserRepository(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper) : base(client, daoHelper, databaseRepositroyHelper)
    {
    }
    
    
}