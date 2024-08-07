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

    public CommentDto(string creatorUserId, string postId, string content, string? parentCommentId = null)
    {
        ParentCommentId = parentCommentId;
        CreatorUserId = creatorUserId;
        PostId = postId;
        Content = content;
    }

    /// <summary> 
    /// The ID of the Comment. This is the Primary Key. It is auto-generated. 
    /// </summary>
    [PrimaryKey("commentID")]
    public string? CommentId { get; set; }

    /// <summary> 
    /// The ID of the Parent Comment. This is only set when there is a Parent Comment 
    /// </summary>
    [Column("parent_commentID")]
    public string? ParentCommentId { get; set; }

    /// <summary>
    /// The User who created the Comment. This is a Reference to the User Table. It is a Foreign Key. Be aware, that this
    /// will not be filled when you insert the Comment into the Database.
    /// </summary>
    [Reference(typeof(UserDto), ReferenceAttribute.JoinType.Inner, true, "userID")]
    public UserDto? CreatorUser { get; set; }

    /// <summary> 
    /// The ID of the User who created the Comment. This is a Foreign Key to the User Table 
    /// </summary>
    [Column("creator_UserID")]
    public string? CreatorUserId { get; set; }

    /// <summary>
    /// The Post the Comment is related to. This is a Reference to the Post Table. It is a Foreign Key. Be aware, that this
    /// will not be filled when you insert the Comment into the Database.
    /// </summary>
    [Reference(typeof(PostsDto), ReferenceAttribute.JoinType.Inner, true, "postID")]
    public PostsDto? Post { get; set; }

    /// <summary> 
    /// The ID of the Post the Comment is related to. This is a Foreign Key to the Post Table 
    /// </summary>
    [Column("corresponding_PostID")]
    public string? PostId { get; set; }

    /// <summary> 
    /// The Content of the Comment 
    /// </summary>
    [Column("content")]
    public string? Content { get; set; }

    /// <summary> 
    /// The Date and Time the Comment was created 
    /// </summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}