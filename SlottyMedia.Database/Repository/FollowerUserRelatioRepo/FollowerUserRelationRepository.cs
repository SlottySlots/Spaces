using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Helper;
using Supabase.Postgrest;
using Client = Supabase.Client;

namespace SlottyMedia.Database.Repository.FollowerUserRelatioRepo;

public class FollowerUserRelationRepository : DatabaseRepository<FollowerUserRelationDao>,
    IFollowerUserRelationRepository
{
    /// <summary>
    ///     Base constructor for the <see cref="FollowerUserRelationRepository" />.
    /// </summary>
    /// <param name="client"></param>
    /// <param name="daoHelper"></param>
    /// <param name="databaseRepositroyHelper"></param>
    public FollowerUserRelationRepository(Client client, DaoHelper daoHelper,
        DatabaseRepositroyHelper databaseRepositroyHelper) : base(client, daoHelper, databaseRepositroyHelper)
    {
    }

    /// <inheritdoc />
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

    /// <inheritdoc />
    public async Task<List<FollowerUserRelationDao>> GetFriends(Guid userId)
    {
        var querry = Supabase
            .From<FollowerUserRelationDao>()
            .Filter("followerUserID", Constants.Operator.Equals, userId.ToString())
            .Select(x => new object[] { x.FollowedUserId! });

        return await ExecuteQuery(querry);
    }
}