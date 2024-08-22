using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.PostExceptions;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.LoggingProvider;
using Supabase.Postgrest;

namespace SlottyMedia.Backend.Services;

/// <summary>
///     This class represents the Post Service. It is used to interact with the Post table in the database.
/// </summary>
public class PostService : IPostService
{
    private static readonly Logging<PostService> Logger = new();

    private readonly Supabase.Client _supabaseClient;

    /// <summary>
    ///     Initializes a new instance of the <see cref="PostService" /> class.
    /// </summary>
    /// <param name="databaseActions">The database actions interface.</param>
    public PostService(IDatabaseActions databaseActions, Supabase.Client supabaseClient)
    {
        Logger.LogInfo("PostService initialized");
        DatabaseActions = databaseActions;
        _supabaseClient = supabaseClient;
    }

    /// <summary>
    ///     Gets or sets the database actions interface.
    /// </summary>
    public IDatabaseActions DatabaseActions { get; set; }

    /// <summary>
    ///     Inserts a new post into the database.
    /// </summary>
    /// <param name="content">The content of the post.</param>
    /// <param name="creatorUserId">The ID of the user who created the post.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the inserted post.</returns>
    public async Task<PostDto> InsertPost(string content, Guid creatorUserId, Guid forumId)
    {
        try
        {
            var post = new PostsDao
            {
                Headline = "",
                Content = content,
                UserId = creatorUserId,
                ForumId = forumId,
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

    /// <summary>
    ///     Updates an existing post in the database.
    /// </summary>
    /// <param name="post">The post to update.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated post.</returns>
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

    /// <summary>
    ///     Deletes a post from the database.
    /// </summary>
    /// <param name="post">The post to delete.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result indicates whether the deletion was
    ///     successful.
    /// </returns>
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

    /// <summary>
    ///     Retrieves a list of post titles from a forum for a given user, limited by the specified number.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="startOfSet">The starting index of the set.</param>
    /// <param name="endOfSet">The ending index of the set.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of post titles.</returns>
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

    /// <summary>
    ///     Retrieves a list of posts from the database based on the given userId.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="startOfSet">The starting index of the set.</param>
    /// <param name="endOfSet">The ending index of the set.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of PostDto objects.</returns>
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

    /// <inheritdoc />
    public async Task<List<Guid>> GetAllPosts(int page, int pageSize)
    {
        var query = await _supabaseClient
            .From<PostsDao>()
            .Range((page - 1) * pageSize, (page - 1) * pageSize + pageSize)
            .Order("created_at", Constants.Ordering.Descending)
            .Get();
        var daoList = query.Models;
        var result =
            from dao in daoList
            where dao.PostId is not null
            select dao.PostId;
        return result.OfType<Guid>().ToList();
    }

    public async Task<PostDto?> GetPostById(Guid postId)
    {
        var query = await _supabaseClient
            .From<PostsDao>()
            .Where(post => post.PostId == postId)
            .Get();
        if (query.Model is null)
            return null;
        return new PostDto().Mapper(query.Model);
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
        throw new PostGeneralException($"A database error occurred while counting the forums. UserID: {userId}", ex);
    }
    catch (Exception ex)
    {
        throw new PostGeneralException($"An error occurred while counting the forums. UserID: {userId}", ex);
    }
}
}