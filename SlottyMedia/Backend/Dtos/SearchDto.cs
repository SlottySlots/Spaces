namespace SlottyMedia.Backend.Dtos;

/// <summary>
///     The Search Data Transfer Object
/// </summary>
public class SearchDto
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="SearchDto" /> class.
    /// </summary>
    public SearchDto()
    {
        Users = new List<UserDto>();
        Forums = new List<ForumDto>();
    }

    /// <summary>
    ///     Gets or sets the users who match the search.
    /// </summary>
    public List<UserDto> Users { get; set; }

    /// <summary>
    ///     Gets or sets the forum that matches the search.
    /// </summary>
    public List<ForumDto> Forums { get; set; }

    /// <summary>
    /// This method returns the SearchDto as a string.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"Users: {Users}, Forums: {Forums}";
    }
}