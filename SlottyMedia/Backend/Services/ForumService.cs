using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.ForumExceptions;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Services;

/// <summary>
///     The ForumService class is responsible for handling forum related operations.
/// </summary>
public class ForumService : IForumService
{
    private static readonly Logging<ForumService> Logger = new();
    private readonly IDatabaseActions _databaseActions;

    /// Constructor to initialize the ForumService with the required database actions.
    public ForumService(IDatabaseActions databaseActions)
    {
        Logger.LogInfo("ForumService initialized");
        _databaseActions = databaseActions;
    }

    /// <summary>
    ///     Inserts a new forum into the database.
    /// </summary>
    /// <param name="creatorUserId">The Creator UserID</param>
    /// ///
    /// <param name="forumTopic">The Topic from the Forum</param>
    /// <returns>Returns the inserted ForumDto object.</returns>
    /// <exception cref="GeneralDatabaseException">Throws an exception if an error occurs while inserting the forum.</exception>
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

    /// <summary>
    ///     Deletes a forum from the database based on the given forum ID.
    /// </summary>
    /// <param name="forum">The forum to delete.</param>
    /// <returns>Returns a Task representing the asynchronous operation.</returns>
    /// <exception cref="GeneralDatabaseException">Throws an exception if an error occurs while deleting the forum.</exception>
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
    
    /// <summary>
    ///     Retrieves all forums from the database.
    /// </summary>
    /// <returns>A list of ForumDto objects representing all forums.</returns>
    public async Task<List<ForumDto>> GetForums()
    {
        try
        {
            Logger.LogDebug("Retrieving all forums from the database.");
            
            var forumDaos = await _databaseActions.GetEntities<ForumDao>();

            // Mapping ForumDao objects to ForumDto objects
            var forumDtos = forumDaos.Select(forum => new ForumDto().Mapper(forum)).ToList();

            Logger.LogDebug($"{forumDtos.Count} forums retrieved successfully.");

            return forumDtos;
        }
        catch (GeneralDatabaseException ex)
        {
            throw new ForumGeneralException("An error occurred while retrieving the forums.", ex);
        }
        catch (Exception ex)
        {
            throw new ForumGeneralException("An unexpected error occurred while retrieving the forums.", ex);
        }
    }
    
}