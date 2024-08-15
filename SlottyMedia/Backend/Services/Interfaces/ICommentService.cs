using SlottyMedia.Backend.Dtos;
using SlottyMedia.Database.Exceptions;

namespace SlottyMedia.Backend.Services.Interfaces
{
    /// <summary>
    /// The ICommentService interface is responsible for handling comment related operations.
    /// </summary>
    public interface ICommentService
    {
        /// <summary>
        /// Inserts a new comment into the database.
        /// </summary>
        /// <param name="comment">The CommentDto object containing the comment details.</param>
        /// <returns>Returns the inserted CommentDto object.</returns>
        /// <exception cref="GeneralDatabaseException">Throws an exception if an error occurs while inserting the comment.</exception>
        Task<CommentDto> InsertComment(CommentDto comment);

        /// <summary>
        /// Updates an existing comment in the database.
        /// </summary>
        /// <param name="comment">The CommentDto object containing the updated comment details.</param>
        /// <returns>Returns the updated CommentDto object.</returns>
        /// <exception cref="GeneralDatabaseException">Throws an exception if an error occurs while updating the comment.</exception>
        Task<CommentDto> UpdateComment(CommentDto comment);

        /// <summary>
        /// Deletes a comment from the database.
        /// </summary>
        /// <param name="comment">The CommentDto object containing the comment details.</param>
        /// <returns>Returns a Task representing the asynchronous operation.</returns>
        /// <exception cref="GeneralDatabaseException">Throws an exception if an error occurs while deleting the comment.</exception>
        Task DeleteComment(CommentDto comment);
    }
}