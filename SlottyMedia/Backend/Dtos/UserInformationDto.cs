using SlottyMedia.Database.Daos;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Dtos;

/// <summary>
///     The User Information Data Transfer Object. It differs to UserDto by not persisting recentForums.
/// </summary>
public class UserInformationDto
{
    private static readonly Logging<UserInformationDto> Logger = new();

    /// <summary>
    ///     Initializes a new instance of the <see cref="UserInformationDto" /> class.
    /// </summary>
    public UserInformationDto(bool isLoading = false)
    {
        if (isLoading)
        {
            Username = "Username is loading..";
            Description = "Description is loading..";
            ProfilePic = null;
        }
        else
        {
            Username = string.Empty;
            Description = string.Empty;
            ProfilePic = null;
        }
        UserId = Guid.Empty;
        CreatedAt = DateTime.MinValue;
    }


    /// <summary>
    ///     Gets or sets the User Id.
    /// </summary>
    public Guid? UserId { get; set; }

    /// <summary>
    ///     Gets or sets the Username.
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    ///     Gets or sets the Description of the User.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    ///     ProfilePic of a user
    /// </summary>
    public string? ProfilePic { get; set; }

    /// <summary>
    ///     Amount of Follow4Follows of User
    /// </summary>
    public int FriendsAmount { get; set; }

    /// <summary>
    ///     Amount of Spaces of a User
    /// </summary>
    public int SpacesAmount { get; set; }

    /// <summary>
    ///     Gets or sets the date and time when the User was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }


    /// <summary>
    ///     This method maps the UserInformationDto to the User Dao.
    /// </summary>
    /// <returns></returns>
    public UserDao Mapper()
    {
        Logger.LogTrace($"Mapping UserInformationDto to UserDao. UserInformationDto: {this}");

        return new UserDao
        {
            UserId = UserId,
            UserName = Username,
            Description = Description,
            ProfilePic = ProfilePic,
            CreatedAt = CreatedAt
        };
    }

    /// <summary>
    ///     Maps the User Dao to the UserInformationDto.
    /// </summary>
    /// <param name="user"></param>
    public UserInformationDto Mapper(UserDao user)
    {
        Logger.LogTrace($"Mapping UserDao to UserInformationDto. UserDao: {user}");

        UserId = user.UserId ?? Guid.Empty;
        Username = user.UserName ?? string.Empty;
        Description = user.Description ?? string.Empty;
        ProfilePic = user.ProfilePic;
        CreatedAt = user.CreatedAt.LocalDateTime;
        return this;
    }
}