using Supabase.Postgrest.Attributes;

namespace SlottyMedia.Backend.Models;

[Table("Role")]
public class RoleDto
{   
    [PrimaryKey("roleID", true)]
    public string RoleId { get; set; }
    
    [Column("role")]
    public string RoleName { get; set; }
    
    [Column("description")]
    public string Description { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}