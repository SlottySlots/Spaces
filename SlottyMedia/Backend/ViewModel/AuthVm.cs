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
        var accessToken = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "supabase.auth.token");
        var refreshToken = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "supabase.auth.refreshToken");
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
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "supabase.auth.token", session.AccessToken);
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "supabase.auth.refreshToken", session.RefreshToken);
    }

    public async Task LogoutAsync()
    {
        await _authService.SignOut();
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "supabase.auth.token");
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "supabase.auth.refreshToken");
    }
}