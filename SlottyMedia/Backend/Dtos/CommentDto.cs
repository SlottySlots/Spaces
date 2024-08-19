using SlottyMedia.Database.Daos;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Dtos;

/// <summary>
///     The Comment Data Transfer Object
/// </summary>
public class CommentDto
{
    private static readonly Logging<CommentDto> Logger =new ();
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="CommentDto" /> class.
    /// </summary>
    public CommentDto()
    {
        CommentId = Guid.Empty;
        ParentComment = new List<CommentDto>();
        CreatorUserId = null;
        PostId = Guid.Empty;
        Content = string.Empty;
        CreatedAt = DateTime.MinValue;
    }

    /// <summary>
    ///     Gets or sets the Comment Id.
    /// </summary>
    public Guid CommentId { get; set; }

    /// <summary>
    ///     Gets or sets the list of parent comments.
    /// </summary>
    public List<CommentDto> ParentComment { get; set; }

    /// <summary>
    ///     Gets or sets the ID of the user who created the comment.
    /// </summary>
    public Guid? CreatorUserId { get; set; }

    /// <summary>
    ///     Gets or sets the ID of the post the comment is related to.
    /// </summary>
    public Guid PostId { get; set; }

    /// <summary>
    ///     Gets or sets the content of the comment.
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    ///     Gets or sets the date and time when the comment was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    ///     This method maps the Comment Dto to the Comment Dao.
    /// </summary>
    /// <returns></returns>
    public CommentDao Mapper()
    {
        Logger.LogInfo($"Mapping CommentDto to CommentDao. Parameters: CommentID = {CommentId}, CreatorUserId = {CreatorUserId}, PostId = {PostId}, Content = {Content}, CreatedAt = {CreatedAt}");
        return new CommentDao
        {
            CommentId = CommentId,
            ParentCommentId = ParentComment.FirstOrDefault()?.CommentId,
            CreatorUserId = CreatorUserId,
            PostId = PostId,
            Content = Content,
            CreatedAt = CreatedAt
        };
    }

    /// <summary>
    ///     Maps the Comment Dao to the Comment Dto.
    /// </summary>
    /// <param name="comment"></param>
    public CommentDto Mapper(CommentDao comment)
    {
        Logger.LogInfo($"Mapping CommentDao to CommentDto. Parameters: CommentID = {CommentId}, CreatorUserId = {CreatorUserId}, PostId = {PostId}, Content = {Content}, CreatedAt = {CreatedAt}");
        
        CommentId = comment.CommentId ?? Guid.Empty;
        ParentComment = comment.ParentComment.Select(pc => new CommentDto().Mapper(pc)).ToList();
        CreatorUserId = comment.CreatorUserId;
        PostId = comment.PostId ?? Guid.Empty;
        Content = comment.Content ?? string.Empty;
        CreatedAt = comment.CreatedAt;

        return this;
    }
}