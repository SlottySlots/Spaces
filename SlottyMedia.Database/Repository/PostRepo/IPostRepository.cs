using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;

namespace SlottyMedia.Database.Repository.PostRepo;

/// <summary>
///     Interface for the Post Repository.
/// </summary>
public interface IPostRepository : IDatabaseRepository<PostsDao>
{
    /// <summary>
    ///     Gets the count of forums by a specific user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the count of forums.</returns>
    public Task<int> GetForumCountByUserId(Guid userId);

    /// <summary>
    ///     Gets all elements with pagination.
    /// </summary>
    /// <param name="page">The page number.</param>
    /// <param name="pageSize">The size of the page.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of elements.</returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entity is not found in the database.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    public Task<List<PostsDao>> GetAllElements(int page, int pageSize);

    /// <summary>
    ///     Counts all existing posts.
    /// </summary>
    /// <returns>The total number of existing posts</returns>
    public Task<int> CountAllPosts();

    /// <summary>
    ///     Gets posts by a specific user with pagination.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <param name="page">The page number.</param>
    /// <param name="pageSize">The size of the page.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of posts.</returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entity is not found in the database.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    public Task<List<PostsDao>> GetPostsByUserId(Guid userId, int page, int pageSize);

    /// <summary>
    ///     Gets posts by a specific user and forum with pagination.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <param name="forumId">The unique identifier of the forum.</param>
    /// <param name="page">The page number.</param>
    /// <param name="pageSize">The size of the page.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of posts.</returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entity is not found in the database.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    public Task<List<PostsDao>> GetPostsByUserIdByForumId(Guid userId, Guid forumId, int page, int pageSize);

    /// <summary>
    ///     Gets posts by a specific forum with pagination.
    /// </summary>
    /// <param name="forumId">The unique identifier of the forum.</param>
    /// <param name="page">The page number.</param>
    /// <param name="pageSize">The size of the page.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of posts.</returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entity is not found in the database.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    public Task<List<PostsDao>> GetPostsByForumId(Guid forumId, int page, int pageSize);
}