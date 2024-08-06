using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using Supabase.Postgrest;

namespace SlottyMedia.Backend.Services;

/// <summary>
/// This class represents the Post Service. It is used to interact with the Post table in the database.
/// </summary>
public class PostService : IPostService
{
    private readonly IDatabaseActions _databaseActions;

    /// <summary>
    /// Initializes a new instance of the <see cref="PostService"/> class.
    /// </summary>
    /// <param name="databaseActions">The database actions interface.</param>
    public PostService(IDatabaseActions databaseActions)
    {
        _databaseActions = databaseActions;
    }

    /// <summary>
    /// Retrieves a list of post titles from a forum for a given user, limited by the specified number.
    /// </summary>
    /// <param name="userID">The ID of the user.</param>
    /// <param name="limit">The maximum number of posts to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of post titles.</returns>
    public async Task<List<string>> GetPostsFromForum(Guid userID, int limit)
    {
        try
        {
            // Fetch posts from the database based on the user ID and limit
            var posts = await _databaseActions.GetEntitiesWithSelectorById<PostsDao>(
                x => new[] { x.Forum },
                "creator_userID",
                userID.ToString(), limit,
                ("created_at", Constants.Ordering.Descending, Constants.NullPosition.Last)
            );

            // Return the list of forum names associated with the posts
            return posts.Select(post => post.Forum.TableName).ToList();
        }
        catch (Exception e)
        {
            // Log the exception and rethrow it
            Console.WriteLine(e);
            throw;
        }
    }
}