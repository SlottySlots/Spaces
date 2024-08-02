using SlottyMedia.Backend.Models;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Database.Models;

/// <summary>
/// This class represents the Posts table in the database.
/// </summary>
[Table("Posts")]
public class PostsDto : BaseModel
{
    public PostsDto()
    {
    }

    public PostsDto(string userId, string forumId, string headline, string content)
    {
        UserId = userId;
        ForumId = forumId;
        Headline = headline;
        Content = content;
    }

    /// <summary>
    /// The ID of the Post. This is the Primary Key. It is auto-generated.
    /// </summary>
    [PrimaryKey("postID", false)]
    public string PostId { get; set; }
    
    /// <summary>
    /// The User who created the Post. This is a Reference to the User Table. It is a Foreign Key. Be aware, that this
    /// Field will not be filled when you insert the Post into the Database.
    /// </summary>
    [Reference(typeof(UserDto), true, true, "userID")]
    public UserDto User { get; set; }

    /// <summary>
    /// The ID of the User who created the Post. This is a Foreign Key to the User Table.
    /// </summary>
    [Column("creator_userID")]
    public string UserId { get; set; }

    /// <summary>
    /// The Forum the Post is associated with. This is a Reference to the Forum Table. It is a Foreign Key. Be aware, that this
    /// Field will not be filled when you insert the Post into the Database.
    /// </summary>
    [Reference(typeof(ForumDto), ReferenceAttribute.JoinType.Inner, true, "forumID")]
    public ForumDto Forum { get; set; }
    
    /// <summary>
    /// The ID of the Forum the Post is associated with. This is a Foreign Key to the Forum Table.
    /// </summary>
    [Column("associated_forumID")]
    public string ForumId { get; set; }

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