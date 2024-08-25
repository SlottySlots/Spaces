using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.PostExceptions;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.LoggingProvider;
using Supabase.Postgrest;

namespace SlottyMedia.Backend.Services;

/// <inheritdoc />
public class PostService : IPostService
{
    private static readonly Logging<PostService> Logger = new();

    /// <summary>
    ///     Initializes a new instance of the <see cref="PostService" /> class.
    /// </summary>
    /// <param name="databaseActions">The database actions interface.</param>
    public PostService(IDatabaseActions databaseActions)
    {
        Logger.LogInfo("PostService initialized");
        DatabaseActions = databaseActions;
    }

    /// <inheritdoc />
    public IDatabaseActions DatabaseActions { get; set; }

    /// <inheritdoc />
    public async Task<PostDto> InsertPost(string content, Guid creatorUserId, Guid forumId)
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
            var insertedPost = await DatabaseActions.Insert(post);
            return new PostDto().Mapper(insertedPost);
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
    public async Task<PostDto> UpdatePost(PostDto post)
    {
        try
        {
            Logger.LogInfo($"Updating the post in the database {post}");
            var updatedPost = await DatabaseActions.Update(post.Mapper());
            return new PostDto().Mapper(updatedPost);
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
    public async Task<bool> DeletePost(PostDto post)
    {
        try
        {
            Logger.LogInfo($"Deleting the post from the database {post}");
            var result = await DatabaseActions.Delete(post.Mapper());
            return result;
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
    public async Task<List<string>> GetPostsFromForum(Guid userId, int startOfSet, int endOfSet)
    {
        //TODO Fix this method!!
        try
        {
            Logger.LogInfo($"Fetching posts for the user with ID: {userId} from index {startOfSet} to {endOfSet}");
            var posts = await DatabaseActions.GetEntitiesWithSelectorById<PostsDao>(
                x => new object[] { x.Forum! },
                "creator_userID",
                userId.ToString(), startOfSet, endOfSet,
                ("created_at", Constants.Ordering.Descending, Constants.NullPosition.Last)
            );

            Logger.LogInfo("Mapping posts to forum topics");
            var forumTopics = new List<string>();
            foreach (var post in posts)
                if (post.Forum is not null && post.Forum.ForumTopic is not null)
                    forumTopics.Add(post.Forum.ForumTopic);

            return forumTopics;
        }
        catch (DatabaseMissingItemException ex)
        {
            throw new PostNotFoundException(
                $"Posts for the given user ID were not found. UserID {userId} StartOfSet: {startOfSet} EndOfSet: {endOfSet}",
                ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new PostGeneralException(
                $"A database error occurred while fetching the posts. UserID {userId} StartOfSet: {startOfSet} EndOfSet: {endOfSet}",
                ex);
        }
        catch (Exception ex)
        {
            throw new PostGeneralException(
                $"An error occurred while fetching the posts. UserID {userId} StartOfSet: {startOfSet} EndOfSet: {endOfSet}",
                ex);
        }
    }

    /// <inheritdoc />
    public async Task<List<Guid>> GetAllPosts(int page, int pageSize = 10)
    {
        try
        {
            Logger.LogInfo($"Fetching all posts for page {page} with page size {pageSize}");
            var posts = await DatabaseActions.GetEntitiesWithSelectorById<PostsDao>(
                x => new object[] { x.PostId! },
                new List<(string, Constants.Operator, string)>(),
                page * pageSize,
                (page - 1) * pageSize,
                ("created_at", Constants.Ordering.Descending, Constants.NullPosition.Last)
            );

            var result = posts
                .Where(post => post.PostId is not null)
                .Select(post => post.PostId!.Value)
                .ToList();

            return result;
        }
        catch (DatabaseMissingItemException ex)
        {
            throw new PostNotFoundException(
                $"Posts for the given page and page size were not found. Page: {page}, PageSize: {pageSize}", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new PostGeneralException(
                $"A database error occurred while fetching the posts. Page: {page}, PageSize: {pageSize}", ex);
        }
        catch (Exception ex)
        {
            throw new PostGeneralException(
                $"An error occurred while fetching the posts. Page: {page}, PageSize: {pageSize}", ex);
        }
    }

    public async Task<PostDto?> GetPostById(Guid postId)
    {
        try
        {
            Logger.LogInfo($"Fetching post with ID: {postId}");
            var post = await DatabaseActions.GetEntityByField<PostsDao>("postID", postId.ToString());
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
            var forumCount = await DatabaseActions.GetCountForUserForums(userId.ToString());
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


    /// <summary>
    ///     Retrieves the total number of posts associated with a specific forum by its ID.
    /// </summary>
    /// <param name="forumId">The unique identifier of the forum.</param>
    public async Task<int> GetPostCountByForumId(Guid forumId)
    {
        if (forumId == Guid.Empty)
        {
            Logger.LogError("Invalid forum ID provided.");
            throw new ArgumentException("Forum ID cannot be empty.", nameof(forumId));
        }

        try
        {
            Logger.LogDebug($"Retrieving post count for forum ID: {forumId}");
            var postCount = await DatabaseActions.GetCountByField<PostsDao>("associated_forumID", forumId.ToString());
            Logger.LogDebug($"Post count for forum ID {forumId}: {postCount}");
            return postCount;
        }
        catch (ArgumentNullException ex)
        {
            Logger.LogError(
                $"An argument was null while retrieving the post count for forum ID {forumId}: {ex.Message}");
            throw new GeneralDatabaseException("A required argument was null while retrieving the post count.", ex);
        }
        catch (Exception ex)
        {
            Logger.LogError(
                $"An unexpected error occurred while retrieving the post count for forum ID {forumId}: {ex.Message}");
            throw new GeneralDatabaseException("An unexpected error occurred while retrieving the post count.", ex);
        }
    }

    /// <inheritdoc />
    public async Task<List<PostDto>> GetPostsByUserId(Guid userId, int startOfSet, int endOfSet)
    {
        try
        {
            Logger.LogInfo($"Fetching posts for the user with ID: {userId} from index {startOfSet} to {endOfSet}");
            var posts = await DatabaseActions.GetEntitiesWithSelectorById<PostsDao>(
                x => new object[] { x.PostId!, x.Content!, x.Forum!, x.CreatedAt },
                new List<(string, Constants.Operator, string)>
                {
                    ("creator_userID", Constants.Operator.Equals, userId.ToString())
                },
                startOfSet,
                endOfSet,
                ("created_at", Constants.Ordering.Descending, Constants.NullPosition.Last)
            );

            return ConvertPostsToPostDtos(posts);
        }
        catch (DatabaseMissingItemException ex)
        {
            throw new PostNotFoundException(
                $"Posts for the given user ID were not found. UserID {userId} StartOfSet: {startOfSet} EndOfSet: {endOfSet}",
                ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new PostGeneralException(
                $"A database error occurred while fetching the posts. UserID {userId} StartOfSet: {startOfSet} EndOfSet: {endOfSet}",
                ex);
        }
        catch (Exception ex)
        {
            throw new PostGeneralException(
                $"An error occurred while fetching the posts. UserID {userId} StartOfSet: {startOfSet} EndOfSet: {endOfSet}",
                ex);
        }
    }

    /// <summary>
    ///     Retrieves a list of posts from the database based on the given userId and forumId.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="startOfSet">The starting index of the set.</param>
    /// <param name="endOfSet">The ending index of the set.</param>
    /// <param name="forumId">The ID of the forum.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of PostDto objects.</returns>
    public async Task<List<PostDto>> GetPostsByUserIdByForumId(Guid userId, int startOfSet, int endOfSet, Guid forumId)
    {
        try
        {
            Logger.LogInfo(
                $"Fetching posts for the user with ID: {userId} and forum with ID: {forumId} from index {startOfSet} to {endOfSet}");
            var posts = await DatabaseActions.GetEntitiesWithSelectorById<PostsDao>(
                x => new object[] { x.PostId!, x.Content!, x.Forum!, x.CreatedAt },
                new List<(string, Constants.Operator, string)>
                {
                    ("creator_userID", Constants.Operator.Equals, userId.ToString()),
                    ("associated_forumID", Constants.Operator.Equals, forumId.ToString())
                },
                startOfSet,
                endOfSet,
                ("created_at", Constants.Ordering.Descending, Constants.NullPosition.Last)
            );

            return ConvertPostsToPostDtos(posts);
        }
        catch (DatabaseMissingItemException ex)
        {
            throw new PostNotFoundException(
                $"Posts for the given user ID and forum ID were not found. User ID: {userId}, Forum ID: {forumId}", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new PostGeneralException(
                $"A database error occurred while fetching the posts. FormID: {forumId} UserID {userId} StartOfSet: {startOfSet} EndOfSet: {endOfSet}",
                ex);
        }
        catch (Exception ex)
        {
            throw new PostGeneralException(
                $"An error occurred while fetching the posts. FormID: {forumId} UserID {userId} StartOfSet: {startOfSet} EndOfSet: {endOfSet}",
                ex);
        }
    }

    /// <summary>
    ///     Retrieves a list of posts from the database based on the given forumId.
    /// </summary>
    /// <param name="forumId">The ID of the forum.</param>
    /// <param name="startOfSet">The starting index of the set.</param>
    /// <param name="endOfSet">The ending index of the set.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of PostDto objects.</returns>
    public async Task<List<PostDto>> GetPostsByForumId(Guid forumId, int startOfSet, int endOfSet)
    {
        try
        {
            Logger.LogInfo($"Fetching posts for the forum with ID: {forumId} from index {startOfSet} to {endOfSet}");
            var posts = await DatabaseActions.GetEntitiesWithSelectorById<PostsDao>(
                x => new object[] { x.PostId!, x.Content!, x.Forum!, x.CreatedAt },
                new List<(string, Constants.Operator, string)>
                {
                    ("associated_forumID", Constants.Operator.Equals, forumId.ToString())
                },
                startOfSet,
                endOfSet,
                ("created_at", Constants.Ordering.Descending, Constants.NullPosition.Last)
            );

            return ConvertPostsToPostDtos(posts);
        }
        catch (DatabaseMissingItemException ex)
        {
            throw new PostNotFoundException($"Posts for the given forum ID were not found. Forum ID: {forumId}", ex);
        }
        catch (GeneralDatabaseException ex)
        {
            throw new PostGeneralException(
                $"A database error occurred while fetching the posts. FormID: {forumId} StartOfSet: {startOfSet} EndOfSet: {endOfSet}",
                ex);
        }
        catch (Exception ex)
        {
            throw new PostGeneralException(
                $"An error occurred while fetching the posts. FormID: {forumId} StartOfSet: {startOfSet} EndOfSet: {endOfSet}",
                ex);
        }
    }

    /// <summary>
    ///     Converts a list of PostsDao objects to a list of PostDto objects.
    /// </summary>
    /// <param name="posts">The list of PostsDao objects.</param>
    /// <returns>A list of PostDto objects.</returns>
    private List<PostDto> ConvertPostsToPostDtos(List<PostsDao> posts)
    {
        Logger.LogInfo("Mapping posts to DTOs");
        return posts.Select(post => new PostDto().Mapper(post)).ToList();
    }
}