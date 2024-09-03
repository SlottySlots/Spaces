using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Helper;
using Supabase.Postgrest;
using Client = Supabase.Client;

namespace SlottyMedia.Database.Repository.UserLikePostRelationRepo;

/// <summary>
///     Repository class for managing user like post relations in the database.
/// </summary>
public class UserLikePostRelationRepostitory : DatabaseRepository<UserLikePostRelationDao>,
    IUserLikePostRelationRepostitory
{
    /// <summary>
    ///     Base constructor for the <see cref="UserLikePostRelationRepostitory" />.
    /// </summary>
    /// <param name="client">The Supabase client instance.</param>
    /// <param name="daoHelper">The data access object helper instance.</param>
    /// <param name="databaseRepositroyHelper">The database repository helper instance.</param>
    public UserLikePostRelationRepostitory(Client client, DaoHelper daoHelper,
        DatabaseRepositroyHelper databaseRepositroyHelper) : base(client, daoHelper, databaseRepositroyHelper)
    {
    }

    /// <inheritdoc />
    public async Task<List<UserLikePostRelationDao>> GetLikesForPost(Guid postId)
    {
        var likes = BaseQuerry
            .Filter(posts => posts.PostId!, Constants.Operator.Equals, postId.ToString())
            .Select(x => new object[] { x.UserId! });
        return
            await ExecuteQuery(likes);
    }

    /// <inheritdoc />
    public async Task<UserLikePostRelationDao> GetLikeByUserIdAndPostId(Guid userId, Guid postId)
    {
        var userLikeDao = BaseQuerry
            .Filter(post => post.PostId!, Constants.Operator.Equals, postId.ToString())
            .Filter(post => post.UserId!, Constants.Operator.Equals, userId.ToString());
        return await ExecuteSingleQuery(userLikeDao);
    }
}