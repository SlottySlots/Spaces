using Supabase.Postgrest.Attributes;

namespace SlottyMedia.Backend.Models;

[Table("Posts")]
public class PostsDto
{
    [PrimaryKey("postID", true)]
    public int PostId { get; set; }
    
    [Reference(typeof(UserDto))]
    public string UserId { get; set; }
    
    [Reference(typeof(ForumDto))]
    public int ForumId { get; set; }
    
    [Column("headline")]
    public string Headline { get; set; }
    
    [Column("content")]
    public string Content { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}