using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.UserExceptions;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Services;

/// <summary>
///     This class is the User Service. It is responsible for handling all User related operations.
/// </summary>
public class UserService : IUserService
{
    private static readonly Logging<UserService> Logger = new();
    private readonly IDatabaseActions _databaseActions;
    private readonly IPostService _postService;

    /// <summary>
    ///     This constructor creates a new UserService object.
    /// </summary>
    /// <param name="databaseActions">This parameter is used to interact with the database</param>
    /// <param name="postService">This parameter is used to interact with the post service</param>
    public UserService(IDatabaseActions databaseActions, IPostService postService)
    {
        Logger.LogInfo("Creating a new UserService object");
        _databaseActions = databaseActions;
        _postService = postService;
    }

    /// <summary>
    ///     This method creates a new User object in the database and returns the created object. This method does not check if
    ///     the User already exists.
    /// </summary>
    /// <param name="userId">The ID we get from the Supabase Authentication Service</param>
    /// <param name="username">The Username of the User</param>
    /// <param name="description">The Description of the User (optional)</param>
    /// <param name="profilePicture">The Profile Picture of the User (optional)</param>
    /// <returns>Returns the created UserDto. If it was unable to create a User, it will throw an exception.</returns>
    public async Task<UserDto> CreateUser(string userId, string username, string email, Guid roleId,
        string? description = null,
        string? profilePicture = null)
    {
        var user = new UserDao
        {
            UserId = Guid.Parse(userId),
            UserName = username,
            Description = description ?? string.Empty,
            ProfilePic = profilePicture ?? string.Empty,
            Email = email,
            RoleId = roleId
        };

        try
        {
            Logger.LogInfo($"Creating a new user {user}");
            var result = await _databaseActions.Insert(user);
            return new UserDto().Mapper(result);
        }
        catch (DatabaseIudActionException ex)
        {
            throw new UserIudException(
                $"An error occurred while creating the user. Parameters: {userId} {username}, {description}", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new UserGeneralException(
                $"A database error occurred while creating the user Parameters: {userId} {username}, {description}",
                ex);
        }
        catch (Exception ex)
        {
            throw new UserGeneralException(
                $"An error occurred while creating the user Parameters: {userId} {username}, {description}", ex);
        }
    }

    /// <summary>
    ///     This method deletes the given User object from the database.
    /// </summary>
    /// <param name="user">The UserDto object to delete</param>
    /// <returns>Returns true if the User was successfully deleted, otherwise false.</returns>
    public async Task<bool> DeleteUser(UserDto user)
    {
        try
        {
            var userDao = user.Mapper();
            Logger.LogInfo($"Deleting a user {userDao}");
            return await _databaseActions.Delete(userDao);
        }
        catch (DatabaseIudActionException ex)
        {
            throw new UserIudException($"An error occurred while deleting the user. User: {user}", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new UserGeneralException($"An error occurred while deleting the user. User: {user}", ex);
        }
        catch (Exception ex)
        {
            throw new UserGeneralException($"An error occurred while deleting the user. User: {user}", ex);
        }
    }

    /// <summary>
    ///     This method returns a User object from the database based on the given userId.
    /// </summary>
    /// <param name="userId">The ID of the User to get from the Database</param>
    /// <returns>Returns the UserDto object from the Database. If no User was found, it will throw an exception.</returns>
    public async Task<UserDto> GetUserById(Guid userId)
    {
        try
        {
            Logger.LogInfo($"Fetching user with ID {userId}");
            var user = await _databaseActions.GetEntityByField<UserDao>("userID", userId.ToString());
            return new UserDto().Mapper(user);
        }
        catch (DatabaseMissingItemException ex)
        {
            throw new UserNotFoundException($"User with the given ID was not found. ID: {userId}", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new UserGeneralException("An error occurred while fetching the user", ex);
        }
        catch (Exception ex)
        {
            throw new UserGeneralException("An error occurred while fetching the user", ex);
        }
    }

    /// <summary>
    ///     Gets a UserDTO by its username (usernames are duplicate free)
    /// </summary>
    /// <param name="username">
    ///     Username used for retrieving a user
    /// </param>
    /// <returns>
    ///     The corresponding UserDTO
    /// </returns>
    public virtual async Task<bool> CheckIfUserExistsByUserName(string username)
    {
        try
        {
            Logger.LogInfo($"Fetching user with username {username}");
            var result = await _databaseActions.CheckIfEntityExists<UserDao>("userName", username);
            return result;
        }
        catch (GeneralDatabaseException ex)
        {
            throw new UserGeneralException(
                $"An error occurred while checking if the the user exists. Username: {username}", ex);
        }
        catch (Exception ex)
        {
            throw new UserGeneralException(
                $"A general error occurred while checking if the the user exists. Username: {username}", ex);
        }
    }

    /// <summary>
    ///     This method updates the given User object in the database and returns the updated object.
    /// </summary>
    /// <param name="user">The updated UserDto</param>
    /// <returns>Returns the updated UserDto. If it was unable to update the User, it will throw an exception.</returns>
    public async Task<UserDto> UpdateUser(UserDao user)
    {
        try
        {
            Logger.LogInfo($"Updating user {user}");
            var result = await _databaseActions.Update(user);
            return new UserDto().Mapper(result);
        }
        catch (DatabaseIudActionException ex)
        {
            throw new UserIudException($"An error occurred while updating the user. User {user}", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new UserGeneralException($"An error occurred while updating the user. User {user}", ex);
        }
        catch (Exception ex)
        {
            throw new UserGeneralException($"An error occurred while updating the user. User {user}", ex);
        }
    }

    /// <summary>
    ///     Retrieves a user from the database based on the provided criteria (ID, username, or email).
    /// </summary>
    /// <param name="userID">The ID of the user to retrieve (optional).</param>
    /// <param name="username">The username of the user to retrieve (optional).</param>
    /// <param name="email">The email of the user to retrieve (optional).</param>
    /// <returns>Returns the UserDao object if found, otherwise null.</returns>
    /// <exception cref="UserNotFoundException">Thrown when no user is found with the provided criteria.</exception>
    /// <exception cref="UserGeneralException">Thrown when a general database error occurs.</exception>
    public async Task<UserDao> GetUserBy(Guid? userID = null, string? username = null, string? email = null)
    {
        try
        {
            Logger.LogInfo("Starting GetUser method to retrieve user by ID, username, or email.");

            UserDao user = null;

            if (userID is not null)
            {
                Logger.LogInfo($"Attempting to retrieve user by ID: {userID}");
                user = await GetUserDaoById(userID.Value);
            }
            else if (username is not null)
            {
                Logger.LogInfo($"Attempting to retrieve user by username: {username}");
                user = await _databaseActions.GetEntityByField<UserDao>("userName", username);
            }
            else if (email is not null)
            {
                Logger.LogInfo($"Attempting to retrieve user by email: {email}");
                user = await _databaseActions.GetEntityByField<UserDao>("email", email);
            }

            if (user != null)
                Logger.LogInfo($"Successfully retrieved user: {user}");
            else
                Logger.LogWarn("No user found with the provided criteria.");

            return user;
        }
        catch (DatabaseMissingItemException ex)
        {
            if (userID is not null)
                throw new UserNotFoundException($"User with the given ID was not found. ID: {userID}", ex);
            if (username is not null)
                throw new UserNotFoundException($"User with the given username was not found. Username: {username}",
                    ex);
            if (email is not null)
                throw new UserNotFoundException($"User with the given email was not found. Email: {email}", ex);
            throw new UserNotFoundException("User not found.", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            if (userID is not null)
                throw new UserGeneralException($"An error occurred while fetching the user. ID: {userID}", ex);
            if (username is not null)
                throw new UserGeneralException($"An error occurred while fetching the user. Username: {username}", ex);
            if (email is not null)
                throw new UserGeneralException($"An error occurred while fetching the user. Email: {email}", ex);
            throw new UserGeneralException("An error occurred while fetching the user.", ex);
        }
    }

    /// <summary>
    ///     This method returns the Profile Picture of the given User.
    /// </summary>
    /// <param name="userId">The ID of the User</param>
    /// <returns>Returns the ProfilePicDto containing the Profile Picture of the User.</returns>
    /// <exception cref="UserNotFoundException">Throws an exception if the user is not found</exception>
    public async Task<ProfilePicDto> GetProfilePic(Guid userId)
    {
        try
        {
            Logger.LogInfo($"Fetching profile picture for user with ID {userId}");
            var user = await GetUserDaoById(userId);
            return new ProfilePicDto
            {
                UserId = userId,
                ProfilePic = user.ProfilePic ?? string.Empty
            };
        }
        catch (DatabaseMissingItemException ex)
        {
            throw new UserNotFoundException($"User with the given ID was not found. ID: {userId}", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new UserGeneralException($"An error occurred while fetching the profile picture. ID {userId}", ex);
        }
    }

    /// <summary>
    ///     This method returns a UserDto object from the database based on the given userId.
    /// </summary>
    /// <param name="userId">The ID of the user</param>
    /// <param name="recentForums">The maximum number of recent forums to retrieve</param>
    /// <returns>Returns the UserDto object with recent forums.</returns>
    public async Task<UserDto> GetUser(Guid userId, int recentForums = 5)
    {
        try
        {
            Logger.LogInfo($"Fetching user with ID {userId} and recent forums {recentForums}");
            var result = await _databaseActions.GetEntitieWithSelectorById<UserDao>(
                x => new object[] { x.UserId!, x.UserName!, x.Description!, x.CreatedAt }, "userID", userId.ToString());
            var user = new UserDto().Mapper(result);

            Logger.LogInfo($"Fetching recent forums for user with ID {userId}");
            user.RecentForums = await _postService.GetPostsFromForum(userId, 0, recentForums);

            return user;
        }
        catch (DatabaseMissingItemException ex)
        {
            throw new UserNotFoundException($"User with the given ID was not found. ID: {userId}", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new UserGeneralException($"An error occurred while fetching the user. ID: {userId}", ex);
        }
        catch (Exception ex)
        {
            throw new UserGeneralException($"An error occurred while fetching the user. ID {userId}", ex);
        }
    }

    /// <summary>
    ///     This method returns a list of friends for the given user.
    /// </summary>
    /// <param name="userId">The ID of the user</param>
    /// <returns>Returns a FriendsOfUserDto object containing the list of friends.</returns>
    public async Task<FriendsOfUserDto> GetFriends(Guid userId)
    {
        try
        {
            Logger.LogInfo($"Fetching friends for user with ID {userId}");
            var friends = await _databaseActions.GetEntitiesWithSelectorById<FollowerUserRelationDao>(
                x => new object[] { x.FollowedUserId! }, "followerUserID", userId.ToString());
            var friendList = new FriendsOfUserDto
            {
                UserId = userId,
                Friends = new List<UserDto>()
            };

            Logger.LogInfo(
                $"Found {friends.Count} friends for user with ID {userId}. Now mapping them to UserDto objects.");
            foreach (var friend in friends)
                if (friend.FollowerUser != null)
                    friendList.Friends.Add(new UserDto().Mapper(friend.FollowerUser));

            return friendList;
        }
        catch (DatabaseMissingItemException ex)
        {
            throw new UserNotFoundException($"User with the given ID was not found. ID: {userId}", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new UserGeneralException($"An error occurred while fetching the friends. ID {userId}", ex);
        }
        catch (Exception ex)
        {
            throw new UserGeneralException($"An error occurred while fetching the friends. ID {userId}", ex);
        }
    }

    /// <summary>
    ///     This method returns a UserDao object from the database based on the given userId.
    /// </summary>
    /// <param name="userId">The ID of the User to get from the Database</param>
    /// <returns>Returns the UserDao object from the Database. If no User was found, it will throw an exception.</returns>
    private async Task<UserDao> GetUserDaoById(Guid userId)
    {
        try
        {
            Logger.LogInfo($"Fetching user with ID {userId}");
            var user = await _databaseActions.GetEntityByField<UserDao>("userID", userId.ToString());
            return user;
        }
        catch (DatabaseMissingItemException ex)
        {
            throw new UserNotFoundException($"User with the given ID was not found. ID: {userId}", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new UserGeneralException($"An error occurred while fetching the user. ID: {userId}", ex);
        }
    }
}