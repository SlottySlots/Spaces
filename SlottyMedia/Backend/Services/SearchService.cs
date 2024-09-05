using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.SearchExceptions;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.Database.Pagination;
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
    public async Task<IPage<UserDto>> SearchByUsernameContaining(string searchTerm, PageRequest pageRequest)
    {
        try
        {
            Logger.LogInfo($"Searching for users with search term: {searchTerm}");
            var result = await _userSearchRepository.GetUsersByUserName(searchTerm, pageRequest);
            return result.Map(dao => new UserDto().Mapper(dao));
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
    public async Task<IPage<ForumDto>> SearchByForumTopicContaining(string searchTerm, PageRequest pageRequest)
    {
        try
        {
            Logger.LogInfo($"Searching for topics with search term: {searchTerm}");
            var result = await _forumSearchRepository.GetForumsByTopic(searchTerm, pageRequest);
            return result.Map(dao => new ForumDto().Mapper(dao));
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