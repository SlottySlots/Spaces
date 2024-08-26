using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Helper;
using Supabase.Postgrest;
using Client = Supabase.Client;

namespace SlottyMedia.Database.Repository;

public class UserSearchRepository : DatabaseRepository<UserDao>, IUserSeachRepository
{
    /// <summary>
    ///     Base constructor for the <see cref="UserSearchRepository" />.
    /// </summary>
    /// <param name="client"></param>
    /// <param name="daoHelper"></param>
    /// <param name="databaseRepositroyHelper"></param>
    public UserSearchRepository(Client client, DaoHelper daoHelper,
        DatabaseRepositroyHelper databaseRepositroyHelper) : base(client, daoHelper, databaseRepositroyHelper)
    {
    }
    
    /// <inheritdoc />
    public async Task<List<UserDao>> GetUsersByUserName(string userName, int page, int pageSize)
    {
        var query = Supabase
            .From<UserDao>()
            .Select(x => new object[] { x.UserId!, x.UserName! })
            .Filter("userName", Constants.Operator.ILike,  $"%{userName}%")
            .Range((page - 1) * pageSize, (page - 1) * pageSize + pageSize);
        return await ExecuteQuery(query);
    }
}