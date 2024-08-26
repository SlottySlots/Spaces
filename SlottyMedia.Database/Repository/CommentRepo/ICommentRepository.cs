using SlottyMedia.Database.Daos;

namespace SlottyMedia.Database.Repository.CommentRepo;

/// <summary>
///     Interface for the Comment Repository.
/// </summary>
public interface ICommentRepository : IDatabaseRepository<CommentDao>
{
}