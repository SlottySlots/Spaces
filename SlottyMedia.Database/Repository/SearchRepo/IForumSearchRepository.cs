using SlottyMedia.Database.Daos;

namespace SlottyMedia.Database.Repository;

public interface IForumSearchRepository : IDatabaseRepository<ForumDao>
{
    public Task<List<ForumDao>> GetForumsByTopic(string topic, int page, int pageSize);

}