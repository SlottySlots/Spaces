using SlottyMedia.Database;
using SlottyMedia.Database.Daos;

namespace SlottyMedia.Backend.Services.Interfaces;

/// <summary>
/// Interface for post-related services.
/// </summary>
public interface IPostService
{
    /// <summary>
    /// Retrieves a list of post titles from a forum for a given user, limited by the specified number.
    /// </summary>
    /// <param name="userID">The ID of the user.</param>
    /// <param name="limit">The maximum number of posts to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of post titles.</returns>
    public Task<List<string>> GetPostsFromForum(Guid userId, int limit);

    /// <summary>
    /// Inserts a new post into the database.
    /// </summary>
    /// <param name="post">The post to insert.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the inserted post.</returns>
    public Task<PostsDao> InsertPost(string title, string content, Guid creatorUserID, Guid forumID);

    /// <summary>
    /// Updates an existing post in the database.
    /// </summary>
    /// <param name="post">The post to update.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated post.</returns>
    Task<PostsDao> UpdatePost(PostsDao post);

    /// <summary>
    /// Deletes a post from the database.
    /// </summary>
    /// <param name="postId">The ID of the post to delete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result indicates whether the deletion was successful.</returns>
    Task<bool> DeletePost(PostsDao post);
    
    /// <summary>
    /// DatabaseActions property.
    /// </summary>
    public IDatabaseActions DatabaseActions { get; set; }
}