using Microsoft.IdentityModel.Tokens;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.ViewModel;

/// <summary>
///     The DescriptionContainerVmImpl class is responsible for handling the logic for the DescriptionContainerVm.
/// </summary>
public class DescriptionContainerVmImpl : IDescriptionContainerVm
{
    private readonly Logging<DescriptionContainerVmImpl> _logger = new();
    private readonly IUserService _userService;

    /// <summary>
    ///     The constructor for the DescriptionContainerVmImpl.
    /// </summary>
    /// <param name="userService"></param>
    public DescriptionContainerVmImpl(IUserService userService)
    {
        _userService = userService;
        ShowDescriptionText = true;
    }

    /// <summary>
    ///     Flag to determine whether to show the description text or the input field.
    /// </summary>
    public bool ShowDescriptionText { get; private set; }

    /// <inheritdoc />
    public async Task SubmitDescriptionAsync(string? description, Guid? userId)
    {
        if (userId is not null)
            try
            {
                ShowDescriptionText = false;
                if (!description.IsNullOrEmpty())
                {
                    var user = await _userService.GetUserDaoById(userId.Value);
                    if (description != user.Description && description!.Length <= 200)
                    {
                        user.Description = description;
                        await _userService.UpdateUser(user);
                        ShowDescriptionText = true;
                    }
                    else if (description!.Length > 200)
                    {
                        ShowDescriptionText = true;
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error while updating user description.");
            }
    }
}