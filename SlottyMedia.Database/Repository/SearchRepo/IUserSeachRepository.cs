using SlottyMedia.Database.Daos;

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
    public Task<List<UserDao>> GetUsersByUserName(string userName, int page, int pageSize);
}