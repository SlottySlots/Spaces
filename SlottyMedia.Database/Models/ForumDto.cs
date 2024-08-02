using SlottyMedia.Database.Models;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Backend.Models;

/// <summary>
/// This class represents the Forum table in the database.
/// </summary>
[Table("Forum")]
public class ForumDto : BaseModel
{
    public ForumDto()
    {
    }

    public ForumDto(string forumId, string creatorUserId, string forumTopic, DateTime createdAt)
    {
        ForumId = forumId;
        CreatorUserId = creatorUserId;
        ForumTopic = forumTopic;
        CreatedAt = createdAt;
    }

    /// <summary>
    /// The ID of the Forum. This is the Primary Key. It is auto-generated.
    /// </summary>
    [PrimaryKey("forumID", false)]
    public string ForumId { get; set; }

    /// <summary>
    /// The ID of the User who created the Forum. This is a Foreign Key to the User Table.
    /// </summary>
    [Column("creator_userID")]
    public string CreatorUserId { get; set; }

    /// <summary>
    /// The Title of the Forum.
    /// </summary>
    [Column("forumTopic")]
    public string ForumTopic { get; set; }

    /// <summary>
    /// Created Date and Time of the Forum.
    /// </summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}