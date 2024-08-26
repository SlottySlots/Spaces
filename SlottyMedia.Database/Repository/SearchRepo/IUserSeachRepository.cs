using SlottyMedia.Database.Daos;

namespace SlottyMedia.Database.Repository;

public interface IUserSeachRepository : IDatabaseRepository<UserDao>
{
    public Task<List<UserDao>> GetUsersByUserName(string userName, int page, int pageSize);

}