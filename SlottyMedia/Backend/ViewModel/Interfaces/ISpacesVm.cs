using SlottyMedia.Backend.Dtos;
using SlottyMedia.Components.Pages;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

/// <summary>
///     This ViewModel represents the state of the <see cref="Spaces" /> Page.
/// </summary>
public interface ISpacesVm
{
    /// <summary>
    ///     A list containing all spaces that should be rendered
    /// </summary>
    List<ForumDto> Forums { get; }

    /// <summary>
    ///     Fetches all forums and populates the <see cref="Forums" /> property.
    /// </summary>
    Task LoadForums();
    
    /// <summary>
    ///    Indicates whether the ViewModel is currently loading data.
    /// </summary>
    public bool IsLoading { get; }
}