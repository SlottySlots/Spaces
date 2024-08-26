using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Database.Daos;

/// <summary>
///     This class represents the Forum table in the database.
/// </summary>
[Table("Forum")]
public class TopForumDao : BaseModel
{
    /// <summary>
    ///     The default constructor.
    /// </summary>
    public TopForumDao()
    {
        ForumTopic = string.Empty;
    }

    /// <summary>
    ///     The constructor with parameters.
    /// </summary>
    /// <param name="creatorUserId">The Id of the User who created the Forum</param>
    /// <param name="forumTopic">The Topic of the Forum</param>
    public TopForumDao(Guid creatorUserId, string forumTopic)
    {
        ForumTopic = forumTopic;
    }

    /// <summary>
    ///     The ID of the Forum. This is the Primary Key. It is auto-generated.
    /// </summary>
    [PrimaryKey("forumID")]
    public Guid? ForumId { get; set; }

    /// <summary>
    ///     The Title of the Forum.
    /// </summary>
    [Column("forumTopic")]
    public string? ForumTopic { get; set; }

    /// <summary>
    ///     The Count of Posts in the Forum.
    /// </summary>
    [Column()]
    public int? post_count { get; set; }

    /// <summary>
    ///     The ToString method returns a string representation of the object.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"ForumId: {ForumId}, PostCount{post_count}, ForumTopic: {ForumTopic}";
    }
}