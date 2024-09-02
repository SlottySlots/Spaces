using SlottyMedia.Backend.Exceptions.Services.CommentExceptions;
using SlottyMedia.Database.Daos;

namespace SlottyMedia.Backend.Services.Interfaces;

/// <summary>
///     The ICommentService interface is responsible for handling comment related operations.
/// </summary>
public interface ICommentService
{
    /// <summary>
    ///     Inserts a new comment into the database.
    /// </summary>
    /// <param name="creatorUserId">The ID of the user who created the comment.</param>
    /// <param name="postId">The ID of the post to which the comment belongs.</param>
    /// <param name="content">The content of the comment.</param>
    /// <returns>Returns the inserted CommentDto object.</returns>
    /// <exception cref="CommentIudException">Thrown when an error occurs during Insert, Update, or Delete operations.</exception>
    /// <exception cref="CommentGeneralException">Thrown when a general error occurs.</exception>
    Task InsertComment(Guid creatorUserId, Guid postId, string content);

    /// <summary>
    ///     Updates an existing comment in the database.
    /// </summary>
    /// <param name="comment">The CommentDto object containing the updated comment details.</param>
    /// <returns>Returns the updated CommentDto object.</returns>
    /// <exception cref="CommentIudException">Thrown when an error occurs during Insert, Update, or Delete operations.</exception>
    /// <exception cref="CommentGeneralException">Thrown when a general error occurs.</exception>
    Task UpdateComment(CommentDao comment);

    /// <summary>
    ///     Deletes a comment from the database.
    /// </summary>
    /// <param name="comment">The CommentDto object containing the comment details.</param>
    /// <returns>Returns a Task representing the asynchronous operation.</returns>
    /// <exception cref="CommentIudException">Thrown when an error occurs during Insert, Update, or Delete operations.</exception>
    /// <exception cref="CommentGeneralException">Thrown when a general error occurs.</exception>
    Task DeleteComment(CommentDao comment);
}