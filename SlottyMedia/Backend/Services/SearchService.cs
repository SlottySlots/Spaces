using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using Supabase.Postgrest;

namespace SlottyMedia.Backend.Services;

/// <summary>
///     Service for searching users and topics.
/// </summary>
public class SearchService
{
    private readonly IDatabaseActions _databaseActions;

    /// <summary>
    ///     Constructor to initialize the database actions dependency.
    /// </summary>
    /// <param name="databaseActions">The database actions dependency.</param>
    public SearchService(IDatabaseActions databaseActions)
    {
        _databaseActions = databaseActions;
    }

    /// <summary>
    ///     Method to search for users or topics by a given search term.
    /// </summary>
    /// <param name="searchTerm">The search term to look for.</param>
    /// <returns>Returns a list of user or topic IDs that match the search term.</returns>
    public async Task<List<Guid?>> SearchByUsernameOrTopic(string searchTerm)
    {
        var userSearch = new List<(string, Constants.Operator, string)>
        {
            ("userName", Constants.Operator.Equals, searchTerm)
        };

        var topicSearch = new List<(string, Constants.Operator, string)>
        {
            ("forumTopic", Constants.Operator.Equals, searchTerm)
        };

        var userResults = await _databaseActions.GetEntitiesWithSelectorById<UserDao>(
            u => new object[] { u.UserId! }, userSearch);
        var topicResults = await _databaseActions.GetEntitiesWithSelectorById<ForumDao>(
            f => new object[] { f.ForumId! }, topicSearch);

        var userIds = userResults.Select(u => u.UserId).ToList();
        var topicIds = topicResults.Select(t => t.ForumId).ToList();

        return userIds.Concat(topicIds).ToList();
    }
}