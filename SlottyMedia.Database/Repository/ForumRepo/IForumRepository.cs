using SlottyMedia.Database.Daos;

namespace SlottyMedia.Database.Repository.ForumRepo;

/// <summary>
///     Interface for the Forum Repository.
/// </summary>
public interface IForumRepository : IDatabaseRepository<ForumDao>
{
    /// <summary>
    ///     Fetches a forum by its name.
    /// </summary>
    /// <param name="name">The forum's name</param>
    /// <returns>The forum</returns>
    Task<ForumDao> GetForumByName(string name);
}