using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.Database.Pagination;

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
    /// <param name="pageRequest">The page request</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of users.</returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entity is not found in the database.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    public Task<IPage<UserDao>> GetUsersByUserName(string userName, PageRequest pageRequest);
}