using SlottyMedia.Backend.Models;
using SlottyMedia.Database.Models;

namespace SlottyMedia.Tests.DatabaseTests;

/// <summary>
/// This class initializes the models for the database tests.
/// </summary>
public class InitializeModels
{
    public static RoleDto GetRoleDto()
    {
        return new RoleDto()
        {
            RoleId = "c0589855-a81c-451d-8587-3061926a1f3a",
            RoleName = "User",
            Description = "User"
        };
    }

    public static UserDto GetUserDto()
    {
        return new UserDto()
        {
            UserId = Guid.NewGuid().ToString(),
            UserName = "I'm a Test User",
            Description = "Please don't delete me",
            RoleId = GetRoleDto().RoleId
        };
    }

    public static ForumDto GetForumDto(UserDto userDto)
    {
        return new ForumDto()
        {
            CreatorUserId = userDto.UserId,
            ForumTopic = "I'm a Test Forum"
        };
    }

    public static PostsDto GetPostsDto(ForumDto forumDto, UserDto userDto)
    {
        return new PostsDto()
        {
            ForumId = forumDto.ForumId,
            UserId = userDto.UserId,
            Headline = "I'm a Test Posts Headline",
            Content = "I'm a Test Post"
        };
    }
}