using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Helper;
using SlottyMedia.Database.Pagination;
using Supabase.Postgrest;
using Client = Supabase.Client;

namespace SlottyMedia.Database.Repository.CommentRepo;

/// <summary>
///     Repository class for managing comments in the database.
/// </summary>
public class CommentRepository : DatabaseRepository<CommentDao>, ICommentRepository
{
    /// <summary>
    ///     Base constructor for the <see cref="CommentRepository" />.
    /// </summary>
    /// <param name="client">The Supabase client instance.</param>
    /// <param name="daoHelper">The data access object helper instance.</param>
    /// <param name="databaseRepositroyHelper">The database repository helper instance.</param>
    public CommentRepository(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper) :
        base(client, daoHelper, databaseRepositroyHelper)
    {
    }

    /// <inheritdoc />
    public async Task<int> CountCommentsInPost(Guid postId)
    {
        var query = Supabase
            .From<CommentDao>()
            .Filter(comment => comment.PostId!, Constants.Operator.Equals, postId.ToString());

        return await ExecuteCountQuery(query, Constants.CountType.Exact);
    }

    /// <inheritdoc />
    public async Task<IPage<CommentDao>> GetCommentsInPost(Guid postId, PageRequest pageRequest)
    {
        return await ApplyPagination(
            () => Supabase
                .From<CommentDao>()
                .Filter(comment => comment.PostId!, Constants.Operator.Equals, postId.ToString())
                .Order(comment => comment.CreatedAt, Constants.Ordering.Descending),
            pageRequest);
    }
}