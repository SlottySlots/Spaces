using SlottyMedia.Database.Daos;

namespace SlottyMedia.Database.Repository.ForumRepo;

public interface IForumRepository : IDatabaseRepository<ForumDao>
{
    public Task<ForumDao> GetElementById(string forumName);
}