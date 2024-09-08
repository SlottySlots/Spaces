using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.LoggingProvider;
using Supabase.Gotrue;

namespace SlottyMedia.Backend.ViewModel;

/// <summary>
///     ViewModel of the MainLayout which is essentially the root view of SlottyMedia
/// </summary>
public class MainLayoutVmImpl : IMainLayoutVm
{
    /// <summary>
    ///     AuthService used for restoring a session
    /// </summary>
    private readonly IAuthService _authService;

    /// <summary>
    ///     Logger used to log restores sessions.
    /// </summary>
    private readonly Logging<MainLayoutVmImpl> _logger = new();

    private readonly IUserService _userService;

    /// <summary>
    ///     Ctor used for dep inject
    /// </summary>
    /// <param name="authService"></param>
    /// <param name="userService"></param>
    public MainLayoutVmImpl(IAuthService authService, IUserService userService)
    {
        _authService = authService;
        _userService = userService;
    }

    /// <summary>
    ///     The user information to be displayed
    /// </summary>
    public UserInformationDto UserInformation { get; set; } = new(true);

    /// <summary>
    ///     This sets the session on initialization of the page.
    /// </summary>
    /// <returns>
    ///     Returns the restored session, or null if nothing was restored.
    /// </returns>
    public async Task<Session?> RestoreSessionOnInit()
    {
        var session = await _authService.RestoreSessionOnInit();
        if (session == null) return null;

        _logger.LogInfo($"User session restored with email: {session.User!.Email}");
        return session;
    }

    /// <summary>
    ///     This sets a dto holding information about the current user in order to show the current users infos in the profile
    ///     card
    /// </summary>
    /// <returns>
    ///     Returns a task of type UserInformationDto. The dto is used to update the state in the view.
    /// </returns>
    public async Task<UserInformationDto?> SetUserInfo()
    {
        try
        {
            var currentSession = _authService.GetCurrentSession();
            if (currentSession != null) return await _userService.GetUserInfo(Guid.Parse(currentSession.User!.Id!));
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }

        return null;
    }

    /// <summary>
    ///     This function persists a new avatar of the currently authenticated user
    /// </summary>
    /// <param name="base64Encoding">
    ///     The base64Encoding to persist to db
    /// </param>
    /// <returns>
    ///     Returns a task of type string. The string represents the base64 encoding persisted in db.
    /// </returns>
    public async Task<string?> PersistUserAvatarInDb(string base64Encoding)
    {
        _logger.LogDebug("User ProfilePic tried to retrieve");
        var currentUserId = _authService.GetCurrentSession()?.User?.Id;
        if (currentUserId != null)
            try
            {
                var currentUser = await _userService.GetUserDaoById(Guid.Parse(currentUserId));
                currentUser.ProfilePic = base64Encoding;
                await _userService.UpdateUser(currentUser);
                return base64Encoding;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

        _logger.LogDebug("User ProfilePic could not be restored. Caused by NullPointReference on current session");
        return null;
    }

    /// <summary>
    ///     Initializes the ViewModel with the specified user ID.
    /// </summary>
    /// <param name="userId">The ID of the user to load information for.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task Initialize(Guid? userId)
    {
        if (userId is not null)
            try
            {
                var userInfo = await _userService.GetUserInfo(userId.Value, false, false);
                if (userInfo is not null) UserInformation = userInfo;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Failed to load user information for user {userId}. In comment view model.");
            }
    }
}