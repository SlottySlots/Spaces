using SlottyMedia.Backend.Exceptions.Services.CommentExceptions;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.Database.Repository.CommentRepo;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Services;

/// <inheritdoc />
public class CommentService : ICommentService
{
    private static readonly Logging<CommentService> Logger = new();
    private readonly ICommentRepository _commentRepository;


    /// Constructor to initialize the CommentService with the required database actions.
    public CommentService(ICommentRepository commentRepository)
    {
        Logger.LogInfo("CommentService initialized");
        _commentRepository = commentRepository;
    }

    /// <inheritdoc />
    public async Task InsertComment(Guid creatorUserId, Guid postId, string content)
    {
        try
        {
            var comment = new CommentDao(creatorUserId, postId, content);

            Logger.LogDebug($"Inserting comment: {comment}");
            // Attempt to insert the comment into the database.
            await _commentRepository.AddElement(comment);
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

    /// <inheritdoc />
    public async Task UpdateComment(CommentDao comment)
    {
        try
        {
            // Attempt to update the comment in the database.
            await _commentRepository.UpdateElement(comment);
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

    /// <inheritdoc />
    public async Task DeleteComment(CommentDao comment)
    {
        try
        {
            // Attempt to delete the comment from the database.
            await _commentRepository.DeleteElement(comment);
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