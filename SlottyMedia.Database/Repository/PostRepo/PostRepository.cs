using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Helper;
using SlottyMedia.Database.Pagination;
using Supabase.Postgrest;
using Supabase.Postgrest.Interfaces;
using Client = Supabase.Client;

namespace SlottyMedia.Database.Repository.PostRepo;

/// <summary>
///     Repository class for managing posts in the database.
/// </summary>
public class PostRepository : DatabaseRepository<PostsDao>, IPostRepository
{
    /// <summary>
    ///     Base constructor for the <see cref="PostRepository" />.
    /// </summary>
    /// <param name="client">The Supabase client instance.</param>
    /// <param name="daoHelper">The data access object helper instance.</param>
    /// <param name="databaseRepositroyHelper">The database repository helper instance.</param>
    public PostRepository(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper) : base(
        client, daoHelper, databaseRepositroyHelper)
    {
    }

    /// <summary>
    ///     Fetches all posts and orders them by date created in descending order.
    /// </summary>
    /// <returns>The posts in a list</returns>
    public override Task<List<PostsDao>> GetAllElements()
    {
        return ExecuteQuery(BaseSelectQuery());
    }

    /// <summary>
    ///     Fetches all posts and orders them by date created in descending order.
    ///     Only fetches posts on the specified page of the specified size.
    /// </summary>
    /// <param name="pageRequest">The page request</param>
    /// <returns>The page containing the requested posts</returns>
    public override Task<IPage<PostsDao>> GetAllElements(PageRequest pageRequest)
    {
        return ApplyPagination(BaseSelectQuery, pageRequest);
    }

    /// <inheritdoc />
    public async Task<int> GetForumCountByUserId(Guid userId)
    {
        try
        {
            var result = await Supabase.Rpc<int>("get_post_count_by_user",
                new Dictionary<string, object> { { "user_id", userId } });

            return result;
        }
        catch (Exception ex)
        {
            DatabaseRepositroyHelper.HandleException(ex, "GetForumCountByUserId");
            return 0;
        }
    }

    /// <inheritdoc />
    public async Task<int> CountAllPosts()
    {
        return await Supabase
            .From<PostsDao>()
            .Count(Constants.CountType.Exact);
    }

    /// <inheritdoc />
    public async Task<IPage<PostsDao>> GetPostsByUserId(Guid userId, PageRequest pageRequest)
    {
        return await ApplyPagination(
            () => BaseSelectQuery()
                .Filter(posts => posts.UserId!, Constants.Operator.Equals, userId.ToString()),
            pageRequest);
    }

    /// <inheritdoc />
    public async Task<IPage<PostsDao>> GetPostsByUserIdByForumId(Guid userId, Guid forumId, PageRequest pageRequest)
    {
        return await ApplyPagination(
            () =>BaseSelectQuery()
                .Filter(post => post.UserId!, Constants.Operator.Equals, userId.ToString())
                .Filter(post => post.ForumId!, Constants.Operator.Equals, forumId.ToString()),
            pageRequest);
    }

    /// <inheritdoc />
    public async Task<IPage<PostsDao>> GetPostsByForumId(Guid forumId, PageRequest pageRequest)
    {
        return await ApplyPagination(
            () => BaseSelectQuery()
                .Filter(post => post.ForumId!, Constants.Operator.Equals, forumId.ToString()),
            pageRequest);
    }

    private IPostgrestTable<PostsDao> BaseSelectQuery()
    {
        return Supabase
            .From<PostsDao>()
            .Select(x => new object[] { x.PostId!, x.Content!, x.CreatedAt, x.UserId!, x.ForumId! })
            .Order(post => post.CreatedAt, Constants.Ordering.Descending, Constants.NullPosition.Last);
    }
}