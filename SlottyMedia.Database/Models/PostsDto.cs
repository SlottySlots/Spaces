using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Database.Models;

/// <summary>
/// This class represents the Posts table in the database.
/// </summary>
[Table("Posts")]
public class PostsDto : BaseModel
{
    /// <summary>
    /// The ID of the Post. This is the Primary Key. It is auto-generated.
    /// </summary>
    [PrimaryKey("postID", true)]
    public int PostId { get; set; }

    /// <summary>
    /// The ID of the User who created the Post. This is a Foreign Key to the User Table.
    /// </summary>
    [Column("creator_userID")]
    public string UserId { get; set; }

    /// <summary>
    /// The ID of the Forum the Post is associated with. This is a Foreign Key to the Forum Table.
    /// </summary>
    [Column("associated_forumID")]
    public int ForumId { get; set; }

    /// <summary>
    /// The Headline of the Post.
    /// </summary>
    [Column("headline")]
    public string Headline { get; set; }

    /// <summary>
    /// The Content of the Post.
    /// </summary>
    [Column("content")]
    public string Content { get; set; }

    /// <summary>
    /// The Date and Time the Post was created.
    /// </summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}