using SlottyMedia.Backend.Dtos;
using SlottyMedia.Components.Partial.MainLayout;

namespace SlottyMedia.Backend.ViewModel.Partial.MainLayout;

/// <summary>
///     This ViewModel represents the state of the <see cref="SpacesCard" /> component.
/// </summary>
public interface ISpacesCardVm
{
    /// <summary>A list containing all trending spaces</summary>
    List<ForumDto> TrendingSpaces { get; set; }

    /// <summary>A list containing all recent spaces</summary>
    List<ForumDto> RecentSpaces { get; set; }

    /// <summary>
    ///     A dictionary that maps a space ID to the toal number of posts in that
    ///     space. Only spaces listed in <see cref="TrendingSpaces" /> and <see cref="RecentSpaces" />
    ///     will be considered.
    /// </summary>
    Dictionary<Guid, int> NumOfPostsInSpace { get; set; }

    /// <summary>
    ///     Fetches all trending spaces, recent spaces and evaluates how many posts exist per space.
    /// </summary>
    Task Fetch();
}