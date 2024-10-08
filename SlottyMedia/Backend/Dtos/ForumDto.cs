using SlottyMedia.Database.Daos;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Dtos;

/// <summary>
///     The Forum Data Transfer Object
/// </summary>
public class ForumDto
{
    private static readonly Logging<ForumDto> Logger = new();

    /// <summary>
    ///     The default constructor.
    /// </summary>
    public ForumDto()
    {
        ForumId = Guid.Empty;
        Topic = string.Empty;
        CreatedAt = DateTime.MinValue;
    }

    /// <summary>
    ///     The Forum Id.
    /// </summary>
    public Guid ForumId { get; set; }

    /// <summary>
    ///     The Topic of the Forum.v
    /// </summary>
    public string Topic { get; set; }

    /// <summary>
    ///     The Date and Time the Forum was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    ///     Amount of posts the forum has
    /// </summary>
    public int PostCount { get; set; }

    /// <summary>
    ///     This method maps the ForumDto to a ForumDao.
    /// </summary>
    /// <returns></returns>
    public ForumDao Mapper()
    {
        Logger.LogTrace($"Mapping ForumDto to ForumDao. ForumDto: {this}");

        return new ForumDao
        {
            ForumId = ForumId,
            ForumTopic = Topic,
            CreatedAt = CreatedAt
        };
    }

    /// <summary>
    ///     THis method maps the ForumDao to a ForumDto.
    /// </summary>
    /// <param name="forumDao"></param>
    /// <returns></returns>
    public ForumDto Mapper(ForumDao forumDao)
    {
        Logger.LogTrace($"Mapping ForumDao to ForumDto. ForumDao: {forumDao}");

        return new ForumDto
        {
            ForumId = forumDao.ForumId ?? Guid.Empty,
            Topic = forumDao.ForumTopic ?? string.Empty,
            CreatedAt = forumDao.CreatedAt.LocalDateTime,
            PostCount = forumDao.post_count ?? 0
        };
    }

    /// <summary>
    ///     THis method maps the ForumDao to a ForumDto.
    /// </summary>
    /// <param name="forumDao"></param>
    /// <returns></returns>
    public ForumDto Mapper(TopForumDao forumDao)
    {
        Logger.LogTrace($"Mapping ForumDao to ForumDto. ForumDao: {forumDao}");

        return new ForumDto
        {
            ForumId = forumDao.ForumId ?? Guid.Empty,
            Topic = forumDao.ForumTopic ?? string.Empty,
            PostCount = forumDao.post_count ?? 0
        };
    }

    /// <summary>
    ///     The ToString method returns a string representation of the object.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"ForumId: {ForumId}, Topic: {Topic}; CreatedAt: {CreatedAt}";
    }
}