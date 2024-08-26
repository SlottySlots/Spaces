using SlottyMedia.Database.Daos;

namespace SlottyMedia.Database.Repository.PostRepo;

public interface IPostRepository : IDatabaseRepository<PostsDao>
{
    public Task<int> GetForumCountByUserId(Guid userId);

    public Task<List<PostsDao>> GetAllElements(int page, int pageSize);

    public Task<List<PostsDao>> GetPostsByUserId(Guid userId, int page, int pageSize);

    public Task<List<PostsDao>> GetPostsByUserIdByForumId(Guid userId, Guid forumId, int page, int pageSize);

    public Task<List<PostsDao>> GetPostsByForumId(Guid forumId, int page, int pageSize);
}