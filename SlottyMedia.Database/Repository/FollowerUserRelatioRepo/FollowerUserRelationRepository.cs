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

    /// <inheritdoc />
    public async Task<int> GetCountOfUserFriends(Guid userId)
    {
        try
        {
            var query = Supabase
                .From<FollowerUserRelationDao>()
                .Filter(friends => friends.FollowedUserId!, Constants.Operator.Equals, userId.ToString());

            return await ExecuteCountQuery(query, Constants.CountType.Exact);
        }
        catch (Exception ex)
        {
            DatabaseRepositroyHelper.HandleException(ex, "FollowerUserRelationRepository.GetCountOfUserFriends");
            return 0;
        }
    }

    /// <inheritdoc />
    public async Task<List<FollowerUserRelationDao>> GetFriends(Guid userId)
    {
        var query = Supabase
            .From<FollowerUserRelationDao>()
            .Filter(friend => friend.FollowedUserId!, Constants.Operator.Equals, userId.ToString())
            .Select(x => new object[] { x.FollowedUserId! });

        return await ExecuteQuery(query);
    }

    /// <inheritdoc />
    public async Task<FollowerUserRelationDao> CheckIfUserIsFollowed(Guid userId, Guid followedUserId)
    {
        var query = Supabase
            .From<FollowerUserRelationDao>()
            .Filter(friend => friend.FollowedUserId!, Constants.Operator.Equals, userId.ToString())
            .Filter(friend => friend.FollowerUserId!, Constants.Operator.Equals, followedUserId.ToString());
        return await ExecuteSingleQuery(query);
    }
}