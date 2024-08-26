using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Helper;
using Supabase.Postgrest;
using Client = Supabase.Client;

namespace SlottyMedia.Database.Repository.UserLikePostRelationRepo;

public class UserLikePostRelationRepostitory : DatabaseRepository<UserLikePostRelationDao>,
    IUserLikePostRelationRepostitory
{
    /// <summary>
    ///     Base constructor for the <see cref="UserLikePostRelationRepostitory" />.
    /// </summary>
    /// <param name="client"></param>
    /// <param name="daoHelper"></param>
    /// <param name="databaseRepositroyHelper"></param>
    public UserLikePostRelationRepostitory(Client client, DaoHelper daoHelper,
        DatabaseRepositroyHelper databaseRepositroyHelper) : base(client, daoHelper, databaseRepositroyHelper)
    {
    }

    /// <inheritdoc />
    public async Task<List<UserLikePostRelationDao>> GetLikesForPost(Guid userId, Guid postId)
    {
        var likes = Supabase
            .From<UserLikePostRelationDao>()
            .Filter("PostId", Constants.Operator.Equals, postId.ToString())
            .Select(x => new object[] { x.UserId! });
        return
            await ExecuteQuery(likes);
    }
}