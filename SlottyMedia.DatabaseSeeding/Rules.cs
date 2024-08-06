using Bogus;
using SlottyMedia.Database.Daos;

namespace SlottyMedia.DatabaseSeeding;

public class Rules
{
    /// <summary>
    /// This method creates the rules for the UserDao.
    /// </summary>
    /// <returns></returns>
    public Faker<UserDao> UserRules()
    {
        var userFaker = new Faker<UserDao>()
            .RuleFor(u => u.UserId, f => f.Random.Guid().ToString())
            .RuleFor(u => u.RoleId, "c0589855-a81c-451d-8587-3061926a1f3a")
            .RuleFor(u => u.UserName, f => f.Internet.UserName())
            .RuleFor(u => u.Description, f => f.Lorem.Sentence())
            .RuleFor(u => u.ProfilePic, f => f.Random.Long(1, 1000))
            .RuleFor(u => u.CreatedAt, f => f.Date.Past());
        return userFaker;
    }

    /// <summary>
    /// This method creates the rules for the ForumDao.
    /// </summary>
    /// <param name="userFaker"></param>
    /// <returns></returns>
    public Faker<ForumDao> ForumRules(Faker<UserDao> userFaker)
    {
        var forumFaker = new Faker<ForumDao>()
            .RuleFor(f => f.ForumId, f => f.Random.Guid().ToString())
            .RuleFor(f => f.CreatorUserId, f => userFaker.Generate().UserId)
            .RuleFor(f => f.ForumTopic, f => f.Lorem.Sentence())
            .RuleFor(f => f.CreatedAt, f => f.Date.Past());
        return forumFaker;
    }

    /// <summary>
    /// This method creates the rules for the PostsDto.
    /// </summary>
    /// <param name="userFaker"></param>
    /// <param name="forumFaker"></param>
    /// <returns></returns>
    public Faker<PostsDto> PostRules(Faker<UserDao> userFaker, Faker<ForumDao> forumFaker)
    {
        var postFaker = new Faker<PostsDto>()
            .RuleFor(p => p.PostId, f => f.Random.Guid().ToString())
            .RuleFor(p => p.UserId, f => userFaker.Generate().UserId)
            .RuleFor(p => p.ForumId, f => forumFaker.Generate().ForumId)
            .RuleFor(p => p.Headline, f => f.Lorem.Sentence())
            .RuleFor(p => p.Content, f => f.Lorem.Paragraphs())
            .RuleFor(p => p.CreatedAt, f => f.Date.Past());
        return postFaker;
    }

    /// <summary>
    /// This method creates the rules for the CommentDto.
    /// </summary>
    /// <param name="userFaker"></param>
    /// <param name="postFaker"></param>
    /// <returns></returns>
    public Faker<CommentDao> CommentRules(Faker<UserDao> userFaker, Faker<PostsDto> postFaker)
    {
        var commentFaker = new Faker<CommentDao>()
            .RuleFor(c => c.CommentId, f => f.Random.Guid().ToString())
            .RuleFor(c => c.CreatorUserId, f => userFaker.Generate().UserId)
            .RuleFor(c => c.PostId, f => postFaker.Generate().PostId)
            .RuleFor(c => c.Content, f => f.Lorem.Paragraph())
            .RuleFor(c => c.CreatedAt, f => f.Date.Past());
        return commentFaker;
    }

    /// <summary>
    /// This method creates the rules for the FollowerUserRelationDao.
    /// </summary>
    /// <param name="userFaker"></param>
    /// <returns></returns>
    public Faker<FollowerUserRelationDao> FollowerUserRelationRules(Faker<UserDao> userFaker)
    {
        var followerUserRelationFaker = new Faker<FollowerUserRelationDao>()
            .RuleFor(f => f.FollowerUserRelationId, f => f.Random.Guid().ToString())
            .RuleFor(f => f.FollowerUserId, f => userFaker.Generate().UserId)
            .RuleFor(f => f.FollowedUserId, f => userFaker.Generate().UserId)
            .RuleFor(f => f.CreatedAt, f => f.Date.Past());
        return followerUserRelationFaker;
    }

    /// <summary>
    /// This method creates the rules for the UserLikePostRelationDao.
    /// </summary>
    /// <param name="userFaker"></param>
    /// <param name="postFaker"></param>
    /// <returns></returns>
    public Faker<UserLikePostRelationDao> UserLikePostRelationRules(Faker<UserDao> userFaker, Faker<PostsDto> postFaker)
    {
        var userLikePostRelationFaker = new Faker<UserLikePostRelationDao>()
            .RuleFor(ul => ul.UserLikePostRelationId, f => f.Random.Guid().ToString())
            .RuleFor(ul => ul.UserId, f => userFaker.Generate().UserId)
            .RuleFor(ul => ul.PostId, f => postFaker.Generate().PostId)
            .RuleFor(ul => ul.CreatedAt, f => f.Date.Past());
        return userLikePostRelationFaker;
    }
}