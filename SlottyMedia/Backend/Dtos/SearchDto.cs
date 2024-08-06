namespace SlottyMedia.Backend.Dtos;

/// <summary>
/// The Search Data Transfer Object
/// </summary>
public class SearchDto
{
    /// <summary>
    /// The Users who mach the search
    /// </summary>
    public UserDto Users { get; set; }

    /// <summary>
    /// The Forum that match the search
    /// </summary>
    public ForumDto Forum { get; set; }
}