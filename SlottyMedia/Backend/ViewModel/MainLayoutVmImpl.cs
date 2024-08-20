using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using SlottyMedia.LoggingProvider;
using Supabase.Gotrue;

namespace SlottyMedia.Backend.ViewModel;
/// <summary>
/// ViewModel of the MainLayout which is essentially the root view of SlottyMedia
/// </summary>
public class MainLayoutVmImpl : IMainLayoutVm
{
    /// <summary>
    /// AuthService used for restoring a session
    /// </summary>
    private readonly IAuthService _authService;

    /// <summary>
    /// DatabaseActions used to perform crud operations such as updating the description
    /// </summary>
    private readonly IDatabaseActions _databaseActions;
    
    /// <summary>
    /// Logger used to log restores sessions.
    /// </summary>
    private readonly Logging _logger = Logging.Instance;
    
    public MainLayoutVmImpl(IAuthService authService, IDatabaseActions databaseActions)
    {
        _authService = authService;
        _databaseActions = databaseActions;
    }
    
    /// <summary>
    /// This sets the session on initialization of the page.
    /// </summary>
    /// <returns>
    /// Returns the restored session, or null if nothing was restored.
    /// </returns>
    public async Task<Session?> RestoreSessionOnInit()
    {
        Session? session = await _authService.RestoreSessionOnInit();
        if (session == null)
        {
            return null;
        }
        else
        {
            _logger.LogInfo($"User session restored with email: {session.User!.Email}");
            return session;
        }
    }
    
    /// <summary>
    /// This sets a dto holding information about the current user in order to show the current users infos in the profile card 
    /// </summary>
    /// <returns>
    /// Returns a task of type UserInformationDto. The dto is used to update the state in the view.
    /// </returns>
    public async Task<UserInformationDto?> SetUserInfo()
    {
        var currentSession = _authService.GetCurrentSession();
        if (currentSession != null)
        {
            var userDao = await _databaseActions.GetEntityByField<UserDao>("email", currentSession.User!.Email!);
            if (userDao is { UserId: null, UserName: null, Description: null, Email: null })
            {
                _logger.LogError($"User with mail {currentSession.User.Email} retrieved corrupt User entry from database!");
            }
            else
            {
                UserInformationDto userInformationDto = new UserInformationDto
                {
                    UserId = userDao.UserId!,
                    Username = userDao.UserName!,
                    Description = userDao.Description!,
                    ProfilePic = userDao.ProfilePic,
                    CreatedAt = userDao.CreatedAt!
                };
                return userInformationDto;
            }
        }
        return null;
    }
    
    /// <summary>
    /// This function persists a new avatar of the currently authenticated user
    /// </summary>
    /// <param name="base64Encoding">
    /// The base64Encoding to persist to db
    /// </param>
    /// <returns>
    /// Returns a task of type string. The string represents the base64 encoding persisted in db.
    /// </returns>
    public async Task<string?> PersistUserAvatarInDb(string base64Encoding)
    {
        var currentUserEmail = _authService.GetCurrentSession()?.User?.Email;
        if (currentUserEmail != null)
        {
            var currentUser = await _databaseActions.GetEntityByField<UserDao>("email", currentUserEmail);
            currentUser.ProfilePic = base64Encoding;
            await _databaseActions.Update(currentUser);
            return base64Encoding;
        }

        return null;
    }
}