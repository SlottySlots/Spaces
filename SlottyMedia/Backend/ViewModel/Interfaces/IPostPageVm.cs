using SlottyMedia.Backend.Dtos;
using SlottyMedia.Components.Pages;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

/// <summary>
///     This ViewModel represents the state of the <see cref="PostPage" />.
/// </summary>
public interface IPostPageVm
{
    /// <summary>Indicates whether the post is being fetched (i.e. the whole page is loading)</summary>
    bool IsLoadingPage { get; }

    /// <summary>Indicates whether additional comments are being fetched</summary>
    bool IsLoadingComments { get; }

    /// <summary>The post that will be showcased. If <c>null</c>, then the post is either being fetched or it does not exist.</summary>
    PostDto? Post { get; }

    /// <summary>The comments that belong to the post</summary>
    List<CommentDto> Comments { get; }

    /// <summary>Indicates the total number of comments in the showcased post</summary>
    int TotalNumberOfComments { get; }

    /// <summary>
    ///     Attempts to load the given post. If no such post exists, then <see cref="Post" /> will be <c>null</c>.
    ///     Otherwise, it will be a <see cref="PostDto" /> that corresponds to the requested post.
    /// </summary>
    /// <param name="postId">The ID of the post to showcase</param>
    Task LoadPage(Guid postId);

    /// <summary>
    ///     Attempts to load more comments than were already showcased. Does nothing if no further comments exist.
    /// </summary>
    Task LoadMoreComments();
}