using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.SearchExceptions;
using SlottyMedia.Backend.Services.Interfaces;
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
    private readonly IUserSeachRepository _userSearchRepository;


    /// <summary>
    ///     Constructor to initialize the database actions dependency.
    /// </summary>
    /// <param name="userSearchRepository">Repo used to retrieve search results.</param>
    /// <param name="forumSearchRepository">Repo used to retrieve search results specific to a forum</param>
    public SearchService(IUserSeachRepository userSearchRepository, IForumSearchRepository forumSearchRepository)
    {
        Logger.LogInfo("SearchService initialized");
        _userSearchRepository = userSearchRepository;
        _forumSearchRepository = forumSearchRepository;
    }

    /// <inheritdoc />
    public async Task<SearchDto> SearchByUsername(string searchTerm)
    {
        try
        {
            Logger.LogInfo($"Searching for users with search term: {searchTerm}");

            if (searchTerm.Length == 0)
                return new SearchDto();

            var userResults = await _userSearchRepository.GetUsersByUserName(searchTerm);

            if (!userResults.Any())
                return new SearchDto();

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
        catch (DatabasePaginationFailedException ex)
        {
            throw new SearchGeneralExceptions(
                $"An error occurred during the Pagination for search results with term {searchTerm}", ex);
        }
        catch (Exception ex)
        {
            throw new SearchGeneralExceptions(
                $"An error occurred while searching for users or topics. Term {searchTerm}", ex);
        }
    }

    /// <inheritdoc />
    public async Task<SearchDto> SearchByTopic(string searchTerm)
    {
        try
        {
            Logger.LogInfo($"Searching for topics with search term: {searchTerm}");

            if (searchTerm.Length == 0)
                return new SearchDto();

            var topicResults = await _forumSearchRepository.GetForumsByTopic(searchTerm);

            if (!topicResults.Any())
                return new SearchDto();

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
        catch (DatabasePaginationFailedException ex)
        {
            throw new SearchGeneralExceptions(
                $"An error occurred during the Pagination for search results with term {searchTerm}", ex);
        }
        catch (Exception ex)
        {
            throw new SearchGeneralExceptions(
                $"An error occurred while searching for users or topics. Term {searchTerm}", ex);
        }
    }
}