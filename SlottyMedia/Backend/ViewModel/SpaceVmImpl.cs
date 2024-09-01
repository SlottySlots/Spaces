using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.ViewModel;

/// <summary>
/// Implements ISpaceVm to manage the state of the Space Page.
/// </summary>
public class SpaceVmImpl : ISpaceVm
{
    private static readonly Logging<SpaceVmImpl> Logger = new();
    private readonly IForumService _forumService;
    private readonly IPostService _postService;
    
    public DateTime CreatedAt { get; private set; }
    public string Topic { get; private set; } = string.Empty;
    public int PostCount { get; private set; }
    
    //public string CreatedBy { get; private set; }

    /// <summary>
    /// Initializes the ViewModel with the necessary services.
    /// </summary>
    public SpaceVmImpl(IForumService forumService, IPostService postService)
    {
        _forumService = forumService ?? throw new ArgumentNullException(nameof(forumService));
        _postService = postService ?? throw new ArgumentNullException(nameof(postService));
    }

    /// <inheritdoc />
    public async Task<ForumDto?> GetSpaceInformation(string name)
    {
        try
        {
            return await _forumService.GetForumByName(name);
        }
        catch (Exception ex)
        {
            Logger.LogError($"An error occurred while fetching space information for '{name}': {ex.Message}");
            return null;
        }
    }

    /// <inheritdoc />
    public async Task LoadSpaceDetails(string name)
    {
        try
        {
            var space = await GetSpaceInformation(name);
            if (space != null)
            {
                PostCount = space.PostCount;
                CreatedAt = space.CreatedAt;
                Topic = space.Topic;
                // CreatedBy = space.CreatedBy; 
            }
        }
        catch (Exception ex)
        {
            Logger.LogError($"An error occurred while loading space details for '{name}': {ex.Message}");
        }
    }
    
    
    /// <summary>
    /// Gets post by forum id
    /// </summary>
    /// <param name="forumId">
    /// Forum the posts belongs to
    /// </param>
    /// <param name="startOfSet">
    /// Starting index on which the follows are retrieved (they are sorted by date)
    /// </param>
    /// <param name="endOfSet">
    /// Ending index used to slice the posts in a specific intervall
    /// </param>
    /// <returns>
    /// List of PostDtos
    /// </returns>
    public async Task<List<PostDto>> GetPostsByForumId(Guid forumId, int startOfSet, int endOfSet)
    {
        var posts = await _postService.GetPostsByForumId(forumId, startOfSet, endOfSet);
        return posts;
    }
    
    
    
}