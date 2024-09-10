using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.PostExceptions;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.Database.Pagination;
using SlottyMedia.Database.Repository.PostRepo;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Services;

/// <inheritdoc />
public class PostService : IPostService
{
    private static readonly Logging<PostService> Logger = new();

    private readonly IPostRepository _postRepository;

    /// <summary>
    ///     Initializes a new instance of the <see cref="PostService" /> class.
    /// </summary>
    public PostService(IPostRepository postRepository)
    {
        Logger.LogInfo("PostService initialized");
        _postRepository = postRepository;
    }

    /// <inheritdoc />
    public async Task InsertPost(string content, Guid creatorUserId, Guid forumId)
    {
        try
        {
            var post = new PostsDao
            {
                Headline = "",
                Content = content,
                UserId = creatorUserId,
                ForumId = forumId
            };
            Logger.LogInfo($"Inserting a new post into the database {post}");
            await _postRepository.AddElement(post);
        }
        catch (DatabaseIudActionException ex)
        {
            throw new PostIudException(
                $"An error occurred while inserting a post starting with '{content[..Math.Min(15, content.Length)]}...'",
                ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new PostGeneralException(
                $"A database error occurred while inserting a post starting with '{content[..Math.Min(15, content.Length)]}...'",
                ex);
        }
        catch (Exception ex)
        {
            throw new PostGeneralException(
                $"An error occurred while inserting the post starting with '{content[..Math.Min(15, content.Length)]}...'",
                ex);
        }
    }

    /// <inheritdoc />
    public async Task UpdatePost(PostsDao post)
    {
        try
        {
            Logger.LogInfo($"Updating the post in the database {post}");
            await _postRepository.UpdateElement(post);
        }
        catch (DatabaseIudActionException ex)
        {
            throw new PostIudException($"An error occurred while updating the post. Post: {post}", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new PostGeneralException($"A database error occurred while updating the post. Post: {post}", ex);
        }
    }

    /// <inheritdoc />
    public async Task DeletePost(PostsDao post)
    {
        try
        {
            Logger.LogInfo($"Deleting the post from the database {post}");
            await _postRepository.DeleteElement(post);
        }
        catch (DatabaseIudActionException ex)
        {
            throw new PostIudException($"An error occurred while deleting the post. Post: {post}", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new PostGeneralException($"A database error occurred while deleting the post. Post: {post}", ex);
        }
    }

    /// <inheritdoc />
    public async Task<PostDto?> GetPostById(Guid postId)
    {
        try
        {
            Logger.LogInfo($"Fetching post with ID: {postId}");
            var post = await _postRepository.GetElementById(postId);
            return new PostDto().Mapper(post);
        }
        catch (DatabaseMissingItemException ex)
        {
            throw new PostNotFoundException($"Post with ID {postId} was not found.", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new PostGeneralException($"A database error occurred while fetching the post with ID {postId}.", ex);
        }
        catch (Exception ex)
        {
            throw new PostGeneralException($"An error occurred while fetching the post with ID {postId}.", ex);
        }
    }

    /// <inheritdoc />
    public async Task<int> GetForumCountByUserId(Guid userId)
    {
        try
        {
            Logger.LogInfo($"Counting forums for the user with ID: {userId}");
            var forumCount = await _postRepository.GetForumCountByUserId(userId);
            return forumCount;
        }
        catch (GeneralDatabaseException ex)
        {
            throw new PostGeneralException($"A database error occurred while counting the forums. UserID: {userId}",
                ex);
        }
        catch (Exception ex)
        {
            throw new PostGeneralException($"An error occurred while counting the forums. UserID: {userId}", ex);
        }
    }

    /// <inheritdoc />
    public async Task<IPage<PostDto>> GetAllPosts(PageRequest pageRequest)
    {
        try
        {
            Logger.LogInfo(
                $"Fetching all posts on page {pageRequest.PageNumber} with page size {pageRequest.PageSize}");
            var posts = await _postRepository.GetAllElements(pageRequest);
            Logger.LogInfo($"Fetched page {posts.PageNumber}, which contains {posts.Count()} posts");
            return posts.Map(dao => new PostDto().Mapper(dao));
        }
        catch (DatabaseMissingItemException ex)
        {
            Logger.LogError($"No posts found: {ex.Message}");
            throw new PostNotFoundException("No posts found.", ex);
        }
        catch (DatabasePaginationFailedException ex)
        {
            Logger.LogError($"An error occurred during the Pagination for all posts: {ex.Message}");
            throw new PostGeneralException("An error occurred during the Pagination for all posts.", ex);
        }
        catch (Exception ex)
        {
            Logger.LogError($"An error occurred while fetching all posts: {ex.Message}");
            throw new PostGeneralException("An error occurred while fetching all posts.", ex);
        }
    }

    /// <inheritdoc />
    public async Task<int> CountAllPosts()
    {
        try
        {
            Logger.LogDebug("Counting all posts in the database!");
            return await _postRepository.CountAllPosts();
        }
        catch (Exception ex)
        {
            Logger.LogError($"An error occurred while counting all posts: {ex.Message}");
            throw new PostGeneralException("An error occurred while counting all posts.", ex);
        }
    }

    /// <inheritdoc />
    public async Task<IPage<PostDto>> GetPostsByUserId(Guid userId, PageRequest pageRequest)
    {
        try
        {
            Logger.LogInfo($"Fetching posts for the user with ID: {userId}");
            var posts = await _postRepository.GetPostsByUserId(userId, pageRequest);
            return posts.Map(dao => new PostDto().Mapper(dao));
        }
        catch (DatabaseMissingItemException ex)
        {
            throw new PostNotFoundException(
                $"Posts for the given user ID were not found. UserID {userId}",
                ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new PostGeneralException(
                $"A database error occurred while fetching the posts. UserID {userId}",
                ex);
        }
        catch (DatabasePaginationFailedException ex)
        {
            throw new PostGeneralException(
                $"An error occurred during the Pagination for posts of user with ID {userId}",
                ex);
        }
        catch (Exception ex)
        {
            throw new PostGeneralException(
                $"An error occurred while fetching the posts. UserID {userId}",
                ex);
        }
    }

    /// <inheritdoc />
    public async Task<IPage<PostDto>> GetPostsByForumId(Guid forumId, PageRequest pageRequest)
    {
        try
        {
            Logger.LogInfo($"Fetching posts for the forum with ID: {forumId}");
            var posts = await _postRepository.GetPostsByForumId(forumId, pageRequest);
            return posts.Map(dao => new PostDto().Mapper(dao));
        }
        catch (DatabaseMissingItemException ex)
        {
            throw new PostNotFoundException(
                $"Posts for the given user ID were not found. UserID {forumId}",
                ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new PostGeneralException(
                $"A database error occurred while fetching the posts. UserID {forumId}",
                ex);
        }
        catch (DatabasePaginationFailedException ex)
        {
            throw new PostGeneralException(
                $"An error occurred during the Pagination for posts of forum with ID {forumId}",
                ex);
        }
        catch (Exception ex)
        {
            throw new PostGeneralException(
                $"An error occurred while fetching the posts. UserID {forumId}",
                ex);
        }
    }
}