using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.SearchExceptions;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.Database.Repository.SearchRepo;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Services;

/// <summary>
///     Service for searching users and topics.
/// </summary>
public class SearchService : ISearchService
{
    private static readonly Logging<SearchService> Logger = new();
    private readonly IForumSearchRepository _forumSearchRepository;
    private readonly IUserSeachRepository _userSeachRepository;


    /// <summary>
    ///     Constructor to initialize the database actions dependency.
    /// </summary>
    /// <param name="databaseActions">The database actions dependency.</param>
    public SearchService(IUserSeachRepository userSeachRepository, IForumSearchRepository forumSearchRepository)
    {
        Logger.LogInfo("SearchService initialized");
        _userSeachRepository = userSeachRepository;
        _forumSearchRepository = forumSearchRepository;
    }

    /// <inheritdoc />
    public async Task<SearchDto> SearchByUsername(string searchTerm, int page, int pagesize)
    {
        try
        {
            Logger.LogInfo($"Searching for users with search term: {searchTerm}");

            if (searchTerm.Length == 0)
                return new SearchDto();
            if (searchTerm[0] == '@') searchTerm = searchTerm.Substring(1);

            var userResults = await _userSeachRepository.GetUsersByUserName(searchTerm, page, pagesize);

            if (userResults is null || !userResults.Any())
                userResults = new List<UserDao>();

            var searchResult = new SearchDto();

            Logger.LogInfo("Mapping search results to DTOs");
            searchResult.Users.AddRange(userResults.Select(x => new UserDto().Mapper(x)));

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

    /// <inheritdoc />
    public async Task<SearchDto> SearchByTopic(string searchTerm, int page, int pagesize)
    {
        try
        {
            Logger.LogInfo($"Searching for topics with search term: {searchTerm}");

            if (searchTerm.Length == 0)
                return new SearchDto();
            if (searchTerm[0] == '#') searchTerm = searchTerm.Substring(1);

            var topicResults = await _forumSearchRepository.GetForumsByTopic(searchTerm, page, pagesize);

            if (topicResults is null || !topicResults.Any())
                topicResults = new List<ForumDao>();

            var searchResult = new SearchDto();

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