using SlottyMedia.Backend.Dtos;
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

    /// <summary>
    ///     Counts the total number of comments in the given post.
    /// </summary>
    /// <param name="postId">The post to query</param>
    /// <returns>The total number of comments</returns>
    Task<int> CountCommentsInPost(Guid postId);

    /// <summary>
    ///     Fetches all comments in the given post. Utilizes pagination in order to limit
    ///     the total number of queried posts: Only posts on the given page will be fetched.
    /// </summary>
    /// <param name="postId">The post whose comments should be fetched</param>
    /// <param name="page">The page to fetch (one-based)</param>
    /// <param name="pageSize">The size of each page (default is 10)</param>
    /// <returns>A list containing the queried posts</returns>
    Task<List<CommentDto>> GetCommentsInPost(Guid postId, int page, int pageSize = 10);
}