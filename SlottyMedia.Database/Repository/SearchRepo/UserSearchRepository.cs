using Microsoft.IdentityModel.Tokens;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Helper;
using SlottyMedia.Database.Pagination;
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
    public async Task<IPage<UserDao>> GetUsersByUserName(string userName, PageRequest pageRequest)
    {
        if (userName.IsNullOrEmpty())
            return PageImpl<UserDao>.Empty();
        
        return await ApplyPagination(
            () => Supabase
                .From<UserDao>()
                .Select(x => new object[] { x.UserId!, x.UserName! })
                .Filter(user => user.UserName!, Constants.Operator.ILike, $"%{userName}%"),
            pageRequest);
    }
}