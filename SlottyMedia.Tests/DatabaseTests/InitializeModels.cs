using SlottyMedia.Database.Daos;

namespace SlottyMedia.Tests.DatabaseTests;

/// <summary>
///     This class initializes the models for the database tests.
/// </summary>
public static class InitializeModels
{
    /// <summary>
    ///     This method initializes a RoleDto for the tests.
    /// </summary>
    /// <returns></returns>
    public static RoleDao GetRoleDto()
    {
        return new RoleDao
        {
            RoleId = Guid.Parse("c0589855-a81c-451d-8587-3061926a1f3a"),
            RoleName = "User",
            Description = "User"
        };
    }

    /// <summary>
    ///     This method initializes a UserDto for the tests.
    /// </summary>
    /// <param name="userID"></param>
    /// <returns></returns>
    public static UserDao GetUserDto(Guid userID)
    {
        return new UserDao
        {
            UserId = userID == default ? Guid.NewGuid() : userID,
            UserName = Guid.NewGuid().ToString(),
            Description = "Please don't delete me",
            RoleId = GetRoleDto().RoleId,
            Email = Guid.NewGuid() + "@test.de"
        };
    }

    /// <summary>
    ///     This method initializes a ForumDto for the tests.
    /// </summary>
    /// <param name="userDao"></param>
    /// <returns></returns>
    public static ForumDao GetForumDto(UserDao userDao)
    {
        return new ForumDao
        {
            CreatorUserId = userDao.UserId,
            ForumTopic = "I'm a Test Forum"
        };
    }

    /// <summary>
    ///     This method initializes a PostsDto for the tests.
    /// </summary>
    /// <param name="forumDao"></param>
    /// <param name="userDao"></param>
    /// <returns></returns>
    public static PostsDao GetPostsDto(ForumDao forumDao, UserDao userDao)
    {
        return new PostsDao
        {
            ForumId = forumDao.ForumId,
            UserId = userDao.UserId,
            Headline = "I'm a Test Posts Headline",
            Content = "I'm a Test Post"
        };
    }
}