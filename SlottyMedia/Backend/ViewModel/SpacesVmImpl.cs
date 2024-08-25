using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.LoggingProvider;


namespace SlottyMedia.Backend.ViewModel;


/// <inheritdoc />
public class SpacesVmImpl : ISpacesVm
{
    private readonly IForumService _forumService;
    private static readonly Logging<SpacesVmImpl> Logger = new();
    
    /// <inheritdoc />
    public List<ForumDto> Forums { get; private set; }

    /// <summary>Initializes this ViewModel</summary>
    public SpacesVmImpl(IForumService forumService)
    {
        _forumService = forumService ?? throw new ArgumentNullException(nameof(forumService));
        Forums = new List<ForumDto>();
    }

    /// <inheritdoc />
    public async Task LoadForums()
    {
        try
        {
            var forums = await _forumService.GetForums();
            Forums.Clear();
            foreach (var forum in forums)
            {
                Forums.Add(forum);
            }
        }
        catch (Exception ex)
        {
            Logger.LogError($"An error occurred while loading forums: {ex.Message}");
        }

    }
}