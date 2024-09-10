using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;

namespace SlottyMedia.Database.Repository.ForumRepo;

/// <summary>
///     Interface for the Top Forum Repository.
/// </summary>
public interface ITopForumRepository : IDatabaseRepository<TopForumDao>
{
    /// <summary>
    ///     Determines the recent spaces.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of recent spaces.</returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entity is not found in the database.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    /// <exception cref="DatabaseJsonConvertFailed">Thrown when the Database Result was not able to be converted to a Class Dao</exception>
    public Task<List<TopForumDao>> DetermineRecentSpaces();

    /// <summary>
    ///     Gets the top forums.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of top forums.</returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entity is not found in the database.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    /// <exception cref="DatabaseJsonConvertFailed">Thrown when the Database Result was not able to be converted to a Class Dao</exception>
    public Task<List<TopForumDao>> GetTopForums();
}