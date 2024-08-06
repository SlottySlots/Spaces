namespace SlottyMedia.Backend.Dtos;

/// <summary>
/// The Profile Picture Data Transfer Object
/// </summary>
public class ProfilePicDto
{
    /// <summary>
    /// The User Id
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// The Profile Picture in binary
    /// </summary>
    public long ProfilePic { get; set; }
}