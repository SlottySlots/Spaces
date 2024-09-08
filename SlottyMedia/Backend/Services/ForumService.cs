using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.ForumExceptions;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.Database.Pagination;
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
            var dao = await _forumRepository.GetForumByName(forumName);
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
    public async Task<ForumDto> GetForumById(Guid forumId)
    {
        try
        {
            Logger.LogDebug($"Fetching forum with name '{forumId}'...");
            var dao = await _forumRepository.GetElementById(forumId);
            return new ForumDto().Mapper(dao);
        }
        catch (DatabaseMissingItemException ex)
        {
            throw new ForumNotFoundException($"No forum found with the name '{forumId}'", ex);
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
    public async Task<IPage<ForumDto>> GetAllForums(PageRequest pageRequest)
    {
        try
        {
            Logger.LogDebug("Fetching all forums...");
            var forums = await _forumRepository.GetAllElements(pageRequest);
            return forums.Map(dao => new ForumDto().Mapper(dao));
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

    public async Task<bool> ExistsByName(string forumName)
    {
        try
        {
            Logger.LogDebug($"Checking if forum with name '{forumName}' exists...");
            return await _forumRepository.ExistsByName(forumName);
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