using SlottyMedia.Database.Daos;

namespace SlottyMedia.Database.Repository.ForumRepo;

/// <summary>
///     Interface for the Top Forum Repository.
/// </summary>
public interface ITopForumRepository : IDatabaseRepository<TopForumDao>
{
    /// <summary>
    ///     Determines the recent spaces.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of recent spaces.</returns>
    public Task<List<TopForumDao>> DetermineRecentSpaces();

    /// <summary>
    ///     Gets the top forums.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of top forums.</returns>
    public Task<List<TopForumDao>> GetTopForums();
}