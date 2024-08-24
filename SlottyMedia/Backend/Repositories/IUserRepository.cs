using SlottyMedia.Database.Daos;

namespace SlottyMedia.Backend.Repositories;


/// <summary>
/// This repository manages all entities of type <see cref="UserDao"/>.
/// </summary>
public interface IUserRepository : IRepository<UserDao>
{
    /// <summary>
    /// Fetches a user by their username. Returns <c>null</c> if such a user was not found
    /// in the database.
    /// </summary>
    /// <param name="username">The user's username</param>
    /// <returns>The user or <c>null</c> if not found</returns>
    /// <exception cref="HttpRequestException">
    /// If an HTTP error occurs while fetching the entity from the database
    /// (except for 404, in which case <c>null</c> is returned)
    /// </exception>
    Task<UserDao?> GetUserByUsername(string username);
}