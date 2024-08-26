using SlottyMedia.Database.Daos;

namespace SlottyMedia.Database.Repository.ForumRepo;

public interface ITopForumRepository : IDatabaseRepository<TopForumDao>
{
    public Task<List<TopForumDao>> DetermineRecentSpaces();

    public Task<List<TopForumDao>> GetTopForums();
}