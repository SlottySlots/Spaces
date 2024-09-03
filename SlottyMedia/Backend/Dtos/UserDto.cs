using SlottyMedia.Database.Daos;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Dtos;

/// <summary>
///     The User Data Transfer Object
/// </summary>
public class UserDto
{
    private static readonly Logging<UserDto> Logger = new();


    /// <summary>
    ///     Initializes a new instance of the <see cref="UserDto" /> class.
    /// </summary>
    public UserDto()
    {
        UserId = Guid.Empty;
        Username = string.Empty;
        Description = string.Empty;
        CreatedAt = DateTime.MinValue;
        RecentForums = new List<string>();
    }

    /// <summary>
    ///     Gets or sets the User Id.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    ///     Gets or sets the Username.
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    ///     Gets or sets the Description of the User.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    ///     Gets or sets the date and time when the User was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    ///     Gets or sets a list of the recent forums the User has visited.
    /// </summary>
    public List<string> RecentForums { get; set; }

    /// <summary>
    ///     This method maps the User Dto to the User Dao.
    /// </summary>
    /// <returns></returns>
    public UserDao Mapper()
    {
        Logger.LogInfo($"Mapping UserDto to UserDao. UserDto: {this}");

        return new UserDao
        {
            UserId = UserId,
            UserName = Username,
            Description = Description,
            CreatedAt = CreatedAt
        };
    }

    /// <summary>
    ///     Maps the User Dao to the User Dto.
    /// </summary>
    /// <param name="user"></param>
    public UserDto Mapper(UserDao user)
    {
        Logger.LogInfo($"Mapping UserDao to UserDto. UserDao: {user}");

        UserId = user.UserId ?? Guid.Empty;
        Username = user.UserName ?? string.Empty;
        Description = user.Description ?? string.Empty;
        CreatedAt = user.CreatedAt.LocalDateTime;
        return this;
    }

    /// <summary>
    ///     This method returns the UserDto as a string.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"UserId: {UserId}, Username: {Username}, Description: {Description}, CreatedAt: {CreatedAt}";
    }
}