using SlottyMedia.Database.Daos;

namespace SlottyMedia.Backend.Services.Interfaces;

/// <summary>
/// This interface defines the methods which can be used to interact with the User table in the database.
/// </summary>
public interface IUserService
{
    /// <summary>
    ///  This method returns a User object from the database based on the given userId.
    /// </summary>
    /// <param name="userId">The UserID inside the Database</param>
    /// <returns>UserDao</returns>
    Task<UserDao> GetUserById(Guid userId);

    /// <summary>
    /// This method creates a new User object in the database and returns the created object.
    /// </summary>
    /// <param name="userId">The UserID from the Authentication Service</param>
    /// <param name="username">The Username, which the User set himself</param>
    /// <param name="description">The Description about the User</param>
    /// <param name="profilePicture">The ProfilePicture</param>
    /// <returns>UserDao</returns>
    Task<UserDao?> CreateUser(string userId, string username, string? description = null, long? profilePicture = null);

    /// <summary>
    /// This method updates the given User object in the database and returns the updated object.
    /// </summary>
    /// <param name="user">The User object</param>
    /// <returns>UserDao</returns>
    Task<UserDao?> UpdateUser(UserDao user);

    /// <summary>
    /// This method deletes the given User object from the database.
    /// </summary>
    /// <param name="user">The User Object</param>
    /// <returns name="bool">Return if the User got deleted or not</returns>
    Task<bool> DeleteUser(UserDao user);
}