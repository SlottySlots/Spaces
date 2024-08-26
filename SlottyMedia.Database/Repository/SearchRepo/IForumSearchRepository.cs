using SlottyMedia.Database.Daos;

namespace SlottyMedia.Database.Repository.SearchRepo;

/// <summary>
///     Interface for the Forum Search Repository.
/// </summary>
public interface IForumSearchRepository : IDatabaseRepository<ForumDao>
{
    /// <summary>
    ///     Gets forums by a specific topic with pagination.
    /// </summary>
    /// <param name="topic">The topic to search for.</param>
    /// <param name="page">The page number.</param>
    /// <param name="pageSize">The size of the page.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of forums.</returns>
    public Task<List<ForumDao>> GetForumsByTopic(string topic, int page, int pageSize);
}