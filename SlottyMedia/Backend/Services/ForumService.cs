using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.ForumExceptions;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.Database.Repository.ForumRepo;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Services;

/// <inheritdoc />
public class ForumService : IForumService
{
    private static readonly Logging<ForumService> Logger = new();
    private readonly IForumRepository _forumRepository;
    private readonly ISearchService _searchService;
    private readonly ITopForumRepository _topForumRepository;

    /// Constructor to initialize the ForumService with the required database actions.
    public ForumService(IForumRepository forumRepository, ITopForumRepository topForumRepository,
        ISearchService searchService)
    {
        Logger.LogInfo("ForumService initialized");
        _forumRepository = forumRepository;
        _topForumRepository = topForumRepository;
        _searchService = searchService;
    }


    /// <inheritdoc />
    public async Task InsertForum(Guid creatorUserId, string forumTopic)
    {
        try
        {
            var forum = new ForumDao(creatorUserId, forumTopic);
            Logger.LogDebug($"Inserting forum: {forum}");

            // Attempt to insert the forum into the database.
            await _forumRepository.AddElement(forum);
        }
        catch (DatabaseIudActionException ex)
        {
            // Handle specific database insert/update/delete action exceptions.
            throw new ForumIudException(
                $"An error occurred while inserting the forum. Parameters: CreatorUserId {creatorUserId}, ForumTopic {forumTopic}",
                ex);
        }
        catch (GeneralDatabaseException ex)
        {
            // Handle general database exceptions.
            throw new ForumGeneralException(
                $"An error occurred while inserting the forum. Parameters: CreatorUserId {creatorUserId}, ForumTopic {forumTopic}",
                ex);
        }
        catch (Exception ex)
        {
            // Handle any other exceptions.
            throw new ForumGeneralException(
                $"An error occurred while inserting the forum. Parameters: CreatorUserId {creatorUserId}, ForumTopic {forumTopic}",
                ex);
        }
    }

    /// <inheritdoc />
    public async Task DeleteForum(ForumDto forum)
    {
        try
        {
            Logger.LogDebug($"Deleting forum: {forum}");
            // Attempt to delete the forum from the database.
            await _forumRepository.DeleteElement(forum.Mapper());
        }
        catch (DatabaseIudActionException ex)
        {
            // Handle specific database insert/update/delete action exceptions.
            throw new ForumIudException($"An error occurred while deleting the forum. Forum: {forum}", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            // Handle general database exceptions.
            throw new ForumGeneralException($"An error occurred while deleting the forum. Forum: {forum}", ex);
        }
        catch (Exception ex)
        {
            // Handle any other exceptions.
            throw new ForumGeneralException($"An error occurred while deleting the forum. Forum: {forum}", ex);
        }
    }

    /// <inheritdoc />
    public async Task<ForumDto> GetForumByName(string forumName)
    {
        try
        {
            Logger.LogDebug($"Fetching forum with name '{forumName}'...");
            var dao = await _forumRepository.GetElementById(forumName);
            return new ForumDto().Mapper(dao);
        }
        catch (DatabaseMissingItemException ex)
        {
            throw new ForumNotFoundException($"No forum found with the name '{forumName}'", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new ForumGeneralException("An error occurred while fetching the forum.", ex);
        }
        catch (Exception ex)
        {
            throw new ForumGeneralException("An error occurred while fetching the forum.", ex);
        }
    }

    /// <inheritdoc />
    public async Task<List<ForumDto>> GetForumsByNameContaining(string name, int page, int pageSize = 10)
    {
        try
        {
            Logger.LogDebug(
                $"Fetching all forums containing the substring '{name}' (page {page} with size {pageSize})");
            var forums = await _searchService.SearchByTopic(name, page, pageSize);

            return forums.Forums;
        }
        catch (DatabaseMissingItemException ex)
        {
            throw new ForumNotFoundException($"No forums found containing the substring '{name}'", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new ForumGeneralException(
                $"An error occurred while fetching forums containing the substring '{name}'", ex);
        }
        catch (Exception ex)
        {
            throw new ForumGeneralException(
                $"An unexpected error occurred while fetching forums containing the substring '{name}'", ex);
        }

        //TODO use searchservice for this type of stuff

        // var query = await _supabase
        //     .From<ForumDao>()
        //     .Filter(dao => dao.ForumTopic!, Constants.Operator.ILike, $"%{name}%")
        //     .Range((page - 1) * pageSize, (page - 1) * pageSize + pageSize)
        //     .Get();
        // return query.Models
        //     .Select(forum => new ForumDto().Mapper(forum))
        //     .ToList();
    }


    /// <summary>
    ///     Retrieves all forums from the database.
    /// </summary>
    /// <returns>A list of ForumDto objects representing all forums.</returns>
    public async Task<List<ForumDto>> GetForums()
    {
        try
        {
            Logger.LogDebug("Fetching all forums...");
            var forumDaos = await _forumRepository.GetAllElements();

            // Map ForumDao to ForumDto
            return forumDaos.Select(dao => new ForumDto().Mapper(dao)).ToList();
        }
        catch (DatabaseMissingItemException ex)
        {
            Logger.LogError($"No forums found: {ex.Message}");
            throw new ForumNotFoundException("No forums found.", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            Logger.LogError($"A general database error occurred: {ex.Message}");
            throw new ForumGeneralException("An error occurred while retrieving the forums.", ex);
        }
        catch (Exception ex)
        {
            Logger.LogError($"An unexpected error occurred: {ex.Message}");
            throw new ForumGeneralException("An unexpected error occurred while retrieving the forums.", ex);
        }
    }

    /// <inheritdoc />
    public async Task<List<ForumDto>> DetermineRecentSpaces()
    {
        try
        {
            Logger.LogDebug("Fetching the 3 most recent forums...");
            var recentForums = await _topForumRepository.DetermineRecentSpaces();

            // Map ForumDao to ForumDto
            return recentForums.Select(dao => new ForumDto().Mapper(dao)).ToList();
        }
        catch (DatabaseMissingItemException ex)
        {
            Logger.LogError($"No recent forums found: {ex.Message}");
            throw new ForumNotFoundException("No recent forums found.", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            Logger.LogError($"A general database error occurred: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Logger.LogError($"An unexpected error occurred: {ex.Message}");
            throw new ForumGeneralException("An unexpected error occurred while retrieving the recent forums.", ex);
        }
    }

    /// <inheritdoc />
    public async Task<List<ForumDto>> GetTopForums()
    {
        try
        {
            Logger.LogDebug("Fetching the top forums...");
            var topForums = await _topForumRepository.GetTopForums();

            // Map TopForumDao to ForumDto
            return topForums.Select(dao => new ForumDto().Mapper(dao)).ToList();
        }
        catch (DatabaseMissingItemException ex)
        {
            Logger.LogError($"No top forums found: {ex.Message}");
            throw new ForumNotFoundException("No top forums found.", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            Logger.LogError($"A general database error occurred: {ex.Message}");
            throw new ForumGeneralException("An error occurred while retrieving the top forums.", ex);
        }
        catch (Exception ex)
        {
            Logger.LogError($"An unexpected error occurred: {ex.Message}");
            throw new ForumGeneralException("An unexpected error occurred while retrieving the top forums.", ex);
        }
    }
}