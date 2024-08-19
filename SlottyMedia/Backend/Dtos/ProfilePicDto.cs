using SlottyMedia.Database.Daos;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Dtos;

/// <summary>
///     The Profile Picture Data Transfer Object
/// </summary>
public class ProfilePicDto
{
    private static readonly Logging<ProfilePicDto> Logger =new ();
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="ProfilePicDto" /> class.
    /// </summary>
    public ProfilePicDto()
    {
        UserId = Guid.Empty;
        ProfilePic = 0;
    }

    /// <summary>
    ///     Gets or sets the User Id.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    ///     Gets or sets the Profile Picture in binary.
    /// </summary>
    public long ProfilePic { get; set; }

    /// <summary>
    ///     This method maps the ProfilePicDto to a UserDao.
    /// </summary>
    /// <returns></returns>
    public UserDao Mapper()
    {
        Logger.LogInfo($"Mapping ProfilePicDto to UserDao. ProfilePicDto: {this}");
        
        return new UserDao
        {
            UserId = UserId,
            ProfilePic = ProfilePic
        };
    }

    /// <summary>
    ///     This method maps the UserDao to a ProfilePicDto.
    /// </summary>
    /// <param name="userDao"></param>
    /// <returns></returns>
    public ProfilePicDto Mapper(UserDao userDao)
    {
        Logger.LogInfo($"Mapping UserDao to ProfilePicDto. UserDao: {userDao}");
        
        return new ProfilePicDto
        {
            UserId = userDao.UserId ?? Guid.Empty,
            ProfilePic = userDao.ProfilePic ?? 0
        };
    }

    public override string ToString()
    {
        return $"UserId: {UserId}, ProfilePic: {ProfilePic}";
    }
}