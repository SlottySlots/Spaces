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
    /// Inserts a new post into the database.
    /// </summary>
    /// <param name="post">The post to insert.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the inserted post.</returns>
    public async Task<PostsDao> InsertPost(string title, string content, Guid creatorUserID, Guid forumID)
    {
        try
        {
            var post = new PostsDao()
            {
                Headline = title,
                Content = content,
                UserId = creatorUserID,
                ForumId = forumID
            };

            var insertedPost = await _databaseActions.Insert(post);
            return insertedPost;
        }
        catch (Exception e)
        {
            //TODO Implement how we should handle errors in the View
            throw;
        }
    }


    /// <summary>
    /// Updates an existing post in the database.
    /// </summary>
    /// <param name="post">The post to update.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated post.</returns>
    public async Task<PostsDao> UpdatePost(PostsDao post)
    {
        try
        {
            var updatedPost = await _databaseActions.Update(post);
            return updatedPost;
        }
        catch (Exception e)
        {
            //TODO Implement how we should handle errors in the View
            throw;
        }
    }

    /// <summary>
    /// Deletes a post from the database.
    /// </summary>
    /// <param name="post">The post to delete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result indicates whether the deletion was successful.</returns>
    public async Task<bool> DeletePost(PostsDao post)
    {
        try
        {
            var result = await _databaseActions.Delete<PostsDao>(post);
            return result;
        }
        catch (Exception e)
        {
            //TODO Implement how we should handle errors in the View
            throw;
        }
    }

    /// <summary>
    /// Retrieves a list of post titles from a forum for a given user, limited by the specified number.
    /// </summary>
    /// <param name="userID">The ID of the user.</param>
    /// <param name="limit">The maximum number of posts to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of post titles.</returns>
    public async Task<List<string>> GetPostsFromForum(Guid userId, int limit)
    {
        try
        {
            // Fetch posts from the database based on the user ID and limit
            var posts = await _databaseActions.GetEntitiesWithSelectorById<PostsDao>(
                x => new[] { x.Forum },
                "creator_userID",
                userId.ToString(), limit,
                ("created_at", Constants.Ordering.Descending, Constants.NullPosition.Last)
            );

            // Return the list of forum names associated with the posts
            return posts.Select(post => post.Forum.ForumTopic).ToList();
        }
        catch (Exception e)
        {
            //TODO Implement how we should handle errors in the View
            throw;
        }
    }
}