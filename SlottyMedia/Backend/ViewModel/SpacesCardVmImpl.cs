using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.ViewModel;

/// <inheritdoc />
public class SpacesCardVmImpl : ISpacesCardVm
{
    private static readonly Logging<SpacesCardVmImpl> Logger = new();
    private readonly IForumService _forumService;


    /// <summary>Initializes this ViewModel</summary>
    public SpacesCardVmImpl(IForumService forumService)
    {
        _forumService = forumService;
        TrendingSpaces = new List<ForumDto>();
        RecentSpaces = new List<ForumDto>();
        NumOfPostsInSpace = new Dictionary<Guid, int>();
    }

    /// <inheritdoc />
    public List<ForumDto> TrendingSpaces { get; set; }

    /// <inheritdoc />
    public List<ForumDto> RecentSpaces { get; set; }

    /// <inheritdoc />
    public Dictionary<Guid, int> NumOfPostsInSpace { get; set; }

    /// <inheritdoc />
    public async Task Fetch()
    {
        try
        {
            // Calculate the number of posts in each forum and determine trending spaces
            await DetermineTrendingSpaces();

            // Determine the most recent spaces based on creation date
            await DetermineRecentSpaces();
        }
        catch (Exception e)
        {
            Logger.LogError($"An error occurred while fetching spaces: {e.Message}");
        }
        // Fetch all forums from the service
        //var forums = await _forumService.GetForums();

        //await FetchNumOfPostsInSpaces(forums);
    }

    private async Task DetermineTrendingSpaces()
    {
        TrendingSpaces = await _forumService.GetTopForums();

        // Log the trending forums for debugging purposes
        Logger.LogDebug("Trending Spaces determined");
    }

    private async Task DetermineRecentSpaces()
    {
        // Sort forums by creation date in descending order and take the top 3
        RecentSpaces = await _forumService.DetermineRecentSpaces();

        // Log the recent forums for debugging purposes
        Logger.LogDebug("Recent Spaces determined");
    }
}