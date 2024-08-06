namespace SlottyMedia.Backend.Dtos;

/// <summary>
/// The User Data Transfer Object
/// </summary>
public class UserDto
{
    /// <summary>
    /// The User Id
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// The Username
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// The Description of the User
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// When the User was created
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// A list of the recent forums the User has visited
    /// </summary>
    public List<string> RecentForums { get; set; }
}