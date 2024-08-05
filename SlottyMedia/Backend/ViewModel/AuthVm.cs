using Microsoft.JSInterop;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using Supabase.Gotrue;

namespace SlottyMedia.Backend.ViewModel;
public class AuthVm : IAuthVm
{
    private readonly IAuthService _authService;
    private readonly IJSRuntime _jsRuntime;
    
    public AuthVm(IAuthService authService, IJSRuntime jsRuntime)
    {
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        _jsRuntime = jsRuntime ?? throw new ArgumentNullException(nameof(jsRuntime));
    }
    
    public ValueTask SetCookie(string name, string value, int days)
    {
        return _jsRuntime.InvokeVoidAsync("setCookie", name, value, days);
    }

    public  ValueTask<string> GetCookie(string name)
    {
        return _jsRuntime.InvokeAsync<string>("getCookie", name);
    }

    public ValueTask<string> RemoveCookie(string name)
    {
        return _jsRuntime.InvokeAsync<string>("RemoveCookie", name);
    }
    
    
    public async Task<Session?> RegisterAsync(string email, string password)
    {
        var session = await _authService.SignUp(email, password);
        if (session != null)
        {
            await SaveSessionAsync(session);
        }
        return session;
    }

    public async Task<Session?> LoginAsync(string email, string password)
    {
        var session = await _authService.SignIn(email, password);
        if (session != null)
        {
            await SaveSessionAsync(session);
        }
        return session;
    }

    public async Task<Session?> RestoreSessionAsync()
    {
        var accessToken = await GetCookie("supabase.auth.token");
        var refreshToken = await GetCookie("supabase.auth.refreshToken");
        if (!string.IsNullOrEmpty(accessToken) && !string.IsNullOrEmpty(refreshToken))
        {
            try
            {
                var session = await _authService.RefreshSession(accessToken ,refreshToken);
                if (session != null)
                {
                    await SaveSessionAsync(session);
                    return session;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error refreshing session: {ex.Message}");
                await LogoutAsync();
            }
        }
        return null;
    }

    public async Task SaveSessionAsync(Session session)
    {
        await SetCookie("supabase.auth.token", session.AccessToken, 7);
        await SetCookie("supabase.auth.refreshToken", session.RefreshToken, 7);
    }

    public async Task LogoutAsync()
    {
        await _authService.SignOut();
        await RemoveCookie( "supabase.auth.token");
        await RemoveCookie( "supabase.auth.refreshToken");
    }

    public Session? GetCurrentSession()
    {
        return _authService.GetCurrentSession();
    }
}