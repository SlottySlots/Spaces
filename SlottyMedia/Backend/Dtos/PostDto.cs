using SlottyMedia.Database.Daos;

namespace SlottyMedia.Backend.Dtos;

/// <summary>
/// The Post Data Transfer Object
/// </summary>
public class PostDto
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PostDto"/> class.
    /// </summary>
    public PostDto()
    {
        Forum = new ForumDto();
        PostId = Guid.Empty;
        UserDao = 0;
        Likes = new List<Guid>();
        CreatedAt = DateTime.MinValue;
        Content = string.Empty;
        Comments = new CommentDao();
    }

    /// <summary>
    /// Gets or sets the forum associated with the post.
    /// </summary>
    public ForumDto Forum { get; set; }

    /// <summary>
    /// Gets or sets the post ID.
    /// </summary>
    public Guid PostId { get; set; }

    /// <summary>
    /// Gets or sets the user ID of the user who created the post.
    /// </summary>
    public int UserDao { get; set; }

    /// <summary>
    /// Gets or sets the list of user IDs who liked the post.
    /// </summary>
    public List<Guid> Likes { get; set; }

    /// <summary>
    /// Gets or sets the creation date of the post.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the content of the post.
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// Gets or sets the comments on the post.
    /// </summary>
    public CommentDao Comments { get; set; }
}