using SlottyMedia.Database;
using SlottyMedia.Database.Daos;

namespace SlottyMedia.Backend.Services;

public class CommentService
{
    
    /// <summary>
    /// DatabaseActions property.
    /// </summary>
    public IDatabaseActions DatabaseActions { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PostService"/> class.
    /// </summary>
    /// <param name="databaseActions">The database actions interface.</param>
    public CommentService(IDatabaseActions databaseActions)
    {
        DatabaseActions = databaseActions;
    }
    public async Task<CommentDao> GetCommentById(Guid postId)
    {
        try
        {
            var result = await DatabaseActions.GetEntityByField<CommentDao>("commentID", postId.ToString());
        
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            //TODO: Implement how we should handle errors in the View
            throw;
        }

    }
}