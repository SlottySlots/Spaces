using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.ViewModel;

/// <summary>
///     Implementation of the IUserVm interface.
/// </summary>
public class UserVm : IUserVm
{
    private static readonly Logging<UserVm> Logger = new();
    private readonly IUserService _userService;

    /// <summary>
    ///     Initializes a new instance of the UserVm class.
    /// </summary>
    /// <param name="userService">The user service to be used.</param>
    public UserVm(IUserService userService)
    {
        _userService = userService;
    }

    /// <inheritdoc />
    public async Task<UserDto> GetUserById(Guid userId)
    {
        try
        {
            var result = await _userService.GetUserDtoById(userId);
            return result;
        }
        catch (Exception e)
        {
            Logger.LogError($"Error while getting user by id. Error: {e.Message}");
            throw;
        }
    }

    /// <inheritdoc />
    public async Task UpdateUser(UserDto user)
    {
        try
        {
            await _userService.UpdateUser(user);
        }
        catch (Exception e)
        {
            Logger.LogError($"Error while updating user. Error: {e.Message}");
        }
    }
}