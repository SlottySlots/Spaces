using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.ViewModel;

public class SpacesCardVmImpl : ISpacesCardVm
{
    private readonly IForumService _forumService;
    private readonly IPostService _postService;
    private static readonly Logging<SpacesCardVmImpl> Logger = new();

    public List<ForumDto> TrendingSpaces { get; set; }
    public List<ForumDto> RecentSpaces { get; set; }
    public Dictionary<Guid, int> NumOfPostsInSpace { get; set; }

    public SpacesCardVmImpl(IForumService forumService)
    {
        _forumService = forumService ?? throw new ArgumentNullException(nameof(forumService));
        TrendingSpaces = new List<ForumDto>();
        RecentSpaces = new List<ForumDto>();
        NumOfPostsInSpace = new Dictionary<Guid, int>();
    }

    public async Task Fetch()
    {
        try
        {
            // Fetch all forums from the service
            var forums = await _forumService.GetForums();

            // Calculate the number of posts in each forum and determine trending spaces
            TrendingSpaces = await DetermineTrendingSpaces(forums);
            
            // Determine the most recent spaces based on creation date
            RecentSpaces = await DetermineRecentSpaces(forums);
        }
        catch (Exception ex)
        {
            Logger.LogError($"An error occurred while fetching trending spaces: {ex.Message}");
        }
    }

    private async Task<List<ForumDto>> DetermineTrendingSpaces(List<ForumDto> forums)
    {
        var forumPostCounts = new Dictionary<ForumDto, int>();

        foreach (var forum in forums)
        {
            try
            {
                int postCount = await _postService.GetPostCountByForumId(forum.ForumId);
                forumPostCounts.Add(forum, postCount);
                NumOfPostsInSpace[forum.ForumId] = postCount;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Failed to retrieve post count for forum ID {forum.ForumId}: {ex.Message}");
            }
        }

        // Sort forums by post count in descending order and take top 3
        var trendingForums = forumPostCounts
            .OrderByDescending(kvp => kvp.Value)
            .Take(3)
            .Select(kvp => kvp.Key)
            .ToList();

        // Log the trending forums for debugging purposes
        Logger.LogDebug("Trending Spaces determined:");
        foreach (var forum in trendingForums)
        {
            Logger.LogDebug($"Forum ID: {forum.ForumId}, Post Count: {NumOfPostsInSpace[forum.ForumId]}");
        }

        return trendingForums;
    }
    
    private async Task<List<ForumDto>> DetermineRecentSpaces(List<ForumDto> forums)
    {
        try
        {
            
            // Sort forums by creation date in descending order and take the top 3
            var recentForums = forums
                .OrderByDescending(f => f.CreatedAt)
                .Take(3)
                .ToList();

            // Log the recent forums for debugging purposes
            Logger.LogDebug("Recent Spaces determined:");
            foreach (var forum in recentForums)
            {
                Logger.LogDebug($"Forum ID: {forum.ForumId}, Created At: {forum.CreatedAt}");
            }

            return recentForums;
        }
        catch (Exception ex)
        {
            Logger.LogError($"An error occurred while determining recent spaces: {ex.Message}");
            throw;
        }
    }
    
    
}
