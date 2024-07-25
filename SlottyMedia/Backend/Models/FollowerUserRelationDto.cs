using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Backend.Models;

/// <summary>
/// This class represents the Follower_User_Relation table in the database.
/// </summary>
[Table("Follower_User_Relation")]
public class FollowerUserRelationDto : BaseModel
{
    /// <summary>
    /// The ID of the Follower_User_Relation. This is the Primary Key. It is auto-generated.
    /// </summary>
    [PrimaryKey("followerUserRelationID", true)]
    public int FollowerUserRelationId { get; set; }

    /// <summary>
    /// The ID of the User who is following another User. This is a Foreign Key to the User Table.
    /// </summary>
    [Column("userIsFollowing")]
    public string FollowerUserId { get; set; }

    /// <summary>
    /// The ID of the User who is being followed. This is a Foreign Key to the User Table.
    /// </summary>
    [Column("userIsFollowed")]
    public string FollowedUserId { get; set; }

    /// <summary>
    /// The Date and Time the Follower_User_Relation was created.
    /// </summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}