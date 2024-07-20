using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Backend.Models;

[Supabase.Postgrest.Attributes.Table("User")]
public class UserDto : BaseModel
{
   [PrimaryKey("userID", false)]
   public string UserId { get; set; }
   
   [Supabase.Postgrest.Attributes.Reference(typeof(RoleDto))]
   public int RoleId { get; set; }
   
   [Supabase.Postgrest.Attributes.Column("userName")]
   public string UserName { get; set; }
   
   [Supabase.Postgrest.Attributes.Column("description")]
   public string Description { get; set; }
   
   [Supabase.Postgrest.Attributes.Column("profilePic")]
   public long ProfilePic { get; set; }
   
   [Supabase.Postgrest.Attributes.Column("created_at")]
   public DateTime CreatedAt { get; set; }
   
}