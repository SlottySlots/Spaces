using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using Supabase.Gotrue;

namespace SlottyMedia.Backend.ViewModel;

public class RegisterVm : IRegisterVm
{
    private readonly IAuthService _authService;

    public RegisterVm(IAuthService authService, ICookieService cookieService)
    {
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
    }


    public async Task<Session?> RegisterAsync(string email, string password)
    {
        var session = await _authService.SignUp(email, password);
        return session;
    }

    public async Task<Session?> RestoreSessionAsync()
    {
        var session = await _authService.RestoreSessionAsync();
        return session;
    }

    public Session? GetCurrentSession()
    {
        return _authService.GetCurrentSession();
    }
}