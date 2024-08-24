using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.ForumExceptions;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.LoggingProvider;
using Supabase;

namespace SlottyMedia.Backend.Services;

/// <inheritdoc />
public class ForumService : IForumService
{
    private static readonly Logging<ForumService> Logger = new();
    private readonly IDatabaseActions _databaseActions;
    private readonly Client _supabaseClient;

    /// Constructor to initialize the ForumService with the required database actions.
    public ForumService(IDatabaseActions databaseActions, Client supabaseClient)
    {
        Logger.LogInfo("ForumService initialized");
        _databaseActions = databaseActions;
        _supabaseClient = supabaseClient;
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
    
    /// <summary>
    ///     Retrieves all forums from the database.
    /// </summary>
    /// <returns>A list of ForumDto objects representing all forums.</returns>
    public async Task<List<ForumDto>> GetForums()
    {
        try
        {
            // Retrieve forum data from the database
            var query = await _supabaseClient
                .From<ForumDao>()
                .Get();

            var forumDaos = query.Models;

            // Map ForumDao to ForumDto
            return forumDaos.Select(dao => new ForumDto().Mapper(dao)).ToList();
        }
        catch (ArgumentNullException ex)
        {
            // Handle when an argument is null that shouldn't be
            Logger.LogError($"ArgumentNullException: An argument was null but is not allowed: {ex.Message}");
            throw new GeneralDatabaseException("A required argument was null while retrieving the forums.", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            // Handle general database exceptions
            Logger.LogError($"GeneralDatabaseException: A general database error occurred: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            // Handle all other unexpected exceptions
            Logger.LogError($"Exception: An unexpected error occurred: {ex.Message}");
            throw new GeneralDatabaseException("An unexpected error occurred while retrieving the forums.", ex);
        }
    }
    

    
    
    
    
    
    
}