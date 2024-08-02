using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Database.Models;

/// <summary>
/// This class represents the Comment table in the database.
/// </summary>
[Table("Comment")]
public class CommentDto : BaseModel
{
    public CommentDto()
    {
    }

    public CommentDto(string commentId, string? parentCommentId, string creatorUserId, string postId, string content,
        DateTime createdAt)
    {
        CommentId = commentId;
        ParentCommentId = parentCommentId;
        CreatorUserId = creatorUserId;
        PostId = postId;
        Content = content;
        CreatedAt = createdAt;
    }

    /// <summary> 
    /// The ID of the Comment. This is the Primary Key. It is auto-generated. 
    /// </summary>
    [PrimaryKey("commentID", false)]
    public string CommentId { get; set; }

    /// <summary> 
    /// The ID of the Parent Comment. This is only set when there is a Parent Comment 
    /// </summary>
    [Column("parent_commentID")]
    public string? ParentCommentId { get; set; }

    /// <summary> 
    /// The ID of the User who created the Comment. This is a Foreign Key to the User Table 
    /// </summary>
    [Column("creator_UserID")]
    public string CreatorUserId { get; set; }

    /// <summary> 
    /// The ID of the Post the Comment is related to. This is a Foreign Key to the Post Table 
    /// </summary>
    [Column("corresponding_PostID")]
    public string PostId { get; set; }

    /// <summary> 
    /// The Content of the Comment 
    /// </summary>
    [Column("content")]
    public string Content { get; set; }

    /// <summary> 
    /// The Date and Time the Comment was created 
    /// </summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}