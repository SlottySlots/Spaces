using SlottyMedia.Database.Daos;

namespace SlottyMedia.Database.Repository.UserRepo;

/// <summary>
///     Interface for the User Repository.
/// </summary>
public interface IUserRepository : IDatabaseRepository<UserDao>
{
    /// <summary>
    ///     Gets a user by their username.
    /// </summary>
    /// <param name="username">The username of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the user.</returns>
    public Task<UserDao> GetUserByUsername(string username);

    /// <summary>
    ///     Gets a user by their email.
    /// </summary>
    /// <param name="email">The email of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the user.</returns>
    public Task<UserDao> GetUserByEmail(string email);
}