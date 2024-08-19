using SlottyMedia.Backend.Dtos;
using SlottyMedia.Database.Exceptions;

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
    /// ///
    /// <param name="forumTopic">The Topic from the Forum</param>
    /// <returns>Returns the inserted ForumDto object.</returns>
    /// <exception cref="GeneralDatabaseException">Throws an exception if an error occurs while inserting the forum.</exception>
    Task<ForumDto> InsertForum(Guid creatorUserId, string forumTopic);

    /// <summary>
    ///     Deletes a forum from the database based on the given forum ID.
    /// </summary>
    /// <param name="forum">The forum to delete.</param>
    /// <returns>Returns a Task representing the asynchronous operation.</returns>
    /// <exception cref="GeneralDatabaseException">Throws an exception if an error occurs while deleting the forum.</exception>
    Task DeleteForum(ForumDto forum);
}