using SlottyMedia.Database.Daos;

namespace SlottyMedia.Database.Repository.UserLikePostRelationRepo;

public interface IUserLikePostRelationRepostitory : IDatabaseRepository<UserLikePostRelationDao>
{
    public Task<List<UserLikePostRelationDao>> GetLikesForPost(Guid userId, Guid postId);
}