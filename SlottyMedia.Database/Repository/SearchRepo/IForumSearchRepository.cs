using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.Database.Pagination;

namespace SlottyMedia.Database.Repository.SearchRepo;

/// <summary>
///     Interface for the Forum Search Repository.
/// </summary>
public interface IForumSearchRepository : IDatabaseRepository<ForumDao>
{
    /// <summary>
    ///     Gets forums by a specific topic with pagination.
    /// </summary>
    /// <param name="topic">The topic to search for.</param>
    /// <param name="pageRequest">The page request</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of forums.</returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entity is not found in the database.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    public Task<IPage<ForumDao>> GetForumsByTopic(string topic, PageRequest pageRequest);
}