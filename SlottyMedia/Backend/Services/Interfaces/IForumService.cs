using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.ForumExceptions;
using SlottyMedia.Database.Pagination;

namespace SlottyMedia.Backend.Services.Interfaces;

/// <summary>
///     The IForumService interface is responsible for handling forum related operations.
/// </summary>
public interface IForumService
{
    /// <summary>
    ///     Inserts a new forum into the database.
    /// </summary>
    /// <param name="creatorUserId">The Creator UserID</param>
    /// <param name="forumTopic">The Topic from the Forum</param>
    /// <returns>Returns the inserted ForumDto object.</returns>
    /// <exception cref="ForumIudException">Thrown when an error occurs during Insert, Update, or Delete operations.</exception>
    /// <exception cref="ForumGeneralException">Thrown when a general error occurs.</exception>
    Task InsertForum(Guid creatorUserId, string forumTopic);

    /// <summary>
    ///     Deletes a forum from the database based on the given forum ID.
    /// </summary>
    /// <param name="forum">The forum to delete.</param>
    /// <returns>Returns a Task representing the asynchronous operation.</returns>
    /// <exception cref="ForumIudException">Thrown when an error occurs during Insert, Update, or Delete operations.</exception>
    /// <exception cref="ForumGeneralException">Thrown when a general error occurs.</exception>
    Task DeleteForum(ForumDto forum);

    /// <summary>
    ///     Retrieves a forum with the given name.
    /// </summary>
    /// <param name="forumName">The forum's name.</param>
    /// <returns>The requested forum</returns>
    /// <exception cref="ForumNotFoundException">Thrown when the forum is not found.</exception>
    /// <exception cref="ForumGeneralException">Thrown when a general error occurs.</exception>
    Task<ForumDto> GetForumByName(string forumName);
    
    Task<ForumDto> GetForumById(Guid forumId); 

    Task<IPage<ForumDto>> GetAllForums(PageRequest pageRequest);

    /// <summary>
    ///     Retrieves the 3 most recent forums based on the creation date.
    /// </summary>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a list of the 3 most recent
    ///     ForumDto objects.
    /// </returns>
    /// <exception cref="ForumNotFoundException">Thrown when the forums are not found.</exception>
    /// <exception cref="ForumGeneralException">Thrown when a general error occurs.</exception>
    Task<List<ForumDto>> DetermineRecentSpaces();

    /// <summary>
    ///     Retrieves the top forums.
    /// </summary>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a list of ForumDto objects
    ///     representing the top forums.
    /// </returns>
    /// <exception cref="ForumNotFoundException">Thrown when the forums are not found.</exception>
    /// <exception cref="ForumGeneralException">Thrown when a general error occurs.</exception>
    Task<List<ForumDto>> GetTopForums();
    
}