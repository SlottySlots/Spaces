using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;

namespace SlottyMedia.Database.Repository.SearchRepo;

/// <summary>
///     Interface for the User Search Repository.
/// </summary>
public interface IUserSeachRepository : IDatabaseRepository<UserDao>
{
    /// <summary>
    ///     Gets users by their username with pagination.
    /// </summary>
    /// <param name="userName">The username to search for.</param>
    /// <param name="page">The page number.</param>
    /// <param name="pageSize">The size of the page.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of users.</returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entity is not found in the database.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    /// <exception cref="DatabaseJsonConvertFailed">Thrown when the Database Result was not able to be converted to a Class Dao</exception>
    public Task<List<UserDao>> GetUsersByUserName(string userName);
}