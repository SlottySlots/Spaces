using SlottyMedia.Backend.Dtos;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

/// <summary>
///     Interface for the Comment ViewModel.
/// </summary>
public interface ICommentVm
{
    /// <summary>
    ///     Gets the user information data transfer object to be rendered.
    /// </summary>
    UserInformationDto UserInformation { get; }

    /// <summary>
    ///     Gets a value indicating whether the data is still loading.
    /// </summary>
    bool IsLoading { get; }

    /// <summary>
    ///     Initializes the ViewModel with the specified user ID.
    /// </summary>
    /// <param name="userId">The ID of the user to load information for.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task Initialize(Guid? userId);
}