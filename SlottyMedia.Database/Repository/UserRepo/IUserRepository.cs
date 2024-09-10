using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;

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
    /// <exception cref="DatabaseMissingItemException">Thrown when the entity is not found in the database.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    public Task<UserDao> GetUserByUsername(string username);

    /// <summary>
    ///     Gets a user by their email.
    /// </summary>
    /// <param name="email">The email of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the user.</returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entity is not found in the database.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    public Task<UserDao> GetUserByEmail(string email);
}