using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.Database.Helper;
using Supabase.Postgrest;
using Client = Supabase.Client;

namespace SlottyMedia.Database.Repository.RoleRepo;

/// <summary>
/// This class is used to manage roles in the database.
/// </summary>
public class RoleRepository : DatabaseRepository<RoleDao>, IRoleRepository
{
    /// <summary>
    ///     Base constructor for the <see cref="RoleRepository" />.
    /// </summary>
    /// <param name="client">The Supabase client instance.</param>
    /// <param name="daoHelper">The data access object helper instance.</param>
    /// <param name="databaseRepositroyHelper">The database repository helper instance.</param>
    public RoleRepository(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper) : base(
        client, daoHelper, databaseRepositroyHelper)
    {
    }

    /// <inheritdoc />
    public async Task<Guid> GetRoleIdByName(string roleName)
    {
        var query = BaseQuerry
            .Filter("role_name", Constants.Operator.Equals, roleName)
            .Select(x => new object[] { x.RoleId! });

        var result = await ExecuteSingleQuery(query);

        if (result.RoleId == Guid.Empty) throw new DatabaseMissingItemException("Role not found.");

        return result.RoleId ?? Guid.Empty;
    }
}