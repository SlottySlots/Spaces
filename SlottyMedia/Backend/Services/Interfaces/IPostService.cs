namespace SlottyMedia.Backend.Services.Interfaces;

/// <summary>
/// Interface for post-related services.
/// </summary>
public interface IPostService
{
    /// <summary>
    /// Retrieves a list of post titles from a forum for a given user, limited by the specified number.
    /// </summary>
    /// <param name="userID">The ID of the user.</param>
    /// <param name="limit">The maximum number of posts to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of post titles.</returns>
    internal Task<List<string>> GetPostsFromForum(Guid userID, int limit);
}