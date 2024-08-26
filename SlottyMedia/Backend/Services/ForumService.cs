using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.ForumExceptions;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.LoggingProvider;
using Supabase.Postgrest;

namespace SlottyMedia.Backend.Services;

/// <inheritdoc />
public class ForumService : IForumService
{
    private static readonly Logging<ForumService> Logger = new();
    private readonly IDatabaseActions _databaseActions;
    private readonly Client _supabase;

    /// Constructor to initialize the ForumService with the required database actions.
    public ForumService(IDatabaseActions databaseActions, Client supabase)
    {
        Logger.LogInfo("ForumService initialized");
        _databaseActions = databaseActions;
        _supabase = supabase;
    }

    /// <inheritdoc />
    public async Task<ForumDto> InsertForum(Guid creatorUserId, string forumTopic)
    {
        try
        {
            var forum = new ForumDao(creatorUserId, forumTopic);
            Logger.LogDebug($"Inserting forum: {forum}");

            // Attempt to insert the forum into the database.
            var insertedForum = await _databaseActions.Insert(forum);

            // Return the inserted forum as a ForumDto object.
            return new ForumDto().Mapper(insertedForum);
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
            await _databaseActions.Delete(forum.Mapper());
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
        Logger.LogDebug($"Fetching forum with name '{forumName}'...");
        var dao = await _databaseActions.GetEntityByField<ForumDao>("forumTopic", forumName);
        return new ForumDto().Mapper(dao);
    }

    /// <inheritdoc />
    public async Task<List<ForumDto>> GetForumsByNameContaining(string name, int page, int pageSize = 10)
    {
        Logger.LogDebug($"Fetching all forums containing the substring '{name}' (page {page} with size {pageSize})");
        var query = await _supabase
            .From<ForumDao>()
            .Filter(dao => dao.ForumTopic!, Constants.Operator.ILike, $"%{name}%")
            .Range((page - 1) * pageSize, (page - 1) * pageSize + pageSize)
            .Get();
        return query.Models
            .Select(forum => new ForumDto().Mapper(forum))
            .ToList();
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
            var forumDaos = await _databaseActions.GetEntities<ForumDao>();

            // Map ForumDao to ForumDto
            return forumDaos.Select(dao => new ForumDto().Mapper(dao)).ToList();
        }
        catch (DatabaseMissingItemException ex)
        {
            Logger.LogError($"No forums found: {ex.Message}");
            throw new GeneralDatabaseException("No forums found.", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            Logger.LogError($"A general database error occurred: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Logger.LogError($"An unexpected error occurred: {ex.Message}");
            throw new GeneralDatabaseException("An unexpected error occurred while retrieving the forums.", ex);
        }
    }

    /// <inheritdoc />
    public async Task<List<ForumDto>> DetermineRecentSpaces()
    {
        try
        {
            Logger.LogDebug("Fetching the 3 most recent forums...");
            var recentForums = await _databaseActions.GetEntitiesWithSelectorById<TopForumDao>(
                x => new object[] { x.ForumId!, x.ForumTopic! },
                new List<(string, Constants.Operator, string)>(),
                2,
                0,
                ("created_at", Constants.Ordering.Descending, Constants.NullPosition.Last)
            );

            // Map ForumDao to ForumDto
            return recentForums.Select(dao => new ForumDto().Mapper(dao)).ToList();
        }
        catch (DatabaseMissingItemException ex)
        {
            Logger.LogError($"No recent forums found: {ex.Message}");
            throw new GeneralDatabaseException("No recent forums found.", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            Logger.LogError($"A general database error occurred: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Logger.LogError($"An unexpected error occurred: {ex.Message}");
            throw new GeneralDatabaseException("An unexpected error occurred while retrieving the recent forums.", ex);
        }
    }

    /// <inheritdoc />
    public async Task<List<ForumDto>> GetTopForums()
    {
        try
        {
            Logger.LogDebug("Fetching the top forums...");
            var topForums = await _databaseActions.GetTopForums();

            // Map TopForumDao to ForumDto
            return topForums.Select(dao => new ForumDto().Mapper(dao)).ToList();
        }
        catch (DatabaseMissingItemException ex)
        {
            Logger.LogError($"No top forums found: {ex.Message}");
            throw new GeneralDatabaseException("No top forums found.", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            Logger.LogError($"A general database error occurred: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Logger.LogError($"An unexpected error occurred: {ex.Message}");
            throw new GeneralDatabaseException("An unexpected error occurred while retrieving the top forums.", ex);
        }
    }
}