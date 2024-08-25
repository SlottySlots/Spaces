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

    public SpacesCardVmImpl(IForumService forumService, IPostService postService)
    {
        _forumService = forumService;
        _postService = postService;
        TrendingSpaces = new List<ForumDto>();
        RecentSpaces = new List<ForumDto>();
        NumOfPostsInSpace = new Dictionary<Guid, int>();
    }

    public async Task Fetch()
    {
        // Fetch all forums from the service
        var forums = await _forumService.GetForums();

        await FetchNumOfPostsInSpaces(forums);

        // Calculate the number of posts in each forum and determine trending spaces
        DetermineTrendingSpaces(forums);
            
        // Determine the most recent spaces based on creation date
        DetermineRecentSpaces(forums);
    }

    private async Task FetchNumOfPostsInSpaces(List<ForumDto> spaces)
    {
        foreach (var space in spaces)
        {
            if (NumOfPostsInSpace.ContainsKey(space.ForumId))
                continue;
            var postCount = await _postService.GetPostCountByForumId(space.ForumId);
            NumOfPostsInSpace.TryAdd(space.ForumId, postCount);
        }
    }

    private void DetermineTrendingSpaces(List<ForumDto> forums)
    {
        var query =
            from space in forums
            from kvp in NumOfPostsInSpace
            where space.ForumId == kvp.Key
            orderby kvp.Value descending
            select space;
        TrendingSpaces = query.Take(3).ToList();

        // Log the trending forums for debugging purposes
        Logger.LogDebug("Trending Spaces determined:");
        foreach (var forum in TrendingSpaces)
        {
            Logger.LogDebug($"Forum ID: {forum.ForumId}, Post Count: {NumOfPostsInSpace[forum.ForumId]}");
        }
    }
    
    private void DetermineRecentSpaces(List<ForumDto> forums)
    {
        // Sort forums by creation date in descending order and take the top 3
        RecentSpaces = forums
            .OrderByDescending(f => f.CreatedAt)
            .Take(3)
            .ToList();

        // Log the recent forums for debugging purposes
        Logger.LogDebug("Recent Spaces determined:");
        foreach (var forum in RecentSpaces)
        {
            Logger.LogDebug($"Forum ID: {forum.ForumId}, Created At: {forum.CreatedAt}");
        }
    }
    
    
}
