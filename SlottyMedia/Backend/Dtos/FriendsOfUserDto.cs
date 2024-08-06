namespace SlottyMedia.Backend.Dtos;

/// <summary>
/// The Friends of a User
/// </summary>
public class FriendsOfUserDto
{
    /// <summary>
    /// The User Id
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// The Friends of the User
    /// </summary>
    public List<UserDto> Friends { get; set; }
}