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

    /// <summary>
    ///     Gets the likes for a specific post by a specific user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <param name="postId">The unique identifier of the post.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a list of user like post
    ///     relations.
    /// </returns>
    public async Task<List<UserLikePostRelationDao>> GetLikesForPost(Guid userId, Guid postId)
    {
        var likes = BaseQuerry
            .Filter(posts => posts.PostId!, Constants.Operator.Equals, postId.ToString())
            .Select(x => new object[] { x.UserId! });
        return
            await ExecuteQuery(likes);
    }

    public async Task<UserLikePostRelationDao> GetLikeByUserIdAndPostId(Guid userId, Guid postId)
    {
        var userLikeDao = BaseQuerry
            .Filter(post => post.PostId!, Constants.Operator.Equals, postId.ToString())
            .Filter(post => post.PostId!, Constants.Operator.Equals, userId.ToString());
        return await ExecuteSingleQuery(userLikeDao);
    }
}