using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Pagination;

namespace SlottyMedia.Database.Repository.CommentRepo;

/// <summary>
///     Interface for the Comment Repository.
/// </summary>
public interface ICommentRepository : IDatabaseRepository<CommentDao>
{
    /// <summary>
    ///     Counts the total number of comments in the given post.
    /// </summary>
    /// <param name="postId">The post to query</param>
    /// <returns>The total number of comments</returns>
    Task<int> CountCommentsInPost(Guid postId);
    
    /// <summary>
    ///     Fetches all comments in the given post. Utilizes pagination in order to limit
    ///     the total number of queried posts: Only posts on the given page will be fetched.
    /// </summary>
    /// <param name="postId">The post whose comments should be fetched</param>
    /// <param name="pageRequest">The page request</param>
    /// <returns>A list containing the queried posts</returns>
    Task<IPage<CommentDao>> GetCommentsInPost(Guid postId, PageRequest pageRequest);
}