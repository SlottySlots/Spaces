using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.PostExceptions;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Pagination;

namespace SlottyMedia.Backend.Services.Interfaces;

/// <summary>
///     Interface for post-related services.
/// </summary>
public interface IPostService
{
    /// <summary>
    ///     Fetches all posts sorted by date in descending order. Fetches only a specified number of posts
    ///     on the specified page.
    /// </summary>
    /// <param name="pageRequest">The page request</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of PostDto objects.</returns>
    /// <exception cref="PostNotFoundException">Thrown when the posts are not found.</exception>
    /// <exception cref="PostGeneralException">Thrown when a general error occurs.</exception>
    public Task<IPage<PostDto>> GetAllPosts(PageRequest pageRequest);

    /// <summary>
    ///     Counts all existing posts.
    /// </summary>
    /// <returns>The total number of existing posts</returns>
    public Task<int> CountAllPosts();

    /// <summary>
    ///     Attempts to fetch a post by ID. Returns null if such a post could not be found.
    /// </summary>
    /// <param name="postId">The post's ID.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the post or null if not found.</returns>
    /// <exception cref="PostNotFoundException">Thrown when the post is not found.</exception>
    /// <exception cref="PostGeneralException">Thrown when a general error occurs.</exception>
    public Task<PostDto?> GetPostById(Guid postId);

    /// <summary>
    ///     Inserts a new post into the database.
    /// </summary>
    /// <param name="content">The content of the post.</param>
    /// <param name="creatorUserId">The UserId who created the post.</param>
    /// <param name="forumId">The ID of the forum the post should belong to.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the inserted post.</returns>
    /// <exception cref="PostIudException">Thrown when an error occurs during Insert, Update, or Delete operations.</exception>
    /// <exception cref="PostGeneralException">Thrown when a general error occurs.</exception>
    public Task InsertPost(string content, Guid creatorUserId, Guid forumId);

    /// <summary>
    ///     Updates an existing post in the database.
    /// </summary>
    /// <param name="post">The post to update.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated post.</returns>
    /// <exception cref="PostIudException">Thrown when an error occurs during Insert, Update, or Delete operations.</exception>
    /// <exception cref="PostGeneralException">Thrown when a general error occurs.</exception>
    Task UpdatePost(PostsDao post);

    /// <summary>
    ///     Deletes a post from the database.
    /// </summary>
    /// <param name="post">The post to delete.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result indicates whether the deletion was
    ///     successful.
    /// </returns>
    /// <exception cref="PostIudException">Thrown when an error occurs during Insert, Update, or Delete operations.</exception>
    /// <exception cref="PostGeneralException">Thrown when a general error occurs.</exception>
    Task DeletePost(PostsDao post);

    /// <summary>
    ///     This method fetches the number of forums the user has created posts in.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the number of forums.</returns>
    /// <exception cref="PostGeneralException">Thrown when a general error occurs.</exception>
    public Task<int> GetForumCountByUserId(Guid userId);

    /// <summary>
    ///     Gets posts of a user by their id and enables slicing via offsets.
    /// </summary>
    /// <param name="userId">The ID of the user that the posts belong to.</param>
    /// <param name="pageRequest">The page request</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of PostDto objects.</returns>
    /// <exception cref="PostNotFoundException">Thrown when the posts are not found.</exception>
    /// <exception cref="PostGeneralException">Thrown when a general error occurs.</exception>
    public Task<IPage<PostDto>> GetPostsByUserId(Guid userId, PageRequest pageRequest);

    public Task<IPage<PostDto>> GetPostsByForumId(Guid forumId, PageRequest pageRequest);
}