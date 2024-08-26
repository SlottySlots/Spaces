using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Helper;
using Client = Supabase.Client;

namespace SlottyMedia.Database.Repository.ForumRepo;

public class ForumRepository : DatabaseRepository<ForumDao>, IForumRepository
{
    /// <summary>
    ///     Base constructor for the <see cref="ForumRepository" />.
    /// </summary>
    /// <param name="client"></param>
    /// <param name="daoHelper"></param>
    /// <param name="databaseRepositroyHelper"></param>
    public ForumRepository(Client client, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper) :
        base(client, daoHelper, databaseRepositroyHelper)
    {
    }

    /// <inheritdoc />
    public async Task<ForumDao> GetElementById(string forumName)
    {
        return await base.GetElementByField("forumTopic", forumName);
    }
}