using Supabase.Postgrest.Attributes;

namespace SlottyMedia.Backend.Models;

[Supabase.Postgrest.Attributes.Table("Forum")]
public class ForumDto
{
    [PrimaryKey("forumID", true)]
    public int ForumId { get; set; }
    
    [Reference(typeof(UserDto))]
    public string CreatorUserId { get; set; }
    
    [Column("forumTopic")]
    public string ForumTopic { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    
}