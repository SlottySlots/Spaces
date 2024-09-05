using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.UserExceptions;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.Database.Repository.FollowerUserRelatioRepo;
using SlottyMedia.Database.Repository.UserRepo;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Services;

/// <summary>
///     This class is the User Service. It is responsible for handling all User related operations.
/// </summary>
public class UserService : IUserService
{
    private static readonly Logging<UserService> Logger = new();
    private readonly IFollowerUserRelationRepository _followerUserRelationRepository;
    private readonly IPostService _postService;
    private readonly IUserRepository _userRepository;

    /// <summary>
    ///     This constructor creates a new UserService object.
    /// </summary>
    /// <param name="userRepository">Repository used to fetch user table</param>
    /// <param name="postService">This parameter is used to interact with the post service</param>
    /// <param name="followerUserRelationRepository">Repository used to fetch follower user relations</param>
    public UserService(IUserRepository userRepository, IPostService postService,
        IFollowerUserRelationRepository followerUserRelationRepository)
    {
        Logger.LogInfo("Creating a new UserService object");
        _userRepository = userRepository;
        _postService = postService;
        _followerUserRelationRepository = followerUserRelationRepository;
    }

    /// <inheritdoc />
    public async Task CreateUser(string userId, string username, string email, Guid roleId,
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
            Logger.LogDebug($"Creating a new user {user}");

            await _userRepository.AddElement(user);
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
    public async Task DeleteUser(UserDto user)
    {
        try
        {
            var userDao = user.Mapper();
            Logger.LogDebug($"Deleting a user {userDao}");
            await _userRepository.DeleteElement(userDao);
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
    public async Task<UserDto> GetUserDtoById(Guid userId)
    {
        try
        {
            Logger.LogDebug($"Fetching user with ID {userId}");
            var user = await _userRepository.GetElementById(userId);
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
            Logger.LogDebug($"Fetching user with username {username}");
            await _userRepository.GetUserByUsername(username);
            return true;
        }
        catch (DatabaseMissingItemException)
        {
            return false;
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
    public async Task UpdateUser(UserDao user)
    {
        try
        {
            Logger.LogDebug($"Updating user {user}");
            await _userRepository.UpdateElement(user);
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
    public async Task UpdateUser(UserDto user)
    {
        try
        {
            var userDao = await _userRepository.GetElementById(user.UserId);
            userDao.Description = user.Description;
            Logger.LogDebug($"Updating user {user}");
            await _userRepository.UpdateElement(userDao);
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
    public async Task<bool> UserFollowRelation(Guid userIdToCheck, Guid userIdLoggedIn)
    {
        try
        {
            await _followerUserRelationRepository.CheckIfUserIsFollowed(userIdToCheck, userIdLoggedIn);
            return true;
        }
        catch (DatabaseMissingItemException)
        {
            return false;
        }
        catch (GeneralDatabaseException ex)
        {
            Logger.LogError(ex, "There was an error trying to check if the follower user is followed.");
            return false;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "There was an error trying to check if the follower user is followed.");
            return false;
        }
    }

    /// <inheritdoc />
    public async Task<ProfilePicDto> GetProfilePic(Guid userId)
    {
        try
        {
            Logger.LogDebug($"Fetching profile picture for user with ID {userId}");
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
    public async Task<FriendsOfUserDto> GetFriends(Guid userId)
    {
        try
        {
            Logger.LogDebug($"Fetching friends for user with ID {userId}");
            var friends = await _followerUserRelationRepository.GetFriends(userId);
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

    //TODO move to right service
    /// <inheritdoc />
    public async Task<int> GetCountOfUserFriends(Guid userId)
    {
        try
        {
            Logger.LogDebug($"Fetching friends count for user with ID {userId}");
            var friends = await _followerUserRelationRepository.GetCountOfUserFriends(userId);
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

    /// <inheritdoc />
    public async Task<int> GetCountOfUserSpaces(Guid userId)
    { 
        var spaces = await _postService.GetForumCountByUserId(userId);
        return spaces;
    }

    /// <inheritdoc />
    public async Task<UserDao> GetUserDaoById(Guid userId)
    {
        try
        {
            Logger.LogDebug($"Fetching user with ID {userId}");
            var user = await _userRepository.GetElementById(userId);
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

    /// <inheritdoc />
    public async Task FollowUserById(Guid userIdFollows, Guid userIdToFollow)
    {
        try
        {
            var userFollows = new FollowerUserRelationDao
            {
                FollowerUserId = userIdFollows,
                FollowedUserId = userIdToFollow
            };
            await _followerUserRelationRepository.AddElement(userFollows);
        }
        catch (DatabaseIudActionException ex)
        {
            throw new UserIudException(
                $"An error occurred while following the user. UserIdFollows: {userIdFollows}, UserIdToFollow: {userIdToFollow}",
                ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new UserGeneralException(
                $"An error occurred while following the user. UserIdFollows: {userIdFollows}, UserIdToFollow: {userIdToFollow}",
                ex);
        }
        catch (Exception ex)
        {
            throw new UserGeneralException(
                $"An error occurred while following the user. UserIdFollows: {userIdFollows}, UserIdToFollow: {userIdToFollow}",
                ex);
        }
    }

    /// <inheritdoc />
    public async Task UnfollowUserById(Guid userIdFollows, Guid userIdToUnfollow)
    {
        try
        {
            var userToDelete =
                await _followerUserRelationRepository.CheckIfUserIsFollowed(userIdToUnfollow, userIdFollows);
            await _followerUserRelationRepository.DeleteElement(userToDelete);
        }
        catch (DatabaseIudActionException ex)
        {
            throw new UserIudException(
                $"An error occurred while unfollowing the user. UserIdFollows: {userIdFollows}, UserIdToUnfollow: {userIdToUnfollow}",
                ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new UserGeneralException(
                $"An error occurred while unfollowing the user. UserIdFollows: {userIdFollows}, UserIdToUnfollow: {userIdToUnfollow}",
                ex);
        }
        catch (Exception ex)
        {
            throw new UserGeneralException(
                $"An error occurred while unfollowing the user. UserIdFollows: {userIdFollows}, UserIdToUnfollow: {userIdToUnfollow}",
                ex);
        }
    }

    /// <inheritdoc />
    public async Task<UserInformationDto?> GetUserInfo(Guid userId, bool fetchFriends = true, bool fetchSpaces = true)
    {
        try
        {
            var userDao = await GetUserDaoById(userId);
            var amountOfFriends = 0;
            var amountOfSpaces = 0;
            if (fetchSpaces) amountOfSpaces = await GetCountOfUserSpaces(userId);

            if (fetchFriends) amountOfFriends = await GetCountOfUserFriends(userId);

            if (userDao is { UserId: null, UserName: null, Description: null, Email: null })
            {
                Logger.LogError(
                    $"User with id {userId.ToString()} retrieved corrupt User entry from database!");
            }
            else
            {
                var userInformationDto = new UserInformationDto
                {
                    UserId = userDao.UserId!,
                    Username = userDao.UserName!,
                    Description = userDao.Description!,
                    ProfilePic = userDao.ProfilePic,
                    FriendsAmount = amountOfFriends,
                    SpacesAmount = amountOfSpaces,
                    CreatedAt = userDao.CreatedAt.LocalDateTime
                };
                return userInformationDto;
            }
        }
        catch (UserNotFoundException ex)
        {
            Logger.LogError(ex, $"User with id {userId} not found");
        }
        catch (UserGeneralException ex)
        {
            Logger.LogError(ex, $"An error occurred while fetching UserInformation with id {userId}");
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, $"An error occurred while fetching UserInformation with id {userId}");
        }

        return null;
    }
}