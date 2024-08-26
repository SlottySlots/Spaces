using SlottyMedia.Database.Daos;

namespace SlottyMedia.Database.Repository.FollowerUserRelatioRepo;

public interface IFollowerUserRelationRepository : IDatabaseRepository<FollowerUserRelationDao>
{
    public Task<int> GetCountOfUserFriends(Guid userId);

    public Task<List<FollowerUserRelationDao>> GetFriends(Guid userId);
}