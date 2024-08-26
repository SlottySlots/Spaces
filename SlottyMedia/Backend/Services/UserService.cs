using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.PostExceptions;
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
    private readonly IUserRepository _userRepository;

    /// <summary>
    ///     This constructor creates a new UserService object.
    /// </summary>
    /// <param name="databaseActions">This parameter is used to interact with the database</param>
    /// <param name="postService">This parameter is used to interact with the post service</param>
    public UserService(IUserRepository userRepository)
    {
        Logger.LogInfo("Creating a new UserService object");
        _userRepository = userRepository;
    }

    /// <inheritdoc />
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

    /// <inheritdoc />
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

    /// <inheritdoc />
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

    /// <inheritdoc />
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

    /// <inheritdoc />
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

    /// <inheritdoc />
    public async Task<UserDto> UpdateUser(UserDto user)
    {
        try
        {
            var userDao = await _databaseActions.GetEntityByField<UserDao>("userID", user.UserId.ToString());
            userDao.Description = user.Description;
            Logger.LogInfo($"Updating user {user}");
            var result = await _databaseActions.Update(userDao);
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

    /// <inheritdoc />
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

    /// <inheritdoc />
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

    /// <inheritdoc />
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

    /// <inheritdoc />
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

    /// <inheritdoc />
    public async Task<int> GetCountOfUserFriends(Guid userId)
    {
        try
        {
            Logger.LogInfo($"Fetching friends count for user with ID {userId}");
            var friends =
                await _databaseActions.GetCountByField<FollowerUserRelationDao>("userIsFollowed", userId.ToString());
            return friends;
        }
        catch (GeneralDatabaseException ex)
        {
            throw new UserGeneralException($"An error occurred while fetching the friends count. ID {userId}", ex);
        }
        catch (Exception ex)
        {
            throw new UserGeneralException($"An error occurred while fetching the friends count. ID {userId}", ex);
        }
    }

    /// <summary>
    ///     Gets all spaces a user has wrote in
    /// </summary>
    /// <param name="userId">
    ///     User from which it should be retrieved
    /// </param>
    /// <returns>
    ///     Returns the amount of spaces as task
    /// </returns>
    public async Task<int> GetCountOfUserSpaces(Guid userId)
    {
        try
        {
            //TODO: Currently not working
            var spaces = await _postService.GetForumCountByUserId(userId);
            return spaces;
        }
        catch (PostGeneralException)
        {
            throw;
        }
    }

    /// <inheritdoc />
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