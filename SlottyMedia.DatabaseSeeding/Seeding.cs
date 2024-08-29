using Bogus;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.Database.Helper;
using SlottyMedia.Database.Repository.CommentRepo;
using SlottyMedia.Database.Repository.FollowerUserRelatioRepo;
using SlottyMedia.Database.Repository.ForumRepo;
using SlottyMedia.Database.Repository.PostRepo;
using SlottyMedia.Database.Repository.RoleRepo;
using SlottyMedia.Database.Repository.UserLikePostRelationRepo;
using SlottyMedia.Database.Repository.UserRepo;
using SlottyMedia.LoggingProvider;
using Supabase;

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
    /// <param name="client"></param>
    /// <param name="daoHelper"></param>
    /// <param name="databaseRepositroyHelper"></param>
    public Seeding(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper)
    {
        _client = client;
        _daoHelper = daoHelper;
        _databaseRepositroyHelper = databaseRepositroyHelper;
    }

    /// <summary>
    ///     This method seeds the database with random data.
    /// </summary>
    public async Task Seed()
    {
        Login login = new();
        await login.LoginUser(_client);

        if (await CheckIfSeedingIsNeeded())
        {
            await CheckIfRoleExisits();
            Logger.LogDebug("Seeding is Needed.");

            var countUser = 20;
            var rules = new Rules();

            var userFaker = rules.UserRules();
            var userIds = await GenerateUsers(userFaker, countUser);

            var forumFaker = rules.ForumRules(userIds);
            var forumIds = await GenerateForums(forumFaker, countUser * 2);

            var postFaker = rules.PostRules(userIds, forumIds);
            var postIds = await GeneratePosts(postFaker, countUser * 4);

            var commentFaker = rules.CommentRules(userIds, postIds);
            await GenereateComments(commentFaker, countUser * 6);

            var followerUserRelationFaker = rules.FollowerUserRelationRules(userIds);
            await GenerateFollowerUserRelation(followerUserRelationFaker, userIds.Count * (userIds.Count - 1));

            var userLikePostRelationFaker = rules.UserLikePostRelationRules(userIds, postIds);
            await GenerateUserLikePostRelation(userLikePostRelationFaker, userIds.Count * postIds.Count / 2);

            Logger.LogDebug("Database seeded with random data.");
        }
        else
        {
            Logger.LogDebug("Seeding is not needed.");
        }

        await login.LogoutUser(_client);
    }

    private async Task<bool> CheckIfSeedingIsNeeded()
    {
        var userRepository = new UserRepository(_client, _daoHelper, _databaseRepositroyHelper);
        try
        {
            Logger.LogInfo("Checking if seeding is needed.");
            var result = await userRepository.GetAllElements();
            if (result.Count < 10)
                return true;
            return false;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "An exception occurred.");
            throw;
        }
    }

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
            {
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