using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.SearchExceptions;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.LoggingProvider;
using Supabase.Postgrest;

namespace SlottyMedia.Backend.Services;

/// <summary>
///     Service for searching users and topics.
/// </summary>
public class SearchService : ISearchService
{
    private static readonly Logging<SearchService> Logger = new();
    private readonly IDatabaseActions _databaseActions;


    /// <summary>
    ///     Constructor to initialize the database actions dependency.
    /// </summary>
    /// <param name="databaseActions">The database actions dependency.</param>
    public SearchService(IDatabaseActions databaseActions)
    {
        Logger.LogInfo("SearchService initialized");
        _databaseActions = databaseActions;
    }

    /// <inheritdoc />
    public async Task<SearchDto> SearchByUsernameOrTopic(string searchTerm)
    {
        try
        {
            Logger.LogInfo($"Searching for users or topics with search term: {searchTerm}");
            var userSearch = new List<(string, Constants.Operator, string)>
            {
                ("userName", Constants.Operator.Equals, searchTerm)
            };

            var topicSearch = new List<(string, Constants.Operator, string)>
            {
                ("forumTopic", Constants.Operator.Equals, searchTerm)
            };

            Logger.LogDebug($"Searching for users or topics with search term: {searchTerm}");
            var userResults = await _databaseActions.GetEntitiesWithSelectorById<UserDao>(
                u => new object[] { u.UserId! }, userSearch);
            var topicResults = await _databaseActions.GetEntitiesWithSelectorById<ForumDao>(
                f => new object[] { f.ForumId! }, topicSearch);

            if (userResults is null || !userResults.Any())
                userResults = new List<UserDao>();

            if (topicResults is null || !topicResults.Any())
                topicResults = new List<ForumDao>();

            var searchResult = new SearchDto();

            Logger.LogInfo("Mapping search results to DTOs");
            searchResult.Users.AddRange(userResults.Select(x => new UserDto().Mapper(x)));
            searchResult.Forums.AddRange(topicResults.Select(x => new ForumDto().Mapper(x)));

            return searchResult;
        }
        catch (DatabaseMissingItemException ex)
        {
            throw new SearchGeneralExceptions(
                $"A database error occurred while searching for users or topics. Term: {searchTerm}", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new SearchGeneralExceptions(
                $"A database error occurred while searching for users or topics. Term {searchTerm}", ex);
        }
        catch (Exception ex)
        {
            throw new SearchGeneralExceptions(
                $"An error occurred while searching for users or topics. Term {searchTerm}", ex);
        }
    }
}