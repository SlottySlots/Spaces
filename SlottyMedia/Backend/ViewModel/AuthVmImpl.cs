using SlottyMedia.Backend.Services.Interfaces;
using Supabase.Gotrue;

namespace SlottyMedia.Backend.ViewModel;

public class AuthVmImpl
{
    private readonly IAuthService _authService;

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