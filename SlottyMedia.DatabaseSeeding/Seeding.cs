using Bogus;
using NLog;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;

namespace SlottyMedia.DatabaseSeeding;

public class Seeding
{
    private readonly IDatabaseActions _databaseActions;
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();


    public Seeding(IDatabaseActions databaseActions)
    {
        _databaseActions = databaseActions;
    }

    public async Task Seed(IDatabaseActions databaseActions)
    {
        Logger.Debug("Checking if seeding is needed.");
        if (await CheckIfSeedingIsNeeded())
        {
            await CheckIfRoleExisits();
            Logger.Debug("Seeding is Needed.");

            var countUser = 10;
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

            Logger.Debug("Database seeded with random data.");
        }
        else
        {
            Logger.Debug("Seeding is not needed.");
        }
    }

    private async Task<bool> CheckIfSeedingIsNeeded()
    {
        var result = await _databaseActions.GetEntities<UserDao>();
        if (result.Count < 10)
            return true;
        return false;
    }

    private async Task<List<Guid>> GenerateUsers(Faker<UserDao> userFaker, int amount)
    {
        // Generate and insert users
        Logger.Debug("Generating and seeding random user data.");
        var users = userFaker.Generate(amount);
        var userIds = new List<Guid>();
        for (var i = 0; i < users.Count; i++)
        {
            var user = await _databaseActions.Insert(users[i]);
            userIds.Add(user.UserId ?? Guid.Empty);
            Logger.Debug("User seeded: " + user.UserName);
        }
        
        Logger.Debug("Database seeded with random user data.");
        return userIds;
    }

    private async Task<List<Guid>> GenerateForums(Faker<ForumDao> forumFaker, int amount)
    {
        // Generate and insert forums
        Logger.Debug("Generating and seeding random forum data.");
        var forums = forumFaker.Generate(amount);
        var forumIds = new List<Guid>();
        for (var i = 0; i < forums.Count; i++)
        {
            var forum = await _databaseActions.Insert(forums[i]);
            forumIds.Add(forum.ForumId ?? Guid.Empty);
            Logger.Debug("Forum seeded: " + forum.ForumTopic);
        }
        
        Logger.Debug("Database seeded with random forum data.");
        return forumIds;
    }

    private async Task<List<Guid>> GeneratePosts(Faker<PostsDao> postFaker, int amount)
    {
        // Generate and insert posts
        Logger.Debug("Generating and seeding random post data.");
        var posts = postFaker.Generate(amount);
        var postIds = new List<Guid>();
        for (var i = 0; i < posts.Count; i++)
        {
            var post = await _databaseActions.Insert(posts[i]);
            postIds.Add(post.PostId ?? Guid.Empty);
            Logger.Debug("Post seeded: " + post.Headline);
        }
        
        Logger.Debug("Database seeded with random post data.");
        return postIds;
    }

    private async Task GenereateComments(Faker<CommentDao> commentFaker, int amount)
    {
        // Generate and insert comments
        Logger.Debug("Generating and seeding random comment data.");
        var comments = commentFaker.Generate(amount);
        for (var i = 0; i < comments.Count; i++)
        {
            var comment = await _databaseActions.Insert(comments[i]);
            Logger.Debug("Comment seeded: " + comment.Content);
        }
        
        Logger.Debug("Database seeded with random comment data.");
    }

    private async Task GenerateFollowerUserRelation(Faker<FollowerUserRelationDao> followerUserRelationFaker,
        int amount)
    {
        // Generate and insert follower user relations
        Logger.Debug("Generating and seeding random follower user relation data.");
        var followerUserRelations = followerUserRelationFaker.Generate(amount);
        for (var i = 0; i < followerUserRelations.Count; i++)
        {
            var followerUserRelation = await _databaseActions.Insert(followerUserRelations[i]);
            Logger.Debug("FollowerUserRelation seeded. Follower: " + followerUserRelation.FollowerUserId +
                         " Followed: " + followerUserRelation.FollowedUserId);
        }

        Logger.Debug("Database seeded with random follower user relation data.");
    }

    private async Task GenerateUserLikePostRelation(Faker<UserLikePostRelationDao> userLikePostRelationFaker,
        int amount)
    {
        // Generate and insert user like post relations
        Logger.Debug("Generating and seeding random user like post relation data.");
        var userLikePostRelations = userLikePostRelationFaker.Generate(amount);
        for (var i = 0; i < userLikePostRelations.Count; i++)
        {
            var userLikePostRelation = await _databaseActions.Insert(userLikePostRelations[i]);
            Logger.Debug("UserLikePostRelation seeded. User: " + userLikePostRelation.UserId + " Post: " +
                         userLikePostRelation.PostId);
        }

        Logger.Debug("Database seeded with random user like post relation data.");
    }

    private async Task CheckIfRoleExisits()
    {
        var roleId = "c0589855-a81c-451d-8587-3061926a1f3a";
        Logger.Debug("Checking if role exists.");
        try
        {
            var result = await _databaseActions.GetEntityByField<RoleDao>("roleID", roleId);
        }
        catch (DatabaseMissingItemException e)
        {
            var role = new RoleDao
            {
                RoleId = Guid.Parse(roleId),
                RoleName = "User",
                Description = "User"
            };

            await _databaseActions.Insert(role);
        }
        catch (GeneralDatabaseException e)
        {
            Logger.Error(e, "An exception occurred.");
            throw;
        }
        
    }
}