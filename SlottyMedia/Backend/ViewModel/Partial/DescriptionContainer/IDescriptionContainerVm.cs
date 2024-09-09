namespace SlottyMedia.Backend.ViewModel.Partial.DescriptionContainer;

/// <summary>
///     Interface for the DescriptionContainer ViewModel.
/// </summary>
public interface IDescriptionContainerVm
{
    /// <summary>
    ///     Flag to determine whether to show the description text or the input field.
    /// </summary>
    bool ShowDescriptionText { get; }

    /// <summary>
    ///     Submits the description asynchronously.
    /// </summary>
    /// <param name="description">The description text to submit.</param>
    /// <param name="userId">The ID of the user to update the description for.</param>
    Task SubmitDescriptionAsync(string? description, Guid? userId);
}