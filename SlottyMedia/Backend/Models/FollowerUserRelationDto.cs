using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Backend.Models;

[Table("Follower_User_Relation")]
public class FollowerUserRelationDto : BaseModel
{
    [PrimaryKey("followerUserRelationID", true)]
    public int FollowerUserRelationId { get; set; }

    [Column("userIsFollowing")] public string FollowerUserId { get; set; }

    [Column("userIsFollowed")] public string FollowedUserId { get; set; }

    [Column("created_at")] public DateTime CreatedAt { get; set; }
}