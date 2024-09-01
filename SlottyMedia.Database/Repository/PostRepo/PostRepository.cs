using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Helper;
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
    public async Task<List<PostsDao>> GetAllElements(int page, int pageSize)
    {
        var query = BaseSelectQuery();

        return await ExecuteQuery(ApplyPagination(query, page, pageSize));
    }

    /// <inheritdoc />
    public async Task<List<PostsDao>> GetPostsByUserId(Guid userId, int page, int pageSize)
    {
        var query = BaseSelectQuery()
            .Filter(posts => posts.UserId!, Constants.Operator.Equals, userId.ToString());

        return await ExecuteQuery(ApplyPagination(query, page, pageSize));
    }

    /// <inheritdoc />
    public async Task<List<PostsDao>> GetPostsByUserIdByForumId(Guid userId, Guid forumId, int page, int pageSize)
    {
        var query = BaseSelectQuery()
            .Filter(post => post.UserId!, Constants.Operator.Equals, userId.ToString())
            .Filter(post => post.ForumId!, Constants.Operator.Equals, forumId.ToString());

        return await ExecuteQuery(ApplyPagination(query, page, pageSize));
    }

    /// <inheritdoc />
    public async Task<List<PostsDao>> GetPostsByForumId(Guid forumId, int page, int pageSize)
    {
        var query = BaseSelectQuery()
            .Filter(post => post.ForumId!, Constants.Operator.Equals, forumId.ToString());

        return await ExecuteQuery(ApplyPagination(query, page, pageSize));
    }

    private IPostgrestTable<PostsDao> BaseSelectQuery()
    {
        return BaseQuerry
            .Select(x => new object[] { x.PostId!, x.Content!, x.CreatedAt, x.UserId!, x.ForumId! })
            .Order(post => post.CreatedAt, Constants.Ordering.Descending, Constants.NullPosition.Last);
    }
}