using Supabase.Postgrest.Attributes;

namespace SlottyMedia.Backend.Models;

[Table("Follower_User_Relation")]
public class FollowerUserRelationDto
{
    [PrimaryKey("followerUserRelationID", true)]
    public int FollowerUserRelationId { get; set; }
    
    [Reference(typeof(UserDto))]
    public string FollowerUserId { get; set; }
    
    [Reference(typeof(UserDto))]
    public string FollowedUserId { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}