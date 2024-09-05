using Bogus;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.Database.Helper;
using SlottyMedia.Database.Repository;
using SlottyMedia.Database.Repository.CommentRepo;
using SlottyMedia.Database.Repository.FollowerUserRelatioRepo;
using SlottyMedia.Database.Repository.ForumRepo;
using SlottyMedia.Database.Repository.PostRepo;
using SlottyMedia.Database.Repository.RoleRepo;
using SlottyMedia.Database.Repository.UserLikePostRelationRepo;
using SlottyMedia.Database.Repository.UserRepo;
using SlottyMedia.DatabaseSeeding.Exceptions;
using SlottyMedia.LoggingProvider;
using Supabase;
using Supabase.Postgrest.Models;

namespace SlottyMedia.DatabaseSeeding;

/// <summary>
///     This class represents the Seeding.
/// </summary>
public class Seeding
{
    private static readonly Logging<Seeding> Logger = new();
    private readonly Client _client;
    private readonly DaoHelper _daoHelper;
    private readonly DatabaseRepositroyHelper _databaseRepositroyHelper;

    /// <summary>
    ///     This is the constructor for the Seeding class.
    /// </summary>
    /// <param name="client">The Supabase client.</param>
    /// <param name="daoHelper">The DAO helper instance.</param>
    /// <param name="databaseRepositroyHelper">The database repository helper instance.</param>
    public Seeding(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper)
    {
        _client = client;
        _daoHelper = daoHelper;
        _databaseRepositroyHelper = databaseRepositroyHelper;
    }

    /// <summary>
    ///     This method seeds the database with random data.
    /// </summary>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    /// <exception cref="DatabaseSeedingRepositoryCreationFailed">Thrown when repository creation fails.</exception>
    /// <exception cref="DatabaseSeedingUserDosentContainProfilePic">Thrown when a user does not contain a profile pic.</exception>
    /// <exception cref="DatabaseIudActionException">Thrown when an error occurs while deleting the entity.</exception>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entity is not found in the database.</exception>
    public async Task Seed()
    {
        Login login = new();
        await login.LoginUser(_client);

        await CheckIfRoleExisits();

        var countUser = 20;
        var rules = new Rules();

        var userIds = new List<Guid>();

        if (await CheckIfSeedingIsNeeded<UserDao>(countUser))
        {
            Logger.LogInfo("Database needs seeding with random user data.");
            var userFaker = rules.UserRules();
            userIds = await GenerateUsers(userFaker, countUser);
        }
        else
        {
            Logger.LogInfo("Database already seeded with random user data.");
        }

        var forumIds = new List<Guid>();

        if (await CheckIfSeedingIsNeeded<ForumDao>(countUser * 2))
        {
            Logger.LogInfo("Database needs seeding with random forum data.");
            var forumFaker = rules.ForumRules(userIds);
            forumIds = await GenerateForums(forumFaker, countUser * 2);
        }
        else
        {
            Logger.LogInfo("Database already seeded with random forum data.");
        }


        var postIds = new List<Guid>();
        if (await CheckIfSeedingIsNeeded<PostsDao>(countUser * 4))
        {
            Logger.LogInfo("Database needs seeding with random post data.");
            var postFaker = rules.PostRules(userIds, forumIds);
            postIds = await GeneratePosts(postFaker, countUser * 4);
        }
        else
        {
            Logger.LogInfo("Database already seeded with random post data.");
        }

        if (await CheckIfSeedingIsNeeded<CommentDao>(countUser * 6))
        {
            Logger.LogInfo("Database needs seeding with random comment data.");
            var commentFaker = rules.CommentRules(userIds, postIds);
            await GenereateComments(commentFaker, postIds.Count * 6);
        }
        else
        {
            Logger.LogInfo("Database already seeded with random comment data.");
        }

        if (await CheckIfSeedingIsNeeded<FollowerUserRelationDao>(userIds.Count * (userIds.Count - 1)))
        {
            Logger.LogInfo("Database needs seeding with random follower user relation data.");
            var followerUserRelationFaker = rules.FollowerUserRelationRules(userIds);
            await GenerateFollowerUserRelation(followerUserRelationFaker, userIds.Count * (userIds.Count - 1));
        }
        else
        {
            Logger.LogInfo("Database already seeded with random follower user relation data.");
        }


        if (await CheckIfSeedingIsNeeded<UserLikePostRelationDao>(userIds.Count * postIds.Count / 2))
        {
            Logger.LogInfo("Database needs seeding with random user like post relation data.");
            var userLikePostRelationFaker = rules.UserLikePostRelationRules(userIds, postIds);
            await GenerateUserLikePostRelation(userLikePostRelationFaker, userIds.Count * postIds.Count / 2);
        }
        else
        {
            Logger.LogInfo("Database already seeded with random user like post relation data.");
        }

        await login.LogoutUser(_client);
    }

    /// <summary>
    ///     Gets the appropriate database repository for the given type.
    /// </summary>
    /// <typeparam name="T">The type of the DAO.</typeparam>
    /// <returns>The database repository for the given type.</returns>
    private DatabaseRepository<T>? GetDatabaseRepository<T>() where T : BaseModel, new()
    {
        return typeof(T) switch
        {
            var t when t == typeof(UserDao) => new UserRepository(_client, _daoHelper, _databaseRepositroyHelper) as
                DatabaseRepository<T>,
            var t when t == typeof(ForumDao) => new ForumRepository(_client, _daoHelper, _databaseRepositroyHelper) as
                DatabaseRepository<T>,
            var t when t == typeof(PostsDao) => new PostRepository(_client, _daoHelper, _databaseRepositroyHelper) as
                DatabaseRepository<T>,
            var t when t == typeof(CommentDao) => new CommentRepository(_client, _daoHelper, _databaseRepositroyHelper)
                as DatabaseRepository<T>,
            var t when t == typeof(FollowerUserRelationDao) => new FollowerUserRelationRepository(_client, _daoHelper,
                _databaseRepositroyHelper) as DatabaseRepository<T>,
            var t when t == typeof(UserLikePostRelationDao) => new UserLikePostRelationRepostitory(_client, _daoHelper,
                _databaseRepositroyHelper) as DatabaseRepository<T>,
            _ => null
        };
    }

    /// <summary>
    ///     Checks if seeding is needed for the given type and amount.
    /// </summary>
    /// <typeparam name="T">The type of the DAO.</typeparam>
    /// <param name="amount">The amount of elements to check for.</param>
    /// <returns>True if seeding is needed, otherwise false.</returns>
    /// <exception cref="DatabaseSeedingRepositoryCreationFailed">Thrown when repository creation fails.</exception>
    /// <exception cref="DatabaseIudActionException">Thrown when an error occurs while deleting the entity.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    private async Task<bool> CheckIfSeedingIsNeeded<T>(int amount) where T : BaseModel, new()
    {
        var repository = GetDatabaseRepository<T>();
        if (repository == null)
            throw new DatabaseSeedingRepositoryCreationFailed("Repository creation failed");
        try
        {
            Logger.LogInfo("Checking if seeding is needed.");
            var result = await repository.GetAllElements();
            if (result.Count < amount)
                return true;
            return false;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "An exception occurred.");
            throw;
        }
    }

    /// <summary>
    ///     Generates and inserts random users into the database.
    /// </summary>
    /// <param name="userFaker">The Faker instance for generating users.</param>
    /// <param name="amount">The amount of users to generate.</param>
    /// <returns>A list of generated user IDs.</returns>
    /// <exception cref="DatabaseSeedingUserDosentContainProfilePic">Thrown when a user does not contain a profile pic.</exception>
    /// <exception cref="DatabaseIudActionException">Thrown when an error occurs while deleting the entity.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    private async Task<List<Guid>> GenerateUsers(Faker<UserDao> userFaker, int amount)
    {
        var userRepository = new UserRepository(_client, _daoHelper, _databaseRepositroyHelper);
        try
        {
            // Generate and insert users
            Logger.LogInfo("Generating and seeding random user data.");
            var users = userFaker.Generate(amount);
            var userIds = new List<Guid>();
            for (var i = 0; i < users.Count; i++)
                if (users[i].ProfilePic == null)
                {
                    throw new DatabaseSeedingUserDosentContainProfilePic("User does not contain a profile pic.");
                }
                else
                {
                    var result = await ImageDownloader.DownloadAndEncodeImage(users[i].ProfilePic!);
                    users[i].ProfilePic = result;

                    var user = await userRepository.AddElement(users[i]);
                    userIds.Add(user.UserId ?? Guid.Empty);
                    Logger.LogInfo("User seeded: " + user.UserName);
                }

            Logger.LogInfo("Database seeded with random user data.");
            return userIds;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "An exception occurred while seeding users.");
            throw;
        }
    }

    /// <summary>
    ///     Generates and inserts random forums into the database.
    /// </summary>
    /// <param name="forumFaker">The Faker instance for generating forums.</param>
    /// <param name="amount">The amount of forums to generate.</param>
    /// <returns>A list of generated forum IDs.</returns>
    /// <exception cref="DatabaseIudActionException">Thrown when an error occurs while deleting the entity.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    private async Task<List<Guid>> GenerateForums(Faker<ForumDao> forumFaker, int amount)
    {
        var forumRepository = new ForumRepository(_client, _daoHelper, _databaseRepositroyHelper);
        try
        {
            // Generate and insert forums
            Logger.LogInfo("Generating and seeding random forum data.");
            var forums = forumFaker.Generate(amount);
            var forumIds = new List<Guid>();
            for (var i = 0; i < forums.Count; i++)
            {
                var forum = await forumRepository.AddElement(forums[i]);
                forumIds.Add(forum.ForumId ?? Guid.Empty);
                Logger.LogInfo("Forum seeded: " + forum.ForumTopic);
            }

            Logger.LogInfo("Database seeded with random forum data.");
            return forumIds;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "An exception occurred while seeding forums.");
            throw;
        }
    }

    /// <summary>
    ///     Generates and inserts random posts into the database.
    /// </summary>
    /// <param name="postFaker">The Faker instance for generating posts.</param>
    /// <param name="amount">The amount of posts to generate.</param>
    /// <returns>A list of generated post IDs.</returns>
    /// <exception cref="DatabaseIudActionException">Thrown when an error occurs while deleting the entity.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    private async Task<List<Guid>> GeneratePosts(Faker<PostsDao> postFaker, int amount)
    {
        var postRepository = new PostRepository(_client, _daoHelper, _databaseRepositroyHelper);
        try
        {
            // Generate and insert posts
            Logger.LogInfo("Generating and seeding random post data.");
            var posts = postFaker.Generate(amount);
            var postIds = new List<Guid>();
            for (var i = 0; i < posts.Count; i++)
            {
                var post = await postRepository.AddElement(posts[i]);
                postIds.Add(post.PostId ?? Guid.Empty);
                Logger.LogInfo("Post seeded: " + post.Headline);
            }

            Logger.LogInfo("Database seeded with random post data.");
            return postIds;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "An exception occurred while seeding posts.");
            throw;
        }
    }

    /// <summary>
    ///     Generates and inserts random comments into the database.
    /// </summary>
    /// <param name="commentFaker">The Faker instance for generating comments.</param>
    /// <param name="amount">The amount of comments to generate.</param>
    /// <exception cref="DatabaseIudActionException">Thrown when an error occurs while deleting the entity.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    private async Task GenereateComments(Faker<CommentDao> commentFaker, int amount)
    {
        var commentRepository = new CommentRepository(_client, _daoHelper, _databaseRepositroyHelper);
        try
        {
            // Generate and insert comments
            Logger.LogInfo("Generating and seeding random comment data.");
            var comments = commentFaker.Generate(amount);
            for (var i = 0; i < comments.Count; i++)
            {
                var comment = await commentRepository.AddElement(comments[i]);
                Logger.LogInfo("Comment seeded: " + comment.Content);
            }

            Logger.LogInfo("Database seeded with random comment data.");
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "An exception occurred while seeding comments.");
            throw;
        }
    }

    /// <summary>
    ///     Generates and inserts random follower user relations into the database.
    /// </summary>
    /// <param name="followerUserRelationFaker">The Faker instance for generating follower user relations.</param>
    /// <param name="amount">The amount of follower user relations to generate.</param>
    /// <exception cref="DatabaseIudActionException">Thrown when an error occurs while deleting the entity.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    private async Task GenerateFollowerUserRelation(Faker<FollowerUserRelationDao> followerUserRelationFaker,
        int amount)
    {
        var followerUserRelationRepository = new FollowerUserRelationRepository(_client, _daoHelper,
            _databaseRepositroyHelper);
        try
        {
            // Generate and insert follower user relations
            Logger.LogInfo("Generating and seeding random follower user relation data.");
            var followerUserRelations = followerUserRelationFaker.Generate(amount);
            for (var i = 0; i < followerUserRelations.Count; i++)
            {
                var followerUserRelation = await followerUserRelationRepository.AddElement(followerUserRelations[i]);
                Logger.LogInfo("FollowerUserRelation seeded. Follower: " + followerUserRelation.FollowerUserId +
                               " Followed: " + followerUserRelation.FollowedUserId);
            }

            Logger.LogInfo("Database seeded with random follower user relation data.");
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "An exception occurred while seeding follower user relations.");
            throw;
        }
    }

    /// <summary>
    ///     Generates and inserts random user like post relations into the database.
    /// </summary>
    /// <param name="userLikePostRelationFaker">The Faker instance for generating user like post relations.</param>
    /// <param name="amount">The amount of user like post relations to generate.</param>
    /// <exception cref="DatabaseIudActionException">Thrown when an error occurs while deleting the entity.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    private async Task GenerateUserLikePostRelation(Faker<UserLikePostRelationDao> userLikePostRelationFaker,
        int amount)
    {
        var userLikePostRelationRepository = new UserLikePostRelationRepostitory(_client, _daoHelper,
            _databaseRepositroyHelper);
        try
        {
            // Generate and insert user like post relations
            Logger.LogInfo("Generating and seeding random user like post relation data.");
            var userLikePostRelations = userLikePostRelationFaker.Generate(amount);
            for (var i = 0; i < userLikePostRelations.Count; i++)
            {
                var userLikePostRelation = await userLikePostRelationRepository.AddElement(userLikePostRelations[i]);
                Logger.LogDebug("UserLikePostRelation seeded. User: " + userLikePostRelation.UserId + " Post: " +
                                userLikePostRelation.PostId);
            }

            Logger.LogDebug("Database seeded with random user like post relation data.");
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "An exception occurred while seeding user like post relations.");
            throw;
        }
    }

    /// <summary>
    ///     Checks if a specific role exists in the database.
    /// </summary>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    private async Task CheckIfRoleExisits()
    {
        var roleRepository = new RoleRepository(_client, _daoHelper, _databaseRepositroyHelper);
        var roleId = "c0589855-a81c-451d-8587-3061926a1f3a";
        Logger.LogInfo("Checking if role exists.");
        try
        {
            var result = await roleRepository.GetElementById(Guid.Parse(roleId));
            Logger.LogInfo("Role exists.");
        }
        catch (DatabaseMissingItemException)
        {
            Logger.LogInfo("Role does not exist. Seeding role.");
            var role = new RoleDao
            {
                RoleId = Guid.Parse(roleId),
                RoleName = "User",
                Description = "User"
            };

            await roleRepository.AddElement(role);
            Logger.LogInfo("Role seeded.");
        }
        catch (GeneralDatabaseException ex)
        {
            Logger.LogError(ex, "An exception occurred.");
            throw;
        }
    }
}