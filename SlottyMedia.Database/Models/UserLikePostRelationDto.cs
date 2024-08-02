using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Database.Models;

/// <summary>
/// This class represents the User_Like_Post_Relation table in the database.
/// </summary>
[Table("User_Like_Post_Relation")]
public class UserLikePostRelationDto : BaseModel
{
    public UserLikePostRelationDto()
    {
    }

    public UserLikePostRelationDto(string userId, string postId)
    {
        UserId = userId;
        PostId = postId;
    }

    /// <summary>
    /// The ID of the User_Like_Post_Relation. This is the Primary Key. It is auto-generated.
    /// </summary>
    [PrimaryKey("userLikePostRelationID", false)]
    public string UserLikePostRelationId { get; set; }
    
    /// <summary>
    /// The ID of the User who liked the Post. This is a Foreign Key to the User Table.
    /// </summary>
    [Column("userID")]
    public string UserId { get; set; }
    
    /// <summary>
    /// The ID of the Post that was liked. This is a Foreign Key to the Post Table.
    /// </summary>
    [Column("postID")]
    public string PostId { get; set; }

    /// <summary>
    /// The Date and Time the User_Like_Post_Relation was created.
    /// </summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}