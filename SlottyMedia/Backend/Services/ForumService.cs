using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.ForumExceptions;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Services;

/// <inheritdoc />
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
}