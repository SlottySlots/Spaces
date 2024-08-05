using Microsoft.JSInterop;
using SlottyMedia.Backend.Services;
using SlottyMedia.Backend.Services.Interfaces;
using Supabase.Gotrue;
using Client = Supabase.Client;
/// <summary>
/// This class is used to implement the IAuthService.
/// </summary>
/// <param name="supabaseClient"></param>
public class AuthService : IAuthService
{
    private readonly Client _supabaseClient;
    private readonly IJSRuntime _jsRuntime;
    private readonly ICookieService _cookieService;

    public AuthService(Client supabaseClient, IJSRuntime jsRuntime, ICookieService cookieService)
    {
        _supabaseClient = supabaseClient;
        _jsRuntime = jsRuntime;
        _cookieService = cookieService;
    }
    
    /// <summary>
    /// This method is used to sign up the user.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<Session?> SignUp(string email, string password)
    {
        var session = await _supabaseClient.Auth.SignUp(email, password);
        if (session != null)
        {
            await SaveSessionAsync(session);
        }
        return session;
    }
    
    /// <summary>
    /// This method is used to sign in the user.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<Session?> SignIn(string? email, string? password)
    {
        var session = await _supabaseClient.Auth.SignIn(email, password);
        if (session != null)
        {
            await SaveSessionAsync(session);
        }
        return session;
    }

    public async Task SaveSessionAsync(Session session)
    {
        await _cookieService.SetCookie("supabase.auth.token", session.AccessToken, 7);
        await _cookieService.SetCookie("supabase.auth.refreshToken", session.RefreshToken, 7);
    }

    public async Task<Session?> RestoreSessionAsync()
    {
        var accessToken = await _cookieService.GetCookie("supabase.auth.token");
        var refreshToken = await _cookieService.GetCookie("supabase.auth.refreshToken");
        if (!string.IsNullOrEmpty(accessToken) && !string.IsNullOrEmpty(refreshToken))
        {
            try
            {
                var session = await RefreshSession(accessToken ,refreshToken);
                if (session != null)
                {
                    await SaveSessionAsync(session);
                    return session;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error refreshing session: {ex.Message}");
                await SignOut();
            }
        }
        return null;
    }
    
    public async Task<Session?> SetSession(string sessionToken, string refreshToken)
    {
        var session = await _supabaseClient.Auth.SetSession(sessionToken, refreshToken);
        return session; 
    }
    
    /// <summary>
    /// This method is used to sign out the user.
    /// </summary>
    public async Task SignOut()
    {
        await _supabaseClient.Auth.SignOut();
        await _cookieService.RemoveCookie( "supabase.auth.token");
        await _cookieService.RemoveCookie( "supabase.auth.refreshToken");
    }

    public async Task<Session?> RefreshSession(string accessToken, string refreshToken)
    {
        var session = await _supabaseClient.Auth.SetSession(accessToken, refreshToken, false);
        return session;
    }

    /// <summary>
    /// This method is used to check if the user is authenticated.
    /// </summary>
    /// <returns></returns>
    public bool IsAuthenticated()
    {
        return _supabaseClient.Auth.CurrentSession != null;
    }

    public Session? GetCurrentSession()
    {
        var session = _supabaseClient.Auth.CurrentSession;
        return session;
    }
}
