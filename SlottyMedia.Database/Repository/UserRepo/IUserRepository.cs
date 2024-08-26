using SlottyMedia.Database.Daos;

namespace SlottyMedia.Database.Repository.UserRepo;

public interface IUserRepository : IDatabaseRepository<UserDao>
{
    public Task<UserDao> GetUserByUsername(string username);

    public Task<UserDao> GetUserByEmail(string email);
}