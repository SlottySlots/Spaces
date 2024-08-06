namespace SlottyMedia.Backend.Dtos;

/// <summary>
/// The Profile Picture Data Transfer Object
/// </summary>
public class ProfilePicDto
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProfilePicDto"/> class.
    /// </summary>
    public ProfilePicDto()
    {
        UserId = Guid.Empty;
        ProfilePic = 0;
    }

    /// <summary>
    /// Gets or sets the User Id.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the Profile Picture in binary.
    /// </summary>
    public long ProfilePic { get; set; }
}