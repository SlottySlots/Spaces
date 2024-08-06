using SlottyMedia.Database.Daos;

namespace SlottyMedia.Backend.Dtos;

/// <summary>
/// The Post Data Transfer Object
/// </summary>
public class PostDto
{
    //Forum

    /// <summary>
    /// The User who created the post
    /// </summary>
    public int UserDao { get; set; }

    /// <summary>
    /// The UserIds of the Users who liked the post
    /// </summary>
    public List<Guid> Likes { get; set; }

    /// <summary>
    /// When the Post was created
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// The Content of the Post
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// The comments on the post
    /// </summary>
    public CommentDao Comments { get; set; }
}