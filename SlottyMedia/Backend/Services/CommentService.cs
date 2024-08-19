using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.CommentExceptions;
using SlottyMedia.Backend.Exceptions.Services.PostExceptions;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Services;

/// <summary>
///     The CommentService class is responsible for handling comment related operations.
/// </summary>
public class CommentService
{
    private static readonly Logging Logger = Logging.Instance;
    private readonly IDatabaseActions _databaseActions;


    /// Constructor to initialize the CommentService with the required database actions.
    public CommentService(IDatabaseActions databaseActions)
    {
        Logger.LogInfo("CommentService initialized");
        _databaseActions = databaseActions;
    }

    /// <summary>
    ///     Inserts a new comment into the database.
    /// </summary>
    /// <param name="comment">The CommentDto object containing the comment details.</param>
    /// <returns>Returns the inserted CommentDto object.</returns>
    /// <exception cref="GeneralDatabaseException">Throws an exception if an error occurs while inserting the comment.</exception>
    public async Task<CommentDto> InsertComment(Guid creatorUserId, Guid postId, string content)
    {
        try
        {
            var comment = new CommentDao(creatorUserId, postId, content);

            Logger.LogDebug($"Inserting comment: {comment}");
            // Attempt to insert the comment into the database.
            var insertedComment = await _databaseActions.Insert(comment);
            // Return the inserted comment as a CommentDto object.
            return new CommentDto().Mapper(insertedComment);
        }
        catch (DatabaseIudActionException ex)
        {
            // Handle specific database insert/update/delete action exceptions.
            throw new CommentIudException(
                $"An error occurred while inserting the comment. Parameters: CreatorUserID {creatorUserId}. PostId {postId}, Content {content}",
                ex);
        }
        catch (GeneralDatabaseException ex)
        {
            // Handle general database exceptions.
            throw new CommentGeneralException(
                $"An error occurred while inserting the comment. Parameters: CreatorUserID {creatorUserId}. PostId {postId}, Content {content}",
                ex);
        }
        catch (Exception ex)
        {
            // Handle any other exceptions.
            throw new CommentGeneralException(
                $"An error occurred while inserting the comment. Parameters: CreatorUserID {creatorUserId}. PostId {postId}, Content {content}",
                ex);
        }
    }

    /// <summary>
    ///     Updates an existing comment in the database.
    /// </summary>
    /// <param name="comment">The CommentDto object containing the updated comment details.</param>
    /// <returns>Returns the updated CommentDto object.</returns>
    /// <exception cref="GeneralDatabaseException">Throws an exception if an error occurs while updating the comment.</exception>
    public async Task<CommentDto> UpdateComment(CommentDto comment)
    {
        try
        {
            // Attempt to update the comment in the database.
            var updatedComment = await _databaseActions.Update(comment.Mapper());
            // Return the updated comment as a CommentDto object.
            return new CommentDto().Mapper(updatedComment);
        }
        catch (DatabaseIudActionException ex)
        {
            // Handle specific database insert/update/delete action exceptions.
            throw new CommentIudException($"An error occurred while updating the comment. Comment: {comment}", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            // Handle general database exceptions.
            throw new CommentGeneralException($"An error occurred while updating the comment. Comment: {comment}", ex);
        }
        catch (Exception ex)
        {
            // Handle any other exceptions.
            throw new CommentGeneralException($"An error occurred while updating the comment. Comment: {comment}", ex);
        }
    }

    /// <summary>
    ///     Deletes a comment from the database.
    /// </summary>
    /// <param name="comment">The CommentDto object containing the comment details.</param>
    /// <returns>Returns a Task representing the asynchronous operation.</returns>
    /// <exception cref="GeneralDatabaseException">Throws an exception if an error occurs while deleting the comment.</exception>
    public async Task DeleteComment(CommentDto comment)
    {
        try
        {
            // Attempt to delete the comment from the database.
            await _databaseActions.Delete(comment.Mapper());
        }
        catch (DatabaseIudActionException ex)
        {
            // Handle specific database insert/update/delete action exceptions.
            throw new CommentIudException($"An error occurred while deleting the comment. Comment: {comment}", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            // Handle general database exceptions.
            throw new CommentGeneralException($"An error occurred while deleting the comment. Comment {comment}", ex);
        }
        catch (Exception ex)
        {
            // Handle any other exceptions.
            throw new CommentGeneralException($"An error occurred while deleting the comment. Comment {comment}", ex);
        }
    }
}