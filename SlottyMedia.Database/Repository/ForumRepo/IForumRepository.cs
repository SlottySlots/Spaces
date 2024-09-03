using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;

namespace SlottyMedia.Database.Repository.ForumRepo;

/// <summary>
///     Interface for the Forum Repository.
/// </summary>
public interface IForumRepository : IDatabaseRepository<ForumDao>
{
    /// <summary>
    ///     Gets a forum element by its name.
    /// </summary>
    /// <param name="forumName">The name of the forum.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the forum element.</returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entity is not found in the database.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    public Task<ForumDao> GetElementById(string forumName);
}