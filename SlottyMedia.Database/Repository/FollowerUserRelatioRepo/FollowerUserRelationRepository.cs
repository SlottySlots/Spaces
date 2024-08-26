using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Helper;
using Supabase.Postgrest;
using Client = Supabase.Client;

namespace SlottyMedia.Database.Repository.FollowerUserRelatioRepo;

/// <summary>
///     Repository class for managing follower-user relations in the database.
/// </summary>
public class FollowerUserRelationRepository : DatabaseRepository<FollowerUserRelationDao>,
    IFollowerUserRelationRepository
{
    /// <summary>
    ///     Base constructor for the <see cref="FollowerUserRelationRepository" />.
    /// </summary>
    /// <param name="client">The Supabase client instance.</param>
    /// <param name="daoHelper">The data access object helper instance.</param>
    /// <param name="databaseRepositroyHelper">The database repository helper instance.</param>
    public FollowerUserRelationRepository(Client client, DaoHelper daoHelper,
        DatabaseRepositroyHelper databaseRepositroyHelper)
        : base(client, daoHelper, databaseRepositroyHelper)
    {
    }

    /// <summary>
    ///     Gets the count of friends for a specific user.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the count of friends.</returns>
    public async Task<int> GetCountOfUserFriends(Guid userId)
    {
        try
        {
            var result = await Supabase
                .From<FollowerUserRelationDao>()
                .Filter("userIsFollowed", Constants.Operator.Equals, userId.ToString())
                .Count(Constants.CountType.Exact);

            return result;
        }
        catch (Exception ex)
        {
            DatabaseRepositroyHelper.HandleException(ex, "FollowerUserRelationRepository.GetCountOfUserFriends");
            return 0;
        }
    }

    /// <summary>
    ///     Retrieves the list of friends for a specific user.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of follower-user relations.</returns>
    public async Task<List<FollowerUserRelationDao>> GetFriends(Guid userId)
    {
        var querry = Supabase
            .From<FollowerUserRelationDao>()
            .Filter("followerUserID", Constants.Operator.Equals, userId.ToString())
            .Select(x => new object[] { x.FollowedUserId! });

        return await ExecuteQuery(querry);
    }
}