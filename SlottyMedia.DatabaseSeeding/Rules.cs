using Bogus;
using SlottyMedia.Database.Daos;

namespace SlottyMedia.DatabaseSeeding;

/// <summary>
///     The Rules class contains methods to create Faker objects with predefined rules for generating fake Dao objects.
/// </summary>
public class Rules
{
    /// <summary>
    ///     Creates the rules for generating fake UserDao objects.
    ///     - UserId: Randomly generated GUID.
    ///     - RoleId: Fixed GUID value.
    ///     - UserName: Randomly generated internet username.
    ///     - Description: Randomly generated sentence.
    ///     - ProfilePic: Randomly generated long value between 1 and 1000.
    ///     - CreatedAt: Randomly generated past date.
    /// </summary>
    /// <returns>A Faker&lt;\<see cref="UserDao" />&gt; object with predefined rules.</returns>
    public Faker<UserDao> UserRules()
    {
        var existingUserIds = new HashSet<Guid>();
        var existingEmails = new HashSet<string>();
        var existingUserNames = new HashSet<string>();
        var userFaker = new Faker<UserDao>("de")
            .RuleFor(u => u.UserId, f =>
            {
                Guid userId;
                do
                {
                    userId = f.Random.Guid();
                } while (existingUserIds.Contains(userId));
                existingUserIds.Add(userId);
                return userId;
            })
            .RuleFor(u => u.RoleId, Guid.Parse("c0589855-a81c-451d-8587-3061926a1f3a"))
            .RuleFor(u => u.UserName, f =>
            {
                string userName;
                do
                {
                    userName = f.Internet.UserName();
                } while (existingUserNames.Contains(userName));
                existingUserNames.Add(userName);
                return userName;
            })
            .RuleFor(u => u.Description, f => f.WaffleTitle())
            .RuleFor(u => u.ProfilePic, f => null)
            .RuleFor(u => u.CreatedAt, f => f.Date.Past())
            .RuleFor(u => u.Email, f =>
            {
                string email;
                do
                {
                    email = f.Internet.Email();
                } while (existingEmails.Contains(email));
                existingEmails.Add(email);
                return email;
            });
        return userFaker;
    }

    /// <summary>
    ///     Creates the rules for generating fake ForumDao objects.
    ///     - ForumId: Randomly generated GUID.
    ///     - CreatorUserId: Randomly selected from provided user IDs.
    ///     - ForumTopic: Randomly generated sentence.
    ///     - CreatedAt: Randomly generated past date.
    /// </summary>
    /// <param name="userIds">A list of user IDs to associate with the forums.</param>
    /// <returns>A Faker&lt;\<see cref="ForumDao" />&gt; object with predefined rules.</returns>
    public Faker<ForumDao> ForumRules(List<Guid> userIds)
    {
        var existingForumIds = new HashSet<Guid>();
        var existingForumTopics = new HashSet<string>();
    
        var forumFaker = new Faker<ForumDao>()
            .RuleFor(f => f.ForumId, f =>            {
                Guid forumId;
                do
                {
                    forumId = f.Random.Guid();
                } while (existingForumIds.Contains(forumId));
                existingForumIds.Add(forumId);
                return forumId;
            })
            .RuleFor(f => f.CreatorUserId, f => userIds[f.Random.Int(0, userIds.Count - 1)])
            .RuleFor(f => f.ForumTopic, f =>  {
                string forumTopic;
                do
                {
                    forumTopic = f.Internet.DomainWord();
                } while (existingForumTopics.Contains(forumTopic));
                existingForumTopics.Add(forumTopic);
                return forumTopic;
            })
            .RuleFor(f => f.CreatedAt, f => f.Date.Past());
        return forumFaker;
    }

    /// <summary>
    ///     Creates the rules for generating fake PostsDao objects.
    ///     - PostId: Randomly generated GUID.
    ///     - UserId: Randomly selected from provided user IDs.
    ///     - ForumId: Randomly selected from provided forum IDs.
    ///     - Headline: Randomly generated sentence.
    ///     - Content: Randomly generated paragraphs.
    ///     - CreatedAt: Randomly generated past date.
    /// </summary>
    /// <param name="userIds">A list of user IDs to associate with the posts.</param>
    /// <param name="forumIds">A list of forum IDs to associate with the posts.</param>
    /// <returns>A Faker&lt;\<see cref="PostsDao" />&gt; object with predefined rules.</returns>
    public Faker<PostsDao> PostRules(List<Guid> userIds, List<Guid> forumIds)
    {
        var existingPostIds = new HashSet<Guid>();
        var postFaker = new Faker<PostsDao>()
            .RuleFor(p => p.PostId, f => {
                Guid postId;
                do
                {
                    postId = f.Random.Guid();
                } while (existingPostIds.Contains(postId));
                existingPostIds.Add(postId);
                return postId;
            })
            .RuleFor(p => p.UserId, f => userIds[f.Random.Int(0, userIds.Count - 1)])
            .RuleFor(p => p.ForumId, f => forumIds[f.Random.Int(0, forumIds.Count - 1)])
            .RuleFor(p => p.Headline, f => f.Lorem.Sentence())
            .RuleFor(p => p.Content, f => f.WaffleText(f.Random.Int(1, 3), false))
            .RuleFor(p => p.CreatedAt, f => f.Date.Past());
        return postFaker;
    }

    /// <summary>
    ///     Creates the rules for generating fake CommentDao objects.
    ///     - CommentId: Randomly generated GUID.
    ///     - CreatorUserId: Randomly selected from provided user IDs.
    ///     - PostId: Randomly selected from provided post IDs.
    ///     - Content: Randomly generated paragraph.
    ///     - CreatedAt: Randomly generated past date.
    /// </summary>
    /// <param name="userIds">A list of user IDs to associate with the comments.</param>
    /// <param name="postIds">A list of post IDs to associate with the comments.</param>
    /// <returns>A Faker&lt;\<see cref="CommentDao" />&gt; object with predefined rules.</returns>
    public Faker<CommentDao> CommentRules(List<Guid> userIds, List<Guid> postIds)
    {
        var existingCommentIds = new HashSet<Guid>();

        var commentFaker = new Faker<CommentDao>()
            .RuleFor(c => c.CommentId, f => {
                Guid commentId;
                do
                {
                    commentId = f.Random.Guid();
                } while (existingCommentIds.Contains(commentId));
                existingCommentIds.Add(commentId);
                return commentId;
            })
            .RuleFor(c => c.CreatorUserId, f => userIds[f.Random.Int(0, userIds.Count - 1)])
            .RuleFor(c => c.PostId, f => postIds[f.Random.Int(0, userIds.Count - 1)])
            .RuleFor(c => c.Content, f => f.Lorem.Paragraph())
            .RuleFor(c => c.CreatedAt, f => f.Date.Past());
        return commentFaker;
    }

    /// <summary>
    ///     Creates the rules for generating fake FollowerUserRelationDao objects.
    ///     - FollowerUserRelationId: Randomly generated GUID.
    ///     - FollowerUserId: Randomly selected from provided user IDs, ensuring no duplicate relations.
    ///     - FollowedUserId: Randomly selected from provided user IDs, ensuring no duplicate relations.
    ///     - CreatedAt: Randomly generated past date.
    /// </summary>
    /// <param name="userIds">A list of user IDs to associate with the follower relations.</param>
    /// <returns>A Faker&lt;\<see cref="FollowerUserRelationDao" />&gt; object with predefined rules.</returns>
    /// <exception cref="ArgumentException">Thrown when less than two user IDs are provided.</exception>
    public Faker<FollowerUserRelationDao> FollowerUserRelationRules(List<Guid> userIds)
    {
        if (userIds.Count < 2)
            throw new ArgumentException("At least two userIds are required to generate follower relations.");

        var exisitingFollowerUserRelationId = new HashSet<Guid>();
        var existingRelations = new HashSet<(Guid, Guid)>();
        var followerUserRelationFaker = new Faker<FollowerUserRelationDao>()
            .RuleFor(f => f.FollowerUserRelationId, f => {
                Guid followerUserRelationId;
                do
                {
                    followerUserRelationId = f.Random.Guid();
                } while (exisitingFollowerUserRelationId.Contains(followerUserRelationId));
                exisitingFollowerUserRelationId.Add(followerUserRelationId);
                return followerUserRelationId;
            })
            .RuleFor(f => f.FollowerUserId, f =>
            {
                Guid followerId;
                Guid followedId;
                do
                {
                    followerId = userIds[f.Random.Int(0, userIds.Count - 1)];
                    followedId = userIds[f.Random.Int(0, userIds.Count - 1)];
                } while (followerId == followedId || existingRelations.Contains((followerId, followedId)));

                existingRelations.Add((followerId, followedId));
                return followerId;
            })
            .RuleFor(f => f.FollowedUserId,
                (f, relation) =>
                {
                    return existingRelations.FirstOrDefault(r => r.Item1 == relation.FollowerUserId).Item2;
                })
            .RuleFor(f => f.CreatedAt, f => f.Date.Past());

        return followerUserRelationFaker;
    }

    /// <summary>
    ///     Creates the rules for generating fake UserLikePostRelationDao objects.
    ///     - UserLikePostRelationId: Randomly generated GUID.
    ///     - UserId: Randomly selected from provided user IDs, ensuring no duplicate relations.
    ///     - PostId: Randomly selected from provided post IDs, ensuring no duplicate relations.
    ///     - CreatedAt: Randomly generated past date.
    /// </summary>
    /// <param name="userIds">A list of user IDs to associate with the like relations.</param>
    /// <param name="postIds">A list of post IDs to associate with the like relations.</param>
    /// <returns>A Faker&lt;\<see cref="UserLikePostRelationDao" />&gt; object with predefined rules.</returns>
    public Faker<UserLikePostRelationDao> UserLikePostRelationRules(List<Guid> userIds, List<Guid> postIds)
    {
        var existingUserLikePostRelationIds = new HashSet<Guid>();
        var existingRelations = new HashSet<(Guid, Guid)>();
        var userLikePostRelationFaker = new Faker<UserLikePostRelationDao>()
            .RuleFor(ul => ul.UserLikePostRelationId, f => {
                Guid userLikePostRelationIds;
                do
                {
                    userLikePostRelationIds = f.Random.Guid();
                } while (existingUserLikePostRelationIds.Contains(userLikePostRelationIds));
                existingUserLikePostRelationIds.Add(userLikePostRelationIds);
                return userLikePostRelationIds;
            })
            .RuleFor(ul => ul.UserId, f =>
            {
                Guid userId;
                Guid postId;
                do
                {
                    userId = userIds[f.Random.Int(0, userIds.Count - 1)];
                    postId = postIds[f.Random.Int(0, postIds.Count - 1)];
                } while (existingRelations.Contains((userId, postId)));

                existingRelations.Add((userId, postId));
                return userId;
            })
            .RuleFor(ul => ul.PostId,
                (f, relation) => { return existingRelations.FirstOrDefault(r => r.Item1 == relation.UserId).Item2; })
            .RuleFor(ul => ul.CreatedAt, f => f.Date.Past());

        return userLikePostRelationFaker;
    }
}