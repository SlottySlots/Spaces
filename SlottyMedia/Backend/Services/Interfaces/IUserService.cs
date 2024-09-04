using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.UserExceptions;
using SlottyMedia.Database.Daos;

namespace SlottyMedia.Backend.Services.Interfaces;

/// <summary>
///     This interface defines the methods which can be used to interact with the User table in the database.
/// </summary>
public interface IUserService
{
    /// <summary>
    ///     This method returns a User object from the database based on the given userId.
    /// </summary>
    /// <param name="userId">The UserID inside the Database</param>
    /// <returns>UserDao</returns>
    /// <exception cref="UserNotFoundException">Thrown when the user is not found.</exception>
    /// <exception cref="UserGeneralException">Thrown when a general error occurs.</exception>
    Task<UserDto> GetUserDtoById(Guid userId);

    /// <summary>
    ///     Fetches a user by their username. Returns null if no user was found.
    /// </summary>
    /// <param name="username">The user's username</param>
    /// <returns>The queried user or null if no such user was found</returns>
    /// <exception cref="UserGeneralException">Thrown when a general error occurs.</exception>
    Task<bool> CheckIfUserExistsByUserName(string username);

    /// <summary>
    ///     This method creates a new User object in the database and returns the created object.
    /// </summary>
    /// <param name="userId">The UserID from the Authentication Service</param>
    /// <param name="username">The Username, which the User set himself</param>
    /// <param name="email">The Email of the User</param>
    /// <param name="roleId">The Role ID of the User</param>
    /// <param name="description">The Description about the User</param>
    /// <param name="profilePicture">The ProfilePicture</param>
    /// <returns>UserDto</returns>
    /// <exception cref="UserIudException">Thrown when an error occurs during Insert, Update, or Delete operations.</exception>
    /// <exception cref="UserGeneralException">Thrown when a general error occurs.</exception>
    Task CreateUser(string userId, string username, string email, Guid roleId, string? description = null,
        string? profilePicture = null);

    /// <summary>
    ///     This method updates the given User object in the database and returns the updated object.
    /// </summary>
    /// <param name="user">The User object</param>
    /// <returns>UserDao</returns>
    /// <exception cref="UserIudException">Thrown when an error occurs during Insert, Update, or Delete operations.</exception>
    /// <exception cref="UserGeneralException">Thrown when a general error occurs.</exception>
    Task UpdateUser(UserDao user);

    /// <summary>
    ///     This method deletes the given User object from the database.
    /// </summary>
    /// <param name="user">The User Object</param>
    /// <returns name="bool">Return if the User got deleted or not</returns>
    /// <exception cref="UserIudException">Thrown when an error occurs during Insert, Update, or Delete operations.</exception>
    /// <exception cref="UserGeneralException">Thrown when a general error occurs.</exception>
    Task DeleteUser(UserDto user);

    /// <summary>
    ///     This method returns the Profile Picture of the given User.
    /// </summary>
    /// <param name="userId">The ID of the User</param>
    /// <returns>Returns the Profile Picture of the User</returns>
    /// <exception cref="UserNotFoundException">Thrown when the user is not found.</exception>
    /// <exception cref="UserGeneralException">Thrown when a general error occurs.</exception>
    Task<ProfilePicDto> GetProfilePic(Guid userId);

    /// <summary>
    ///     This method returns a UserDto object from the database based on the given userId.
    /// </summary>
    /// <param name="userId">The Id of the user</param>
    /// <param name="limit">The maximum number of recent forums to retrieve</param>
    /// <returns>Returns the UserDto object</returns>
    /// <exception cref="UserNotFoundException">Thrown when the user is not found.</exception>
    /// <exception cref="UserGeneralException">Thrown when a general error occurs.</exception>
    Task<UserDto> GetUser(Guid userId, int limit = 5);

    /// <summary>
    ///     This method returns a list of friends for the given user.
    /// </summary>
    /// <param name="userId">The ID of the user</param>
    /// <returns>Returns a FriendsOfUserDto object containing the list of friends</returns>
    /// <exception cref="UserNotFoundException">Thrown when the user is not found.</exception>
    /// <exception cref="UserGeneralException">Thrown when a general error occurs.</exception>
    Task<FriendsOfUserDto> GetFriends(Guid userId);

    /// <summary>
    ///     This method retrieves the count of friends for a given user from the database.
    /// </summary>
    /// <param name="userId">The ID of the user whose friends count is to be retrieved.</param>
    /// <returns>Returns the count of friends for the specified user.</returns>
    /// <exception cref="UserGeneralException">
    ///     Thrown when a general database error occurs while fetching the friends count.
    /// </exception>
    Task<int> GetCountOfUserFriends(Guid userId);

    /// <summary>
    ///     Gets all spaces a user has wrote in
    /// </summary>
    /// <param name="userId">
    ///     User from which it should be retrieved
    /// </param>
    /// <returns>
    ///     Returns the amount of spaces as task
    /// </returns>
    /// <exception cref="UserGeneralException">Thrown when a general error occurs.</exception>
    Task<int> GetCountOfUserSpaces(Guid userId);

    /// <summary>
    ///     Updates the given UserDto object in the database and returns the updated object.
    /// </summary>
    /// <param name="user">The UserDto object to be updated.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated UserDto object.</returns>
    /// <exception cref="UserIudException">Thrown when an error occurs during Insert, Update, or Delete operations.</exception>
    /// <exception cref="UserGeneralException">Thrown when a general error occurs.</exception>
    Task UpdateUser(UserDto user);

    /// <summary>
    ///     Checks whether a user follows another user based on their ids
    /// </summary>
    /// <param name="userIdToCheck">
    ///     UserId to check
    /// </param>
    /// <param name="userIdLoggedIn">
    ///     UserId that may follow the one to check
    /// </param>
    /// <returns>
    ///     Boolean representing the state
    /// </returns>
    /// <exception cref="UserGeneralException">Thrown when a general error occurs.</exception>
    Task<bool> UserFollowRelation(Guid userIdToCheck, Guid userIdLoggedIn);

    /// <summary>
    ///     Gets a user dao based on the user id
    /// </summary>
    /// <param name="userId">
    ///     Id to retrieve
    /// </param>
    /// <returns>
    ///     Returns a user dao
    /// </returns>
    /// <exception cref="UserNotFoundException">Thrown when the user is not found.</exception>
    /// <exception cref="UserGeneralException">Thrown when a general error occurs.</exception>
    Task<UserDao> GetUserDaoById(Guid userId);

    /// <summary>
    ///     Method used to follow a user by id
    /// </summary>
    /// <param name="userIdFollows">
    ///     The user that tries to follow another
    /// </param>
    /// <param name="userIdToFollow">
    ///     The user that the user tries to follow
    /// </param>
    /// <returns>
    ///     Task
    /// </returns>
    /// <exception cref="UserIudException">Thrown when an error occurs during Insert, Update, or Delete operations.</exception>
    /// <exception cref="UserGeneralException">Thrown when a general error occurs.</exception>
    Task FollowUserById(Guid userIdFollows, Guid userIdToFollow);

    /// <summary>
    ///     Method used to unfollow a user by id
    /// </summary>
    /// <param name="userIdFollows">
    ///     The user that tries to unfollow another
    /// </param>
    /// <param name="userIdToUnfollow">
    ///     The user that the user tries to unfollow
    /// </param>
    /// <returns>
    ///     Task
    /// </returns>
    /// <exception cref="UserIudException">Thrown when an error occurs during Insert, Update, or Delete operations.</exception>
    /// <exception cref="UserGeneralException">Thrown when a general error occurs.</exception>
    Task UnfollowUserById(Guid userIdFollows, Guid userIdToUnfollow);

    /// <summary>
    ///     This sets a dto holding information about the current user in order to show the current users infos in the profile
    ///     card
    /// </summary>
    /// <param name="userId">User from which the dto should be retrieved</param>
    /// <returns>
    ///     Returns a task of type UserInformationDto. The dto is used to update the state in the view.
    /// </returns>
    public Task<UserInformationDto?> GetUserInfo(Guid userId);

}