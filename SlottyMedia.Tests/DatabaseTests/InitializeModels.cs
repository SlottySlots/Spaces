using SlottyMedia.Database.Daos;

namespace SlottyMedia.Tests.DatabaseTests;

/// <summary>
/// This class initializes the models for the database tests.
/// </summary>
public static class InitializeModels
{
    private static RoleDao GetRoleDto()
    {
        return new RoleDao
        {
            RoleId = "c0589855-a81c-451d-8587-3061926a1f3a",
            RoleName = "User",
            Description = "User"
        };
    }

    public static UserDao GetUserDto()
    {
        return new UserDao
        {
            UserId = Guid.NewGuid().ToString(),
            UserName = "I'm a Test User",
            Description = "Please don't delete me",
            RoleId = GetRoleDto().RoleId
        };
    }

    public static ForumDao GetForumDto(UserDao userDao)
    {
        return new ForumDao
        {
            CreatorUserId = userDao.UserId,
            ForumTopic = "I'm a Test Forum"
        };
    }

    public static PostsDto GetPostsDto(ForumDao forumDao, UserDao userDao)
    {
        return new PostsDto
        {
            ForumId = forumDao.ForumId,
            UserId = userDao.UserId,
            Headline = "I'm a Test Posts Headline",
            Content = "I'm a Test Post"
        };
    }
}