using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using Supabase.Gotrue;

namespace SlottyMedia.Backend.ViewModel;

/// <summary>
///     This class implements the IAuthVmImpl interface
/// </summary>
public class AuthVmImpl : IAuthVm
{
    private readonly IAuthService _authService;

    /// <summary>
    ///     This constructor initializes the AuthService
    /// </summary>
    /// <param name="authVmImpl"></param>
    public AuthVmImpl(IAuthService authVmImpl)
    {
        _authService = authVmImpl;
    }

    /// <inheritdoc />
    public Session? GetCurrentSession()
    {
        return _authService.GetCurrentSession();
    }
}